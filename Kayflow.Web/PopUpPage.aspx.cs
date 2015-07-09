using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class PopUpPage : BasePage
{
    protected int PopupWidth
    {
        get { return GetRequestParam<int>("wdth", 100); }
    }

    protected int PopupHeight
    {
        get { return GetRequestParam<int>("hght", 100) + 40; }
    }

    protected int ViewportHeight
    {
        get { return GetRequestParam<int>("viewporthght", 100); }
    }

    protected int ViewportWidth
    {
        get { return GetRequestParam<int>("viewportwdth", 100); }
    }

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
        popupControl.Height = Unit.Pixel(PopupHeight > ViewportHeight ? ViewportHeight : PopupHeight);
        popupControl.Width = Unit.Pixel(PopupWidth > ViewportWidth ? ViewportWidth : PopupWidth);
        popupControl.AllowDragging = !Context.Request.Browser.IsMobileDevice;
    }

    protected void loadingPanelDialog_OnCustomJSProperties(object sender, CustomJSPropertiesEventArgs e)
    {
        e.Properties.Add("cpCurrentView", CurrentView);
    }
}