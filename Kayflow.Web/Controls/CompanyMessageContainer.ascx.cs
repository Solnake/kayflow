using System;
using System.Linq;
using System.Web.UI;

public partial class Controls_CompanyMessageContainer : BaseControl
{
    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        if (CurrentOfficeSettings != null && CurrentOfficeSettings.NeedShowMessage)
        {
            var array = CurrentOfficeSettings.Messages
                .Select(message => string.Format("'{0}'", message.MessageText))
                .ToList();
            if (array.Count!=0)
            {
                var script = "$(document).ready(function () { doCompanyMessages([" + string.Join(",", array.ToArray()) +
                             "]); });";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
            }

            CurrentOfficeSettings.NeedShowMessage = false;
        }
    }
}