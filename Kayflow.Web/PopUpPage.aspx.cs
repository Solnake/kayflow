using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopUpPage : BasePage
{
    public override List<Crumb> Breadcrumbs
    {
        get { throw new NotImplementedException(); }
    }

    protected override void OnPreLoadFormContent(EventArgs e)
    {
        base.OnPreLoadFormContent(e);
        CenterPlaceHolder = phCenter;
    }

    protected override void AttachEventHandlers(Control ctl)
    {
        base.AttachEventHandlers(ctl);
        var scriptabe = ctl as IEditScriptabe;
        if (scriptabe != null)
        {
            scriptabe.CancelScript = "DialogForm_HideFrame();";
            scriptabe.OKScript = "DialogForm_CloseFrame(dialogResult);";
        }
        var dialog = ctl as BaseControl;
        if (dialog != null)
        {
            dialog.IsDialog = true;
        }
    }


    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        popupControl.HeaderText = GetRequestParam<string>("hdrTitle");
        if (GetRequestParam<int>("wdth") != 0)
        {
            popupControl.Width = Unit.Pixel(GetRequestParam<int>("wdth"));
        }
        if (GetRequestParam<int>("hght") != 0)
        {
            popupControl.Height = Unit.Pixel(GetRequestParam<int>("hght"));
        }
    }
}