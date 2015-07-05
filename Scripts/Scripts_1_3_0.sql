IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'DropTableRecord')
BEGIN
	DROP PROCEDURE [dbo].[DropTableRecord]
END
GO

CREATE PROCEDURE [dbo].[DropTableRecord]
	@TableName varchar(255),
    @FieldName varchar(255),
    @ID uniqueidentifier,
    @IsEntryPoint bit = 0,
    @OfficeID uniqueidentifier = NULL,
    @TerminateProcess bit = 0 OUTPUT
AS
BEGIN

IF @TerminateProcess = 1
    RETURN

/* Check for maximum recursion depth */
IF @@NESTLEVEL = 32
    RETURN
    
/* Set OfficeID as original ID */
IF @OfficeID IS NULL AND @IsEntryPoint = 1
	SET @OfficeID = @ID
    
/* Creating temporary table (need for recursion) if it's first proc launch*/
IF @IsEntryPoint = 1
BEGIN
	IF OBJECT_ID('tempdb..#TmpDropTableRecord') IS NOT NULL 
		DROP TABLE #TmpDropTableRecord   
    CREATE TABLE #TmpDropTableRecord (
    	RecID int IDENTITY(1, 1) NOT NULL,
        TableName varchar(255),
        PKFieldName varchar(255),
        ID uniqueidentifier,
        OfficeID uniqueidentifier
    )
   
	IF OBJECT_ID('tempdb..#ActDropTableRecord') IS NOT NULL 
		DROP TABLE #ActDropTableRecord   
    CREATE TABLE #ActDropTableRecord (
    	RecID int IDENTITY(1, 1) NOT NULL,
        TableName varchar(255),
        PKFieldName varchar(255),
        ID uniqueidentifier
    )    
    
	IF OBJECT_ID('tempdb..#CallStackDropTableRecord') IS NOT NULL 
		DROP TABLE #CallStackDropTableRecord   
    CREATE TABLE #CallStackDropTableRecord (
    	RecID int IDENTITY(1, 1) NOT NULL,
        TableName varchar(255),
        ID uniqueidentifier,
        NestLevel int
    )   
	
	IF OBJECT_ID('tempdb..#ExceptionTable') IS NOT NULL 
		DROP TABLE #ExceptionTable   
    CREATE TABLE #ExceptionTable (
        TableName varchar(255)
    )    

	insert into #ExceptionTable(TableName)
	select 'Employee'
	union all
	select 'Office'
END

    INSERT INTO #CallStackDropTableRecord
    VALUES (@TableName, @ID, @@NESTLEVEL)

/* If source record already added for deleting then go away*/
IF EXISTS (
  	SELECT 0
    FROM #ActDropTableRecord
    WHERE TableName = @TableName AND PKFieldName = @FieldName AND ID = @ID
)
	RETURN    

/* Collect all FK to [Office] table */
DECLARE @LinksToOfficeTable TABLE (
    LinkedTableName varchar(255),
    LinkedFieldName varchar(255)
)
INSERT INTO @LinksToOfficeTable
SELECT FK.TABLE_NAME, CU.COLUMN_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
WHERE PK.TABLE_NAME = 'Office'

/* Get the foreign keys with Tables list*/
DECLARE @FK TABLE (
    ID int IDENTITY(1, 1) NOT NULL,
    ParentTableName varchar(255),    
    ParentFieldName varchar(255), 
    TableName varchar(255),
    FieldName varchar(255),
    FKName varchar(255),
    PKName varchar(255),
    OfficeIDFieldName varchar(255)
)

