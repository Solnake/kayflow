--if db_id('Kayflow') is not null
--	RAISERROR ('DB Already Exists', 20, 1) WITH LOG
--GO

--CREATE DATABASE [Kayflow]
--COLLATE Ukrainian_CI_AS
--GO

--USE [Kayflow]
--GO

--
-- Definition for table Category : 
--

CREATE TABLE [dbo].[Category] (
  [CategoryID] uniqueidentifier CONSTRAINT [DF_Category_CategoryID] DEFAULT newid() NOT NULL,
  [CategoryName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Office : 
--

CREATE TABLE [dbo].[Office] (
  [OfficeID] uniqueidentifier CONSTRAINT [DF_Office_OfficeID] DEFAULT newid() NOT NULL,
  [OfficeName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [IsDefault] bit NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table TerritorialUnit : 
--

CREATE TABLE [dbo].[TerritorialUnit] (
  [TerritorialUnitID] uniqueidentifier CONSTRAINT [DF_TerritorialUnit_TerritorialUnitID] DEFAULT newid() NOT NULL,
  [ParentID] uniqueidentifier NULL,
  [UnitName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [UnitType] int NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Employee : 
--

CREATE TABLE [dbo].[Employee] (
  [EmployeeID] uniqueidentifier CONSTRAINT [DF_Employee_EmployeeID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [FirstName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [LastName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [MiddleName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [Login] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [Password] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [Permission] int NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Act : 
--

CREATE TABLE [dbo].[Act] (
  [ActID] uniqueidentifier CONSTRAINT [DF_Act_ActID] DEFAULT newid() NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [MeteringDate] datetime NOT NULL,
  [TerritorialUnitID] uniqueidentifier NOT NULL,
  [Address] nvarchar(256) COLLATE Ukrainian_CI_AS NULL,
  [CustomerName] nvarchar(256) COLLATE Ukrainian_CI_AS NOT NULL,
  [CustomerPhone] nvarchar(36) COLLATE Ukrainian_CI_AS NULL,
  [AreaAmount] int NOT NULL,
  [ActAmount] int NOT NULL,
  [CategoryID] uniqueidentifier NOT NULL,
  [TotalCost] float NULL,
  [PaidOn] float NULL,
  [LeftOn] float NULL,
  [Approval1] float NULL,
  [KailasPaid1] float NULL,
  [KailasDue] float NULL,
  [PaidDue] float NULL,
  [Approval2] float NULL,
  [KailasPaid2] float NULL,
  [SalaryCalculated] float NOT NULL,
  [SalaryPaidDate] datetime NULL,
  [CalculatedMain] float NOT NULL,
  [PaidMainDate] datetime NULL,
  [ActDate] datetime NULL,
  [ActNum] varchar(10) COLLATE Ukrainian_CI_AS NULL,
  [Description] nvarchar(256) COLLATE Ukrainian_CI_AS NULL
)
ON [PRIMARY]
GO

--
-- Definition for table ActAction : 
--

CREATE TABLE [dbo].[ActAction] (
  [ActActionID] uniqueidentifier CONSTRAINT [DF_ActAction_ActActionID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [ActionName] varchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [OrdNum] int NOT NULL,
  [Hidden] bit NOT NULL,
  [AlertDays] int NULL,
  [RelativeAlertDays] int NULL,
  [AlertColor] int NULL
)
ON [PRIMARY]
GO

--
-- Definition for table ValueSet : 
--

CREATE TABLE [dbo].[ValueSet] (
  [ValueSetID] uniqueidentifier CONSTRAINT [DF_ValueSet_ValueSetID] DEFAULT newid() NOT NULL,
  [SetName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table DocumentValue : 
--

CREATE TABLE [dbo].[DocumentValue] (
  [DocumentValueID] uniqueidentifier CONSTRAINT [DF_DocumentValue_DocumentValueID] DEFAULT newid() NOT NULL,
  [ValueSetID] uniqueidentifier NOT NULL,
  [DocValue] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [DocColor] int NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table DocumentGroup : 
--

CREATE TABLE [dbo].[DocumentGroup] (
  [DocumentGroupID] uniqueidentifier CONSTRAINT [DF_DocumentGroup_DocumentGroupID] DEFAULT newid() NOT NULL,
  [GroupName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [OrdNum] int NOT NULL,
  [Hidden] bit NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Document : 
--

CREATE TABLE [dbo].[Document] (
  [DocumentID] uniqueidentifier CONSTRAINT [DF_Document_DocumentID] DEFAULT newid() NOT NULL,
  [DocumentName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [DocumentGroupID] uniqueidentifier NOT NULL,
  [OrdNum] int NOT NULL,
  [Hidden] bit NOT NULL,
  [ValueSetID] uniqueidentifier NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table ActDocument : 
--

CREATE TABLE [dbo].[ActDocument] (
  [ActDocumentID] uniqueidentifier CONSTRAINT [DF_ActDocument_ActDocumentID] DEFAULT newid() NOT NULL,
  [ActID] uniqueidentifier NOT NULL,
  [DocumentID] uniqueidentifier NOT NULL,
  [DocumentValueID] uniqueidentifier NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table ActHistory : 
--

CREATE TABLE [dbo].[ActHistory] (
  [ActHistoryID] uniqueidentifier CONSTRAINT [DF_ActHistory_ActHistoryID] DEFAULT newid() NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [OnDate] datetime NOT NULL,
  [Description] nvarchar(1024) COLLATE Ukrainian_CI_AS NOT NULL,
  [ActID] uniqueidentifier NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Cost : 
--

CREATE TABLE [dbo].[Cost] (
  [CostID] uniqueidentifier CONSTRAINT [DF_Cost_CostID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [CostName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL,
  [Hidden] bit NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Expense : 
--

CREATE TABLE [dbo].[Expense] (
  [ExpenseID] uniqueidentifier CONSTRAINT [DF_Expense_ExpenseID] DEFAULT newid() NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [OnDate] datetime NOT NULL,
  [Distance] int NULL
)
ON [PRIMARY]
GO

--
-- Definition for table ExpenseCost : 
--

CREATE TABLE [dbo].[ExpenseCost] (
  [ExpenseID] uniqueidentifier NOT NULL,
  [CostID] uniqueidentifier NOT NULL,
  [Amount] float NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Layout : 
--

CREATE TABLE [dbo].[Layout] (
  [LayoutID] uniqueidentifier CONSTRAINT [DF_Layout_LayoutID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [LayoutData] varbinary(max) NOT NULL,
  [LayoutType] int NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Note : 
--

CREATE TABLE [dbo].[Note] (
  [NoteID] uniqueidentifier CONSTRAINT [DF_Note_NoteID] DEFAULT newid() NOT NULL,
  [ActID] uniqueidentifier NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [OnDate] datetime NOT NULL,
  [Description] nvarchar(512) COLLATE Ukrainian_CI_AS NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table PaymentDataSettings : 
--

CREATE TABLE [dbo].[PaymentDataSettings] (
  [PaymentDataSettingsID] uniqueidentifier CONSTRAINT [DF_PaymentDataSettings_PaymentDataSettingsID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [PaymentFieldID] int NOT NULL,
  [Show] bit NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table State : 
--

CREATE TABLE [dbo].[State] (
  [StateID] uniqueidentifier CONSTRAINT [DF_State_StateID] DEFAULT newid() NOT NULL,
  [OfficeID] uniqueidentifier NOT NULL,
  [StateName] nvarchar(128) COLLATE Ukrainian_CI_AS NOT NULL
)
ON [PRIMARY]
GO

--
-- Definition for table StateHistory : 
--

CREATE TABLE [dbo].[StateHistory] (
  [StateHistoryID] uniqueidentifier CONSTRAINT [DF_StateHistory_StateHistoryID] DEFAULT newid() NOT NULL,
  [ActID] uniqueidentifier NOT NULL,
  [StateID] uniqueidentifier NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [OnDate] datetime NOT NULL,
  [Description] nvarchar(1024) COLLATE Ukrainian_CI_AS NULL
)
ON [PRIMARY]
GO

--
-- Definition for table Step : 
--

CREATE TABLE [dbo].[Step] (
  [StepID] uniqueidentifier CONSTRAINT [DF_Step_StepID] DEFAULT newid() NOT NULL,
  [ActID] uniqueidentifier NOT NULL,
  [ActActionID] uniqueidentifier NOT NULL,
  [EmployeeID] uniqueidentifier NOT NULL,
  [Delivered] datetime NULL,
  [Received] datetime NULL
)
ON [PRIMARY]
GO

--
-- Definition for table sysdiagrams : 
--

CREATE TABLE [dbo].[sysdiagrams] (
  [name] sysname COLLATE Ukrainian_CI_AS NOT NULL,
  [principal_id] int NOT NULL,
  [diagram_id] int IDENTITY(1, 1) NOT NULL,
  [version] int NULL,
  [definition] varbinary(max) NULL
)
ON [PRIMARY]
GO

--
-- Definition for user-defined function fn_diagramobjects : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION dbo.fn_diagramobjects() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
GO

--
-- Definition for view vEmployee : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW dbo.vEmployee
AS
  select e.*, o.OfficeName
  	, e.LastName + ' ' + e.FirstName + ' ' + e.MiddleName DisplayName
  from Employee e
  join Office o on o.OfficeID=e.OfficeID
GO

--
-- Definition for view vExpenseCost : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW dbo.vExpenseCost
AS
	select e.*
    	, c.CostName
    from ExpenseCost e
    join Cost c on c.CostID=e.CostID
GO

--
-- Definition for view vExpiredSteps : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW dbo.vExpiredSteps
AS
with steps as
(
select a.ActID
	, case 
    	when a.RelativeAlertDays is null then a.AlertDays
        when a.RelativeAlertDays>a.AlertDays then a.RelativeAlertDays
      else a.AlertDays
      end DaysForAlert
    , a.ActionName, a.OrdNum, a.ActActionID, a.AlertColor
    , RANK() over (partition by a.ActID order by case 
    	when a.RelativeAlertDays is null then a.AlertDays
        when a.RelativeAlertDays>a.AlertDays then a.RelativeAlertDays
      else a.AlertDays
      end desc, a.OrdNum) RankID 
from
	(
      select s.ActID, aa.ActionName, aa.OrdNum, aa.ActActionID, aa.AlertColor
          , DATEDIFF(dd, a.MeteringDate, getdate()) as DaysLeft
          , case 
              when aa.AlertDays is not null then DATEDIFF(dd, a.MeteringDate, getdate()) - aa.AlertDays
            else
              NULL
            end AlertDays   
          , case
              when isnull(aa.RelativeAlertDays, 0) = 0 then null
              when isnull(aa.RelativeAlertDays, 0) != 0 then 
                  case 
                      when (select top 1 st.Received
                                        from Step st
                                        join ActAction aat on aat.ActActionID=st.ActActionID
                                        where
                                          ActID = s.ActID
                                          and aat.OrdNum<aa.OrdNum
                                        order by
                                          aat.OrdNum desc) is null then null
                      else DATEDIFF(dd, (select top 1 st.Received
                                        from Step st
                                        join ActAction aat on aat.ActActionID=st.ActActionID
                                        where
                                          ActID = s.ActID
                                          and aat.OrdNum<aa.OrdNum
                                        order by
                                          aat.OrdNum desc), getdate()) - aa.RelativeAlertDays
                   end   	                    
            end RelativeAlertDays
      from Step s
      join ActAction aa on aa.ActActionID=s.ActActionID
      join Act a on a.ActID=s.ActID
      where
          s.Received is null
	) as a
)
select s.ActID, s.ActionName, s.OrdNum, s.ActActionID, s.AlertColor, s.DaysForAlert
from steps s
where
	s.RankID = 1
    and s.DaysForAlert>0
GO

--
-- Definition for stored procedure sp_alterdiagram : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
GO

--
-- Definition for stored procedure sp_creatediagram : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
GO

--
-- Definition for stored procedure sp_dropdiagram : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO

--
-- Definition for stored procedure sp_helpdiagramdefinition : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
GO

--
-- Definition for stored procedure sp_helpdiagrams : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO

--
-- Definition for stored procedure sp_renamediagram : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
GO

--
-- Definition for stored procedure sp_upgraddiagrams : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
GO

--
-- Definition for stored procedure Step_CopyFromActions : 
--
GO
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Step_CopyFromActions
	@ActID uniqueidentifier,
    @EmployeeID uniqueidentifier,
    @OfficeID uniqueidentifier
AS
BEGIN
  INSERT INTO dbo.Step(ActID, ActActionID, EmployeeID) 
  select @ActID, a.ActActionID, @EmployeeID
  from ActAction a
  where
  	a.OfficeID = @OfficeID
    and a.Hidden = 0
  order by
  	a.OrdNum  
END
GO

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


--
-- Data for table dbo.DocumentValue  (LIMIT 0,500)
--

INSERT INTO [dbo].[DocumentValue] ([DocumentValueID], [ValueSetID], [DocValue], [DocColor])
VALUES 
  (N'{2727F2A8-F853-473B-ACF9-45D413861EA7}', N'{DB760580-D1AF-4354-842D-D4FAD5660895}', N'Так', -16728064)
GO

INSERT INTO [dbo].[DocumentValue] ([DocumentValueID], [ValueSetID], [DocValue], [DocColor])
VALUES 
  (N'{FF231F64-288F-44DA-B6F8-C4747363312D}', N'{1D10DCDF-523C-4173-B518-BB4FBF615782}', N'Так', -16728064)
GO

INSERT INTO [dbo].[DocumentValue] ([DocumentValueID], [ValueSetID], [DocValue], [DocColor])
VALUES 
  (N'{1D409EE9-94BE-4A5C-B3D6-C5C436269F69}', N'{1D10DCDF-523C-4173-B518-BB4FBF615782}', N'Ні', -65536)
GO

INSERT INTO [dbo].[DocumentValue] ([DocumentValueID], [ValueSetID], [DocValue], [DocColor])
VALUES 
  (N'{C70FBB53-3DDA-4B62-9C87-CBB0B35EEFD0}', N'{DB760580-D1AF-4354-842D-D4FAD5660895}', N'Ні', -65536)
GO

INSERT INTO [dbo].[DocumentValue] ([DocumentValueID], [ValueSetID], [DocValue], [DocColor])
VALUES 
  (N'{5433763D-0E83-4B4F-9048-D1E9522904EE}', N'{1D10DCDF-523C-4173-B518-BB4FBF615782}', N'З', -256)
GO

--
-- Data for table dbo.ValueSet  (LIMIT 0,500)
--

INSERT INTO [dbo].[ValueSet] ([ValueSetID], [SetName])
VALUES 
  (N'{1D10DCDF-523C-4173-B518-BB4FBF615782}', N'Так/Ні/З')
GO

INSERT INTO [dbo].[ValueSet] ([ValueSetID], [SetName])
VALUES 
  (N'{DB760580-D1AF-4354-842D-D4FAD5660895}', N'Так/Ні')
GO

--
-- Definition for indices : 
--

ALTER TABLE [dbo].[Category]
ADD PRIMARY KEY CLUSTERED ([CategoryID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Office]
ADD PRIMARY KEY CLUSTERED ([OfficeID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[TerritorialUnit]
ADD PRIMARY KEY CLUSTERED ([TerritorialUnitID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]
ADD PRIMARY KEY CLUSTERED ([EmployeeID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Act]
ADD PRIMARY KEY CLUSTERED ([ActID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActAction]
ADD PRIMARY KEY CLUSTERED ([ActActionID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ValueSet]
ADD PRIMARY KEY CLUSTERED ([ValueSetID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[DocumentValue]
ADD CONSTRAINT [PK_DocumentValue] 
PRIMARY KEY CLUSTERED ([DocumentValueID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[DocumentGroup]
ADD CONSTRAINT [PK_DocumentGroup] 
PRIMARY KEY CLUSTERED ([DocumentGroupID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [PK_Document] 
PRIMARY KEY CLUSTERED ([DocumentID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActDocument]
ADD PRIMARY KEY CLUSTERED ([ActDocumentID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ActHistory]
ADD PRIMARY KEY CLUSTERED ([ActHistoryID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cost]
ADD PRIMARY KEY CLUSTERED ([CostID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Expense]
ADD PRIMARY KEY CLUSTERED ([ExpenseID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExpenseCost]
ADD CONSTRAINT [PK_ExpenceCost_] 
PRIMARY KEY CLUSTERED ([ExpenseID], [CostID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Layout]
ADD PRIMARY KEY CLUSTERED ([LayoutID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]
ADD PRIMARY KEY CLUSTERED ([NoteID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentDataSettings]
ADD PRIMARY KEY CLUSTERED ([PaymentDataSettingsID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[State]
ADD PRIMARY KEY CLUSTERED ([StateID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[StateHistory]
ADD PRIMARY KEY CLUSTERED ([StateHistoryID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Step]
ADD PRIMARY KEY CLUSTERED ([StepID])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = OFF,
  ALLOW_PAGE_LOCKS = OFF)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[sysdiagrams]
ADD PRIMARY KEY CLUSTERED ([diagram_id])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [UK_principal_name] 
UNIQUE NONCLUSTERED ([principal_id], [name])
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

--
-- Definition for foreign keys : 
--

ALTER TABLE [dbo].[TerritorialUnit]
ADD CONSTRAINT [FK_TerritorialUnit_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[TerritorialUnit]
ADD CONSTRAINT [FK_TerritorialUnit_TerritorialUnit_ParentID] FOREIGN KEY ([ParentID]) 
  REFERENCES [dbo].[TerritorialUnit] ([TerritorialUnitID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Act]
ADD CONSTRAINT [FK_Act_Category_CategoryID] FOREIGN KEY ([CategoryID]) 
  REFERENCES [dbo].[Category] ([CategoryID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Act]
ADD CONSTRAINT [FK_Act_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Act]
ADD CONSTRAINT [FK_Act_TerritorialUnit_TerritorialUnitID] FOREIGN KEY ([TerritorialUnitID]) 
  REFERENCES [dbo].[TerritorialUnit] ([TerritorialUnitID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ActAction]
ADD CONSTRAINT [FK_ActAction_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[DocumentValue]
ADD CONSTRAINT [FK_DocumentValue_ValueSet_ValueSetID] FOREIGN KEY ([ValueSetID]) 
  REFERENCES [dbo].[ValueSet] ([ValueSetID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DocumentGroup]
ADD CONSTRAINT [FK_DocumentGroup_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [FK_Document_DocumentGroup_DocumentGroupID] FOREIGN KEY ([DocumentGroupID]) 
  REFERENCES [dbo].[DocumentGroup] ([DocumentGroupID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [FK_Document_ValueSet_ValueSetID] FOREIGN KEY ([ValueSetID]) 
  REFERENCES [dbo].[ValueSet] ([ValueSetID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ActDocument]
ADD CONSTRAINT [FK_ActDocument_Act_ActID] FOREIGN KEY ([ActID]) 
  REFERENCES [dbo].[Act] ([ActID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ActDocument]
ADD CONSTRAINT [FK_ActDocument_Document_DocumentID] FOREIGN KEY ([DocumentID]) 
  REFERENCES [dbo].[Document] ([DocumentID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ActDocument]
ADD CONSTRAINT [FK_ActDocument_DocumentValue_DocumentValueID] FOREIGN KEY ([DocumentValueID]) 
  REFERENCES [dbo].[DocumentValue] ([DocumentValueID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ActHistory]
ADD CONSTRAINT [FK_ActHistory_Act_ActID] FOREIGN KEY ([ActID]) 
  REFERENCES [dbo].[Act] ([ActID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ActHistory]
ADD CONSTRAINT [FK_ActHistory_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Cost]
ADD CONSTRAINT [FK_CostID_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Expense]
ADD CONSTRAINT [FK_Expense_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ExpenseCost]
ADD CONSTRAINT [FK_ExprenceCost_Cost_CostID] FOREIGN KEY ([CostID]) 
  REFERENCES [dbo].[Cost] ([CostID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ExpenseCost]
ADD CONSTRAINT [FK_ExprenceCost_Expense_ExprenseID] FOREIGN KEY ([ExpenseID]) 
  REFERENCES [dbo].[Expense] ([ExpenseID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Layout]
ADD CONSTRAINT [FK_Layout_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [FK_Note_Act_ActID] FOREIGN KEY ([ActID]) 
  REFERENCES [dbo].[Act] ([ActID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Note]
ADD CONSTRAINT [FK_Note_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[PaymentDataSettings]
ADD CONSTRAINT [FK_PaymentDataSettings_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[State]
ADD CONSTRAINT [FK_State_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
  REFERENCES [dbo].[Office] ([OfficeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[StateHistory]
ADD CONSTRAINT [FK_StateHistory_Act_ActID] FOREIGN KEY ([ActID]) 
  REFERENCES [dbo].[Act] ([ActID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[StateHistory]
ADD CONSTRAINT [FK_StateHistory_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[StateHistory]
ADD CONSTRAINT [FK_StateHistory_State_StateID] FOREIGN KEY ([StateID]) 
  REFERENCES [dbo].[State] ([StateID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [FK_Step_Act_ActID] FOREIGN KEY ([ActID]) 
  REFERENCES [dbo].[Act] ([ActID]) 
  ON UPDATE NO ACTION
  ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [FK_Step_ActAction_ActActionID] FOREIGN KEY ([ActActionID]) 
  REFERENCES [dbo].[ActAction] ([ActActionID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[Step]
ADD CONSTRAINT [FK_Step_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) 
  REFERENCES [dbo].[Employee] ([EmployeeID]) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

CREATE LOGIN [dbuser] WITH PASSWORD = N'qwe@poi1' ,
  CHECK_POLICY = OFF,
  CHECK_EXPIRATION = OFF
GO

CREATE USER [dbuser] FOR LOGIN [dbuser] 
GO

EXEC sp_addrolemember N'db_owner', N'dbuser'
GO
