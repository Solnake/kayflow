SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW dbo.v_Acts
WITH SCHEMABINDING
AS
	select a.ActID, a.EmployeeID, a.MeteringDate, a.TerritorialUnitID, a.[Address], a.CustomerName
        , a.CustomerPhone, a.AreaAmount, a.ActAmount, a.CategoryID, a.TotalCost, a.PaidOn, a.LeftOn
        , a.Approval1, a.KailasPaid1, a.KailasDue, a.PaidDue, a.Approval2, a.KailasPaid2
        --, a.SalaryCalculated, a.SalaryPaidDate, a.CalculatedMain, a.PaidMainDate
        , a.ActDate, a.ActNum, a.[Description]
		, a.OfficeID, a.IsClosed, a.IgnoreTherms
        , e.LastName + ' ' + e.FirstName + ' ' + e.MiddleName EmployeeName
        , t.UnitName
        , c.CategoryName
    from dbo.Act a
    join dbo.Employee e on e.EmployeeID=a.EmployeeID
  	join dbo.Office o on o.OfficeID=e.OfficeID
    join dbo.TerritorialUnit t on t.TerritorialUnitID=a.TerritorialUnitID
    join dbo.Category c on c.CategoryID=a.CategoryID
GO

SET ARITHABORT ON
GO
SET CONCAT_NULL_YIELDS_NULL ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET ANSI_PADDING ON
GO
SET ANSI_WARNINGS ON
GO
SET NUMERIC_ROUNDABORT OFF
GO
CREATE UNIQUE CLUSTERED INDEX v_Acts_uq ON dbo.v_Acts
  (ActID)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

ALTER TABLE dbo.Act
ALTER COLUMN SalaryCalculated float
GO

ALTER TABLE dbo.Act
ALTER COLUMN CalculatedMain float
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW dbo.v_Acts
WITH SCHEMABINDING
AS
	select a.ActID, a.EmployeeID, a.MeteringDate, a.TerritorialUnitID, a.[Address], a.CustomerName
        , a.CustomerPhone, a.AreaAmount, a.ActAmount, a.CategoryID, a.TotalCost, a.PaidOn, a.LeftOn
        , a.Approval1, a.KailasPaid1, a.KailasDue, a.PaidDue, a.Approval2, a.KailasPaid2
        , a.SalaryCalculated, a.SalaryPaidDate, a.CalculatedMain, a.PaidMainDate
        , a.ActDate, a.ActNum, a.[Description]
		, a.OfficeID, a.IsClosed, a.IgnoreTherms
        , e.LastName + ' ' + e.FirstName + ' ' + e.MiddleName EmployeeName
        , t.UnitName
        , c.CategoryName
    from dbo.Act a
    join dbo.Employee e on e.EmployeeID=a.EmployeeID
  	join dbo.Office o on o.OfficeID=e.OfficeID
    join dbo.TerritorialUnit t on t.TerritorialUnitID=a.TerritorialUnitID
    join dbo.Category c on c.CategoryID=a.CategoryID
GO

SET ARITHABORT ON
GO
SET CONCAT_NULL_YIELDS_NULL ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET ANSI_PADDING ON
GO
SET ANSI_WARNINGS ON
GO
SET NUMERIC_ROUNDABORT OFF
GO
CREATE UNIQUE CLUSTERED INDEX v_Acts_uq ON dbo.v_Acts
  (ActID)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO