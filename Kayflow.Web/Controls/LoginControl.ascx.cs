using System;
using System.Web.Security;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;

public partial class Controls_LoginControl : BaseControl
{
    protected override void DoInitialize(object data, bool loadData)
    {
        base.DoInitialize(data, loadData);
        if (GetRequestParam("IsLogOut", false))
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect(SitePath + "Login.aspx");
        }
    }

    protected void clbkSave_OnCallback(object source, CallbackEventArgs e)
    {
        var model = CreateManager<EmployeeManager>()
            .CheckLogin(GetValue<string>(txtLogin), GetValue<string>(txtPassword), Guid.Empty);
        if (model == null)
        {
            throw new CustomException("Користувача з такими даними не існує");
        }

        if (model.IsBlocked)
            throw new CustomException("Користувача заблокований. Зверніться до адміністратора системи.");

        FormsAuthentication.SignOut();
        Session.Clear();
        FormsAuthentication.SetAuthCookie(model.ID.ToString(), false);
        CurrentEmployee = model;
        CurrentOffice = CreateController<OfficeController>().Get(model.OfficeID);
        string redirectUrl = Request.Params["ReturnUrl"];
        if (string.IsNullOrEmpty(redirectUrl))
        {
            redirectUrl = SitePath + "Default.aspx";
        }

        ASPxWebControl.RedirectOnCallback(redirectUrl);
    }


}