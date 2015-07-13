<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScheduleForm.ascx.cs" Inherits="Controls_Schedule_ScheduleForm" %>
<dx:ASPxScheduler ID="schSchedule" runat="server" Width="100%" ActiveViewType="Timeline" GroupType="Resource"
    OnDataBinding="schSchedule_OnDataBinding"
    OnPopupMenuShowing="schSchedule_OnPopupMenuShowing">
    <Views>
        <WeekView Enabled="false"></WeekView>
        <FullWeekView Enabled="False"></FullWeekView>
        <DayView Enabled="False"></DayView>
        <WorkWeekView Enabled="False"></WorkWeekView>
        <MonthView Enabled="False"></MonthView>
        <TimelineView IntervalCount="7"></TimelineView>
    </Views>
    <Storage EnableReminders="False">
        <Resources>
            <Mappings ResourceId="EmployeeID" Caption="DisplayName"/>
        </Resources>
    </Storage>
    <OptionsCustomization AllowDisplayAppointmentForm="Never" AllowInplaceEditor="None"
        AllowAppointmentDrag="None" />
    <OptionsBehavior ShowViewNavigatorGotoDateButton="False" />
    <OptionsForms AppointmentFormVisibility="None" GotoDateFormVisibility="None" RecurrentAppointmentDeleteFormVisibility="None"
        RecurrentAppointmentEditFormVisibility="None" />
    <ResourceNavigator Visibility="Never" />
</dx:ASPxScheduler>
<script type="text/javascript">
    function CurrentAppID(sched) {
        return sched.appointmentSelection.selectedAppointmentIds[0];
    }

    function CurrentEID(sched, appId) {
        if (!appId)
            appId = sched.appointmentSelection.selectedAppointmentIds[0];
        var event = sched.appointments[appId];
        if (event.EID)
            return event.EID;
        var ps = appId.indexOf('_');
        if (ps === -1)
            return appId;
        return appId.substring(0, ps);
    }

    function DefaultAppointmentMenuHandler(scheduler, s, eventName) {
        var appId = CurrentAppID(scheduler);
        switch (eventName) {
        case "NewEvent":
            var sInt = scheduler.selection.interval;
            var iDate = sInt.GetStart().toDateString();
            DialogForm_ShowFrame('Створити планування', "schEventEdit", "data=" + iDate + "&EmployeeID=" + scheduler.GetSelectedResource(), "OnComplete");
            break;
        case "EditOneEvent":
            DialogForm_ShowFrame('Редагувати планування', "schEventEdit", "ID=" + CurrentEID(scheduler, appId), "OnComplete");
            break;
        case "DeleteOneEvent":
            if (confirm("Ви дійсно бажаєте видалити?")) {
                //cbkAction.PerformCallback("DeleteOneEvent|" + appId);
            }
            break;
        default:
            break;
        }
    }

    function OnComplete(result) {

    }
</script>
