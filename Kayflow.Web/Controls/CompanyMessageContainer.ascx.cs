using System;
using System.Linq;
using System.Web.UI;
using Kayflow.Manager;

public partial class Controls_CompanyMessageContainer : BaseControl
{
    private bool needShowMessage
    {
        get
        {
            if (Session["needShowMessage"] == null)
                Session["needShowMessage"] = true;

            return (bool)Session["needShowMessage"];
        }
        set { Session["needShowMessage"] = value; }
    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        if (CurrentOffice != null && needShowMessage)
        {
            var array = CreateManager<CompanyMessageManager>()
                .GetByOffice(CurrentOffice.ID)
                .Select(message => string.Format("'{0}'", message.MessageText))
                .ToList();
            if (array.Count!=0)
            {
                var script = "$(document).ready(function () { doCompanyMessages([" + string.Join(",", array.ToArray()) +
                             "]); });";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
            }

            needShowMessage = false;
        }
    }
}