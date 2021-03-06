if not exists(select * from sys.columns 
            where Name = N'OfficeID' and Object_ID = Object_ID(N'Act')) 
	ALTER TABLE [dbo].[Act]
	ADD [OfficeID] uniqueidentifier NULL
GO

IF not EXISTS (SELECT * FROM sys.objects WHERE type = 'F' AND name = 'FK_Act_OfficeID_Office_OfficeID')
BEGIN
	ALTER TABLE [dbo].[Act]
	ADD CONSTRAINT [FK_Act_OfficeID_Office_OfficeID] FOREIGN KEY ([OfficeID]) 
	REFERENCES [dbo].[Office] ([OfficeID]) 
	ON UPDATE NO ACTION
	ON DELETE NO ACTION
END
GO

update a
set
	a.OfficeID = e.OfficeID
from Act a
join Employee e on e.EmployeeID=a.EmployeeID
where
	a.OfficeID is null
GO
		
ALTER TABLE [dbo].[Act]
ALTER COLUMN [OfficeID] uniqueidentifier NOT NULL
GO


if not exists(select * from sys.columns 
            where Name = N'IsClosed' and Object_ID = Object_ID(N'Act')) 
begin
	ALTER TABLE [dbo].[Act]
	ADD [IsClosed] bit NULL
END
GO

update act 
set
	IsClosed = 0
where
	IsClosed is null
GO


ALTER TABLE [dbo].[Act]
ALTER COLUMN [IsClosed] bit NOT NULL
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW dbo.vExpiredSteps
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
          , null RelativeAlertDays
      from Step s
      join ActAction aa on aa.ActActionID=s.ActActionID
      join Act a on a.ActID=s.ActID
      where
          s.Received is null
          and isnull(aa.RelativeAlertDays, 0) = 0
      union all
      select tmp.ActID, tmp.ActionName, tmp.OrdNum, tmp.ActActionID, tmp.AlertColor, tmp.DaysLeft, tmp.AlertDays
          , case
              when tmp.DaysDiff is null then null
              else DATEDIFF(dd, tmp.DaysDiff, getdate()) - tmp.RelativeAlertDays
            end RelativeAlertDays
      from (
            select s.ActID, aa.ActionName, aa.OrdNum, aa.ActActionID, aa.AlertColor
                  , DATEDIFF(dd, a.MeteringDate, getdate()) as DaysLeft
                  , case 
                      when aa.AlertDays is not null then DATEDIFF(dd, a.MeteringDate, getdate()) - aa.AlertDays
                    else
                      NULL
                    end AlertDays  
                  , (select top 1 st.Received
                      from Step st
                      join ActAction aat on aat.ActActionID=st.ActActionID
                      where
                        ActID = s.ActID
                        and aat.OrdNum<aa.OrdNum
                      order by
                        aat.OrdNum desc) DaysDiff
                  , aa.RelativeAlertDays      
              from Step s
              join ActAction aa on aa.ActActionID=s.ActActionID
              join Act a on a.ActID=s.ActID
              where
                  s.Received is null
                  and isnull(aa.RelativeAlertDays, 0) != 0  
           ) as tmp
    ) as a
)
select s.ActID, s.ActionName, s.OrdNum, s.ActActionID, s.AlertColor, s.DaysForAlert
from steps s
where
    s.RankID = 1
    and s.DaysForAlert>0
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'TF' AND name = 'f_Acts')
BEGIN
	DROP FUNCtion [dbo].f_Acts
END
GO

CREATE FUNCTION dbo.f_Acts ()
RETURNS @Result TABLE(
    ActID UNIQUEIDENTIFIER,
    EmployeeID UNIQUEIDENTIFIER,
    MeteringDate DATETIME,
    TerritorialUnitID UNIQUEIDENTIFIER,
    [Address] NVARCHAR(256),
    CustomerName NVARCHAR(256),
    CustomerPhone NVARCHAR(36),
    AreaAmount INT,
    ActAmount INT,
    CategoryID UNIQUEIDENTIFIER,
    TotalCost FLOAT,
    PaidOn FLOAT,
    LeftOn FLOAT,
    Approval1 FLOAT,
    KailasPaid1 FLOAT,
    KailasDue FLOAT,
    PaidDue FLOAT,
    Approval2 FLOAT,
    KailasPaid2 FLOAT,
    SalaryCalculated FLOAT,
    SalaryPaidDate DATETIME,
    CalculatedMain FLOAT,
    PaidMainDate DATETIME,
    ActDate DATETIME,
    ActNum VARCHAR(10),
    [Description] NVARCHAR(256),
	[OfficeID] uniqueidentifier,
	[IsClosed] bit,
    EmployeeName NVARCHAR(386),
    [UnitName] nvarchar(128),
    [CategoryName] nvarchar(128),
    [StateID] uniqueidentifier,
    [StateName] nvarchar(128),
    AlertStep varchar(128),
    AlertDays int,
    AlertColor int
    )
AS
begin
    declare @ExpireSteps TABLE(
        ActID uniqueidentifier,
        ActionName varchar(128),
        DaysForAlert int,
        AlertColor int
    )

    insert into @ExpireSteps
    select ActID, ActionName, DaysForAlert, AlertColor from vExpiredSteps e

    insert into @Result
    select a.ActID, a.EmployeeID, a.MeteringDate, a.TerritorialUnitID, a.[Address], a.CustomerName
        , a.CustomerPhone, a.AreaAmount, a.ActAmount, a.CategoryID, a.TotalCost, a.PaidOn, a.LeftOn
        , a.Approval1, a.KailasPaid1, a.KailasDue, a.PaidDue, a.Approval2, a.KailasPaid2, a.SalaryCalculated
        , a.SalaryPaidDate, a.CalculatedMain, a.PaidMainDate, a.ActDate, a.ActNum, a.[Description]
		, a.OfficeID, a.IsClosed
        , e.DisplayName EmployeeName
        , t.UnitName
        , c.CategoryName
        , s.StateID, s.StateName
        , es.ActionName, es.DaysForAlert, es.AlertColor
    from Act a
    join vEmployee e on e.EmployeeID=a.EmployeeID
    join TerritorialUnit t on t.TerritorialUnitID=a.TerritorialUnitID
    join Category c on c.CategoryID=a.CategoryID
    left join @ExpireSteps es on es.ActID=a.ActID
    left join
        (
            select s.StateID, s.StateName, h.ActID
            from StateHistory h
            join [State] s on s.StateID=h.StateID
            where
                h.StateHistoryID = 
                  (select top 1 StateHistoryID
                   from StateHistory
                   where ActID=h.ActID
                   order by OnDate desc)
        ) s on s.ActID = a.ActID

    return    
end      
GO    