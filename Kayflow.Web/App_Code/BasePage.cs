using System.Collections.Generic;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using System;
using Kayflow.Manager;
using Kayflow.Model;
using WebSiteFramework;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class BasePage : PageBase
{
    #region -= Security =-
    protected override bool FormAuthenticate()
    {
        return CurrentEmployee != null;
    }

    protected override void DoAuthenticate()
    {
        if (!FormAuthenticate())
            RedirectToLoginPage();
    }

    public void RedirectToLoginPage()
    {
        if (Page.IsCallback)
            Response.RedirectLocation = GetRedirectToLoginLink();
        else
            Response.Redirect(GetRedirectToLoginLink());
        Response.End();
    }

    protected virtual string GetRedirectToLoginLink()
    {
        return "Login.aspx?ReturnUrl="
                + Server.UrlEncode(
                Request.Path
                + (!Request.QueryString.HasKeys() ? string.Empty : ("?" + Request.QueryString)));
    } 
    #endregion

    #region -= Account Info =-
    public Employee CurrentEmployee
    {
        get { return Session["CurrentEmployee"] as Employee; }
        set { Session["CurrentEmployee"] = value; }
    }

    public Office CurrentOffice
    {
        get { return Session["CurrentOffice"] as Office; }
        set { Session["CurrentOffice"] = value; }
    } 
    #endregion

    #region -= Factory =-
    public T CreateController<T>()
        where T : Framework.SqlDataAccess.Controller.DALCBase
    {
        return CreateController<T>(null, null);
    }

    public T CreateController<T>(AbstractModel model)
        where T : Framework.SqlDataAccess.Controller.DALCBase
    {
        return CreateController<T>(model, null);
    }

    public virtual T CreateController<T>(AbstractModel model, Framework.SqlDataAccess.Controller.DALCBase parent)
        where T : Framework.SqlDataAccess.Controller.DALCBase
    {
        var result = Factory.Controller<T>(parent);
        if (result is Framework.SqlDataAccess.Controller.ICompany)
        {
            (result as Framework.SqlDataAccess.Controller.ICompany).UpdateDate = DateTime.Now;
        }
        return result;
    }

    public M CreateManager<M>()
        where M : IManager
    {
        var result = Factory.Manager<M>();
        if (result.DALCInfo is Framework.SqlDataAccess.Controller.ICompany)
        {
            (result.DALCInfo as Framework.SqlDataAccess.Controller.ICompany).UpdateDate = DateTime.Now;
        }
        var visitor = result as IOfficeData;
        if (visitor != null && CurrentEmployee != null)
        {
            visitor.EmployeeID = CurrentEmployee.ID;
            if (CurrentOffice != null)
                visitor.OfficeID = CurrentOffice.OfficeID;
        }
        return result;
    }

    #endregion

    #region -= Page Info Stuff =-
    public virtual string PageName
    {
        get { return string.Empty; }
    }

    public virtual List<PageLink> MenuItems { get; protected set; }

    public abstract List<Crumb> Breadcrumbs { get; }
    #endregion

    protected override void InitPathToControls(List<string> pathList)
    {
        base.InitPathToControls(pathList);
        pathList.Add("~/Controls/AdminControls");
        pathList.Add("~/Controls/Expense");
        pathList.Add("~/Controls/Acts");
    }

    #region -= Get Values =-
    protected T GetRequestParam<T>(string paramName)
    {
        string v = Request[paramName];
        return GetValueEx<T>(string.IsNullOrEmpty(v) || v == "null" ? null : v);
    }

    private T GetValueEx<T>(object source)
    {
        Type utype = Nullable.GetUnderlyingType(typeof(T));
        Type etype = (utype ?? typeof(T)).BaseType != typeof(Enum) ? null : Enum.GetUnderlyingType(utype ?? typeof(T));
        if (etype != null)
            return (T)Enum.ToObject(utype ?? typeof(T), source);
        return (T)Convert.ChangeType(source, utype ?? typeof(T));
    }
    #endregion

}