INSERT INTO @FK(ParentTableName, ParentFieldName, TableName, FieldName, FKName, PKName, OfficeIDFieldName)
SELECT PK.TABLE_NAME, PT.COLUMN_NAME, FK.TABLE_NAME, CU.COLUMN_NAME, C.CONSTRAINT_NAME, FPK.COLUMN_NAME, ISNULL(lct.LinkedFieldName, CLM.column_name)
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
    INNER JOIN (
        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
    ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
    INNER JOIN (
        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
    ) FPK ON FPK.TABLE_NAME = FK.TABLE_NAME
    LEFT JOIN INFORMATION_SCHEMA.[COLUMNS] CLM ON CLM.table_name = FK.TABLE_NAME AND LOWER(CLM.column_name) = 'OfficeID'
    LEFT JOIN @LinksToOfficeTable lct ON lct.LinkedTableName = FK.TABLE_NAME
    left join #ExceptionTable e on e.TableName = FK.TABLE_NAME
WHERE PK.TABLE_NAME = @TableName AND C.DELETE_RULE <> 'CASCADE'
	and e.TableName is null
ORDER BY PK.TABLE_NAME, PT.COLUMN_NAME, FK.TABLE_NAME, CU.COLUMN_NAME  

/* Generate script for getting all depended records from depended tables (via FK) */
DECLARE @Script varchar(MAX)
SET @Script = ''

SELECT @Script = @Script + CHAR(13) + CHAR(10) +
	CASE
    	WHEN @Script = '' THEN ''
        ELSE '  UNION ALL' + CHAR(13) + CHAR(10)
    END
    + '  SELECT ''' + TableName + ''' AS TableName, ''' + PKName +
        ''' AS PKFieldName, ' + PKName + ' AS ID, ' +
        CASE
            WHEN OfficeIDFieldName IS NULL THEN 'NULL AS OfficeID'
            ELSE OfficeIDFieldName + ' AS OfficeID'
        END
        + CHAR(13) + CHAR(10) +        
    + '  FROM [' + TableName + ']'
    + '  WHERE ' + FieldName + ' = ''' + CAST(@ID AS varchar(128)) + ''''
FROM @FK    

/* If there are no depended tables then go away */
IF (@Script = '' and not exists (select 'x' from #ExceptionTable e where e.TableName = @TableName))
BEGIN	
    INSERT INTO #ActDropTableRecord(TableName, PKFieldName, ID)
    VALUES (@TableName, @FieldName, @ID)        
	RETURN    
END
    
/* Getting first record (for knowing from which record start loop) */
DECLARE @FromRecID int
DECLARE @ToRecID int
SELECT @FromRecID = ISNULL(MAX(RecID), 0) + 1 FROM #TmpDropTableRecord
    
/* Add depended records into tmp table */
SET @Script =
	'INSERT INTO #TmpDropTableRecord(TableName, PKFieldName, ID, OfficeID)' + CHAR(13) + CHAR(10)
    + 'SELECT TableName, PKFieldName, ID, OfficeID' + CHAR(13) + CHAR(10)
    + 'FROM (' + CHAR(13) + CHAR(10)
    + @Script + CHAR(13) + CHAR(10)
    + ') x' + CHAR(13) + CHAR(10)
    + 'WHERE NOT EXISTS (' + CHAR(13) + CHAR(10)
    + '  SELECT 0' + CHAR(13) + CHAR(10)
    + '  FROM #ActDropTableRecord a' + CHAR(13) + CHAR(10)
    + '  WHERE a.TableName = x.TableName AND a.PKFieldName = x.PKFieldName AND a.ID = x.ID' + CHAR(13) + CHAR(10)
    + ')' + CHAR(13) + CHAR(10)



EXEC(@Script)



/* */
DECLARE @ErrTableName varchar(255)
DECLARE @ErrID uniqueidentifier
DECLARE @ErrOfficeID uniqueidentifier

SELECT @ErrTableName = TableName, @ErrID = ID, @ErrOfficeID = OfficeID
FROM #TmpDropTableRecord
WHERE OfficeID <> @OfficeID

IF @ErrTableName IS NOT NULL
BEGIN
    SET @TerminateProcess = 1
    
    DECLARE @CallStack varchar(MAX)
    SET @CallStack = ''
    SELECT @CallStack = @CallStack + CHAR(13) + CHAR(10)
        + REPLICATE(' ', NestLevel) + '-> ' + TableName + '(ID = ''' + CAST(ID AS varchar(128)) + ''')'
    FROM #CallStackDropTableRecord
    ORDER BY RecID
    PRINT @CallStack
    
	DECLARE @ErrMessage varchar(255)
    SET @ErrMessage = 'Another OfficeID found (''' + CAST(@ErrOfficeID AS varchar(128)) + ''') in table [' + @ErrTableName + '], ID = ''' + CAST(@ErrID AS varchar(128)) + ''''
    RAISERROR(@ErrMessage, 16, 1)
    RETURN
END

/* Getting last record (for knowing to which record loop cursor)*/
SELECT @ToRecID = ISNULL(MAX(RecID), 0) FROM #TmpDropTableRecord

/* If there are no depended records then go away*/
IF (@FromRecID > @ToRecID and not exists (select 'x' from #ExceptionTable e where e.TableName = @TableName))
BEGIN	
    INSERT INTO #ActDropTableRecord(TableName, PKFieldName, ID)
    VALUES (@TableName, @FieldName, @ID)      
	RETURN    
END

/* Logging Progress */
IF @IsEntryPoint = 1
BEGIN
	DECLARE @CurrentDepIndex int
    SET @CurrentDepIndex = 0
    DECLARE @Progress int
    SET @Progress = 0
	DECLARE @DepCount int
    SELECT @DepCount = COUNT(*)
    FROM #TmpDropTableRecord
END
    

/* Initialize loop*/
DECLARE @cTableName varchar(255)
DECLARE @cPKFieldName varchar(255)
DECLARE @cID uniqueidentifier

DECLARE @cur CURSOR
SET @cur = CURSOR FOR
    SELECT TableName, PKFieldName, ID
    FROM #TmpDropTableRecord
    WHERE RecID BETWEEN @FromRecID AND @ToRecID

OPEN @cur

FETCH NEXT FROM @cur 
INTO @cTableName, @cPKFieldName, @cID

WHILE @@FETCH_STATUS = 0
BEGIN
	EXEC DropTableRecord @cTableName, @cPKFieldName, @cID, 0, @OfficeID, @TerminateProcess OUTPUT  /* <-- Recursion here! */   
	DELETE
    FROM #CallStackDropTableRecord
    WHERE TableName = @cTableName AND ID = @cID  

    IF @TerminateProcess = 1
        RETURN
    
    IF @IsEntryPoint = 1
	BEGIN
    	SET @CurrentDepIndex = @CurrentDepIndex + 1
        SET @Progress = ROUND((CAST(@CurrentDepIndex AS numeric(15, 0)) / @DepCount) * 100, 0)
        IF @Progress = 100
        	SET @Progress = 99
    END

    FETCH NEXT FROM @cur 
    INTO @cTableName, @cPKFieldName, @cID
END

CLOSE @cur
DEALLOCATE @cur


/* Add to delete current record (it is assumed that all depended records has been deleted)*/
IF (NOT EXISTS (
  	SELECT 0
    FROM #ActDropTableRecord
    WHERE TableName = @TableName AND PKFieldName = @FieldName AND ID = @ID
	) and not exists (select 'x' from #ExceptionTable e where e.TableName = @TableName))
	INSERT INTO #ActDropTableRecord(TableName, PKFieldName, ID)
	VALUES (@TableName, @FieldName, @ID)    
    
DELETE
FROM #CallStackDropTableRecord
WHERE TableName = @TableName AND ID = @ID       

IF @IsEntryPoint = 1
BEGIN
   
    SELECT @DepCount = COUNT(*)
    FROM #ActDropTableRecord
    
    SET @CurrentDepIndex = 0
    SET @Progress = 0;
    
    SET @cur = CURSOR FOR
        SELECT t.TableName, t.PKFieldName, t.ID
        FROM #ActDropTableRecord t 
		left join #ExceptionTable et on et.TableName = t.TableName
		where
			 et.TableName is null
        ORDER BY RecID

    OPEN @cur

    FETCH NEXT FROM @cur 
    INTO @cTableName, @cPKFieldName, @cID

    WHILE @@FETCH_STATUS = 0
    BEGIN
        PRINT 'Deleting from [' + @cTableName + '], ID = ''' + CAST(@cID AS varchar(128)) + ''''
        SET @Script = 'DELETE FROM [' + @cTableName + '] WHERE '
        	+ @cPKFieldName + ' = ''' + CAST(@cID AS varchar(128)) + ''''
        EXEC(@Script)
        
        /* Logging*/
        SET @CurrentDepIndex = @CurrentDepIndex + 1
        SET @Progress = ROUND((CAST(@CurrentDepIndex AS numeric(15, 0)) / @DepCount) * 100, 0)

        FETCH NEXT FROM @cur 
        INTO @cTableName, @cPKFieldName, @cID
    END

    CLOSE @cur
    DEALLOCATE @cur    
    
	DROP TABLE #ActDropTableRecord
	DROP TABLE #TmpDropTableRecord
    DROP TABLE #CallStackDropTableRecord
END

END

GO
