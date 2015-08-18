﻿SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Acts_GetAll]
	@OfficeID uniqueidentifier,
    @IsClosed bit = null,
    @EmployeeID uniqueidentifier = null,
    @ActID uniqueidentifier = null
AS
BEGIN
    IF OBJECT_ID('tempdb..#ExpireSteps') IS NOT NULL DROP TABLE #ExpireSteps
    create table #ExpireSteps(
            ActID uniqueidentifier,
            ActionName varchar(128) COLLATE DATABASE_DEFAULT,
            DaysForAlert int,
            AlertColor int
        )
    create unique clustered index IX_ExpireSteps on #ExpireSteps(ActID)

    IF OBJECT_ID('tempdb..#lastState') IS NOT NULL DROP TABLE #lastState
    create table #lastState(
            ActID uniqueidentifier,
            StateID uniqueidentifier,
            StateName varchar(128) COLLATE DATABASE_DEFAULT
        );
    create unique clustered index IX_lastState on #lastState(ActID);

    with history
    as
    (
    select ROW_NUMBER() over(PARTITION by h.ActID order by h.OnDate desc) history_index
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
        , s.StateID, s.StateName
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
GO