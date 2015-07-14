using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.XtraScheduler;
using Kayflow.Manager;

public partial class Controls_Schedule_ScheduleForm : BaseControl
{
    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        schSchedule.Start = StartOfWeek(DateTime.Today, DayOfWeek.Monday);
        schSchedule.DataBind();
    }

    protected void schSchedule_OnDataBinding(object sender, EventArgs e)
    {
        schSchedule.AppointmentDataSource = CreateManager<schEventManager>().GetByOffice(CurrentOffice.ID);
        schSchedule.ResourceDataSource = CreateManager<EmployeeManager>().GetByOffice(CurrentOffice.ID);
    }

    protected void schSchedule_OnPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
        ASPxSchedulerPopupMenu menu = e.Menu;
        menu.Items.Clear();
        menu.ClientSideEvents.ItemClick =
            String.Format("function(s, e) {{ DefaultAppointmentMenuHandler({0}, s, e.item.name); }}",
                schSchedule.ClientID);
        if (menu.Id.Equals(SchedulerMenuItemId.DefaultMenu))
        {
            menu.Items.Add(new DevExpress.Web.MenuItem("Створити", "NewEvent"));
        }
        else
        {
            if (menu.Id.Equals(SchedulerMenuItemId.AppointmentMenu))
            {
                menu.Items.Add(new DevExpress.Web.MenuItem("Редагувати", "EditOneEvent"));
                menu.Items.Add(new DevExpress.Web.MenuItem("Видалити", "DeleteOneEvent"));
            }
        }
    }

    protected void cbkAction_OnCallback(object source, CallbackEventArgs e)
    {
        var arrParams = e.Parameter.Split("|".ToCharArray());
        var id = Guid.Parse(arrParams[1]);
        switch (arrParams[0])
        {
            case "DeleteOneEvent":
                CreateManager<schEventManager>().Delete(id);
                break;
        }
    }

    bool _locked;
    protected void schSchedule_OnVisibleIntervalChanged(object sender, EventArgs e)
    {
        if (!_locked)
        {
            _locked = true;
            DayOfWeek firstDay = schSchedule.FirstDayOfWeek;
            DateTime firstDayInWeek = schSchedule.Start.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            schSchedule.Start = firstDayInWeek;
            _locked = false;
        }
    }

    protected void schSchedule_OnBeforeExecuteCallbackCommand(object sender, SchedulerCallbackCommandEventArgs e)
    {
        if (e.CommandId == SchedulerCallbackCommandId.NavigateForward)
        {
            e.Command = new CustomNavigateForwardCallbackCommand((ASPxScheduler)sender);
        }
        else if (e.CommandId == SchedulerCallbackCommandId.NavigateBackward)
        {
            e.Command = new CustomNavigateBackwardCallbackCommand((ASPxScheduler)sender);
        }
    }

    private static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = dt.DayOfWeek - startOfWeek;
        if (diff < 0)
        {
            diff += 7;
        }

        return dt.AddDays(-1 * diff).Date;
    }

    public class CustomNavigateForwardCallbackCommand : NavigateForwardCallbackCommand
    {
        public CustomNavigateForwardCallbackCommand(ASPxScheduler control)
            : base(control)
        {

        }

        protected override void ExecuteCore()
        {
            Control.Start = Control.ActiveView.GetVisibleIntervals().Start.AddDays(7);
        }
    }

    public class CustomNavigateBackwardCallbackCommand : NavigateBackwardCallbackCommand
    {
        public CustomNavigateBackwardCallbackCommand(ASPxScheduler control)
            : base(control)
        {

        }

        protected override void ExecuteCore()
        {
            Control.Start = Control.ActiveView.GetVisibleIntervals().Start.AddDays(-7);
        }
    }
}