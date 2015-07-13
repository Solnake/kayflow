using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using Kayflow.Manager;

public partial class Controls_Schedule_ScheduleForm : BaseControl
{
    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        schSchedule.DataBind();
    }

    protected void schSchedule_OnDataBinding(object sender, EventArgs e)
    {
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
}