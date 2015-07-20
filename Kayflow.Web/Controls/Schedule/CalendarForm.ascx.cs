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
using Kayflow.Controller;
using Kayflow.Manager;

public partial class Controls_Schedule_CalendarForm : BaseControl
{
    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        var model = CreateController<EmployeeController>().Get(DocID);
        if (model==null)
            return;

        ShowTitle(model.Name);

        schSchedule.Start = StartOfMonth(DateTime.Today);
        schSchedule.DataBind();
    }

    protected void schSchedule_OnDataBinding(object sender, EventArgs e)
    {
        schSchedule.AppointmentDataSource = CreateManager<schEventManager>().GetForEmployee(DocID, CurrentOffice.OfficeID);
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
    
    private static DateTime StartOfMonth(DateTime dt)
    {
        return dt.AddDays(-1 * dt.Day).Date;
    }

}