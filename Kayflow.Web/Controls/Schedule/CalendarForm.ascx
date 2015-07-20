<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarForm.ascx.cs" Inherits="Controls_Schedule_CalendarForm" %>
<dx:ASPxScheduler ID="schSchedule" runat="server" Width="100%" ActiveViewType="Month"
    OnDataBinding="schSchedule_OnDataBinding"
    OnPopupMenuShowing="schSchedule_OnPopupMenuShowing">
    <Views>
        <WeekView Enabled="false"></WeekView>
        <FullWeekView Enabled="False"></FullWeekView>
        <DayView Enabled="False"></DayView>
        <WorkWeekView Enabled="False"></WorkWeekView>
        <MonthView Enabled="True"></MonthView>
        <TimelineView Enabled="False"></TimelineView>
    </Views>
    <Storage EnableReminders="False">
        <Appointments>
            <Mappings Subject="Subject" AllDay="AllDay" AppointmentId="ID" Start="StartDate" End="EndDate"></Mappings>
        </Appointments>
    </Storage>
    <OptionsCustomization AllowDisplayAppointmentForm="Never" AllowInplaceEditor="None"
        AllowAppointmentDrag="None" />
    <OptionsBehavior ShowViewNavigatorGotoDateButton="true" />
    <OptionsForms AppointmentFormVisibility="None" GotoDateFormVisibility="None" RecurrentAppointmentDeleteFormVisibility="None"
        RecurrentAppointmentEditFormVisibility="None" />
    <ResourceNavigator Visibility="Never" />
</dx:ASPxScheduler>
<dx:ASPxCallback ID="cbkAction" runat="server" ClientInstanceName="cbkAction" OnCallback="cbkAction_OnCallback">
    <ClientSideEvents CallbackComplete="function(s,e){ OnComplete(); }" />
</dx:ASPxCallback>
<script type="text/javascript">
    function CurrentAppID(sched) {
        return sched.appointmentSelection.selectedAppointmentIds[0];
    }

    function DefaultAppointmentMenuHandler(scheduler, s, eventName) {
        var appId = CurrentAppID(scheduler);
        switch (eventName) {
        case "NewEvent":
            var sInt = scheduler.selection.interval;
            var iDate = sInt.GetStart().toDateString();
            DialogForm_ShowFrame('Створити планування', "schEventEdit", "data=" + iDate + "&EmployeeID=" + '<%= DocID %>', "OnComplete");
            break;
        case "EditOneEvent":
            DialogForm_ShowFrame('Редагувати планування', "schEventEdit", "ID=" + appId, "OnComplete");
            break;
        case "DeleteOneEvent":
            if (confirm("Ви дійсно бажаєте видалити?")) {
                cbkAction.PerformCallback("DeleteOneEvent|" + appId);
            }
            break;
        default:
            break;
        }
    }

    function OnComplete(result) {
        gfGetElement('<%= schSchedule.ClientID %>').Refresh();
    }
</script>