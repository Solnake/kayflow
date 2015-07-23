using System;
using System.Text;
using System.Web.UI;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;

public partial class Controls_Content_UserControl : BaseControl
{
    protected override void DoInitialize(object data, bool loadData)
    {
        hlUserName.NavigateUrl = SitePath + "Login.aspx";
        if (CurrentEmployee != null)
        {
            hlUserName.Text = CurrentEmployee.Name;
            hlUserName.NavigateUrl += "?IsLogOut=true";
            if (loadData)
            {
                var offices = CreateManager<EmployeeOfficesManager>().GetByEmployeeID(CurrentEmployee.ID);
                panOffices.Visible = offices.Count > 1;
                if (offices.Count>1)
                {
                    lblOffice.Attributes.Add("data-dropdown", "#panOffices");
                    var items = new StringBuilder();
                    foreach (var office in offices)
                    {
                        items.Append(getOfficeElement(office.OfficeID, office.OfficeName));
                    }

                    panOffices.Controls.Add(new LiteralControl
                    {
                        Text = string.Format("<ul class='dropdown-menu'>{0}</ul>", items)
                    });
                }
            }
        }

        if (CurrentOffice != null)
        {
            lblOffice.Text = CurrentOffice.Name;
        }
    }

    private string getOfficeElement(Guid officeId, string officeName)
    {
        return string.Format("<li><a href='#' onclick=\"officeChange('{0}');\">{1}</a></li>", officeId, officeName);
    }

    protected void callbackOFficeActions_OnCallback(object source, CallbackEventArgs e)
    {
        var office = CreateController<OfficeController>().Get(Guid.Parse(e.Parameter));
        if (office != null)
        {
            CurrentOffice = office;
            CurrentOfficeSettings = null;
        }
    }
}