--------------- SQL ---------------

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW dbo.vEmployee
WITH SCHEMABINDING
AS
  select e.EmployeeID, e.OfficeID, e.FirstName, e.LastName, e.MiddleName, e.Login, e.Password, e.Permission
  	, o.OfficeName
  	, e.LastName + ' ' + e.FirstName + ' ' + e.MiddleName DisplayName
  from dbo.Employee e
  join dbo.Office o on o.OfficeID=e.OfficeID
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
CREATE UNIQUE CLUSTERED INDEX vEmployee_uq ON dbo.vEmployee
  (EmployeeID)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW dbo.v_Acts
WITH SCHEMABINDING
AS
	select a.ActID, a.EmployeeID, a.MeteringDate, a.TerritorialUnitID, a.[Address], a.CustomerName
        , a.CustomerPhone, a.AreaAmount, a.ActAmount, a.CategoryID, a.TotalCost, a.PaidOn, a.LeftOn
        , a.Approval1, a.KailasPaid1, a.KailasDue, a.PaidDue, a.Approval2, a.KailasPaid2, a.SalaryCalculated
        , a.SalaryPaidDate, a.CalculatedMain, a.PaidMainDate, a.ActDate, a.ActNum, a.[Description]
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

DROP FUNCTION dbo.f_Acts
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW dbo.vExpiredSteps
AS
with steps as
(
select a.ActID, a.OfficeID
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
          , a.OfficeID
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
            , tmp.OfficeID
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
                  , a.OfficeID     
              from Step s
              join ActAction aa on aa.ActActionID=s.ActActionID
              join Act a on a.ActID=s.ActID
              where
                  s.Received is null
                  and isnull(aa.RelativeAlertDays, 0) != 0  
           ) as tmp
    ) as a
)
select s.ActID, s.ActionName, s.OrdNum, s.ActActionID, s.AlertColor, s.DaysForAlert, s.OfficeID
from steps s
where
    s.RankID = 1
    and s.DaysForAlert>0
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.Acts_GetAll
	@OfficeID uniqueidentifier,
    @IsClosed bit = null,
    @EmployeeID uniqueidentifier = null,
    @ActID uniqueidentifier = null
AS
BEGIN
    IF OBJECT_ID('tempdb..#ExpireSteps') IS NOT NULL DROP TABLE #ExpireSteps
    create table #ExpireSteps(
            ActID uniqueidentifier,
            ActionName varchar(128),
            DaysForAlert int,
            AlertColor int
        )
    create unique clustered index IX_ExpireSteps on #ExpireSteps(ActID)

    IF OBJECT_ID('tempdb..#lastState') IS NOT NULL DROP TABLE #lastState    
    create table #lastState(
            ActID uniqueidentifier,
            StateID uniqueidentifier,
            StateName varchar(128)
        );
    create unique clustered index IX_lastState on #lastState(ActID);    
    
    with history
    as
    (      
    select ROW_NUMBER() over(PARTITION by h.ActID order by h.OnDate) history_index
        , h.ActID, h.StateID, s.StateName
    from dbo.StateHistory h with (nolock)
    join dbo.[State] s on s.StateID=h.StateID
    join Act a on a.ActID=h.ActID
    where
    	a.OfficeID=@OfficeID
        and (@IsClosed is null or a.IsClosed=@IsClosed)
        and (@EmployeeID is null or a.EmployeeID=@EmployeeID)
        and (@ActID is null or a.ActID=@ActID)
    )
    insert into #lastState
    select h.ActID, h.StateID, h.StateName
    from history h
    where
        h.history_index=1

    insert into #ExpireSteps
    select ActID, ActionName, DaysForAlert, AlertColor 
    from vExpiredSteps e
    where
    	e.OfficeID=@OfficeID
        and (@ActID is null or e.ActID=@ActID)
    
    select a.*
        , s.ActID, s.StateID, s.StateName
        , es.ActionName, es.DaysForAlert, es.AlertColor
    from v_Acts a
    left join #ExpireSteps es on es.ActID=a.ActID
    left join #lastState s on s.ActID = a.ActID
    where 
    	a.OfficeID=@OfficeID
        and (@IsClosed is null or a.IsClosed=@IsClosed)
        and (@EmployeeID is null or a.EmployeeID=@EmployeeID) 
        and (@ActID is null or a.ActID=@ActID)
END

