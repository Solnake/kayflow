using System.Collections.Generic;
using System.Linq;
using DevExpress.Web;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using System;
using Framework.SqlDataAccess.Validation;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using log4net;
using WebSiteFramework;

/// <summary>
/// Summary description for BaseControl
/// </summary>
public abstract class BaseControl : CustomUserControlBase
{
    protected BasePage CurrentPage
    {
        get
        {
            var result = Page as BasePage;
            if (result == null)
                throw new NullReferenceException("Page is not BasePage");
            return result;
        }
    }

    public bool IsDialog { get; set; }

    protected new Guid DocID
    {
        get
        {
            Guid id;
            Guid.TryParse(GetRequestParam<string>("ID"), out id);
            return id;
        }
    }

    protected ILog _Logger
    {
        get { return LogManager.GetLogger(GetType()); }
    }

    public Employee CurrentEmployee
    {
        get { return CurrentPage.CurrentEmployee; }
        set { CurrentPage.CurrentEmployee = value; }
    }

    public Office CurrentOffice
    {
        get { return CurrentPage.CurrentOffice; }
        set { CurrentPage.CurrentOffice = value; }
    }

    #region -= Factory =-
    protected T CreateController<T>()
        where T : DALCBase
    {
        return CurrentPage.CreateController<T>();
    }

    protected T CreateController<T>(AbstractModel model)
        where T : DALCBase
    {
        return CurrentPage.CreateController<T>(model);
    }

    protected virtual T CreateController<T>(AbstractModel model, DALCBase parent)
        where T : DALCBase
    {
        return CurrentPage.CreateController<T>(model, parent);
    }

    protected M CreateManager<M>()
        where M : IManager
    {
        return CurrentPage.CreateManager<M>();
    }

    #endregion

    #region -= Initialize =-
    protected override void DoInitialize(object data, bool loadData)
    {
        DoInitialize_1_BeforeLoadData();
        if (loadData)
        {
            DoInitialize_2_LoadDataInitControls();
            DoInitialize_3_LoadDataMain();
            DoInitialize_4_LoadDataFinal();
        }
        DoInitialize_5_AfterLoadData();
    }

    protected virtual void DoInitialize_1_BeforeLoadData()
    {

    }

    protected virtual void DoInitialize_2_LoadDataInitControls() { }

    protected virtual void DoInitialize_3_LoadDataMain()
    {

    }

    protected virtual void DoInitialize_4_LoadDataFinal() { }

    protected virtual void DoInitialize_5_AfterLoadData() { }
    #endregion

    #region -= Overlay Methods =-

    protected string jsFunctionOverlay(string value)
    {
        return "function(s,e) { " + value + " }";
    }

    protected string jsFunctionOverlayFormat(string format, params object[] args)
    {
        return "function(s,e) { " + string.Format(format, args) + " }";
    }

    protected void ExceptionCheck(ExceptionCheckDelegate executeMethod)
    {
        try
        {
            executeMethod();
        }
        catch (RulesException ex)
        {
            throw new CustomException(ex.Errors.Take(10).Aggregate(
                string.Empty,
                (current, error) => current + ("\r\n " + error.ErrorMessage)));
        }
        catch (Exception ex)
        {
            _Logger.Error(ex.Message, ex);
            throw;
        }
    }

    #endregion

    #region -= Init Controls =-
    public enum e0Type
    {
        DontNeed = 0,
        PlsSelect,
        All
    }

    public string Get0Type(e0Type type)
    {
        string result = "";
        switch (type)
        {
            case e0Type.PlsSelect:
                result = "Оберіть, будь-ласка";
                break;
            case e0Type.All:
                result = "Всі";
                break;
        }
        return result;
    }

    public void InitCombo(ASPxComboBox ddl, object source, e0Type type)
    {
        InitCombo(ddl, source, "ID", "Name", type, ddl.ValueType != typeof (string) ? ddl.ValueType : typeof (int));
    }

    public void InitCombo(ASPxComboBox ddl, object source, string valuefield, string textfield, e0Type type, Type valueType)
    {
        if (source != null)
        {
            ddl.DataSource = source;
            ddl.TextField = textfield;
            ddl.ValueField = valuefield;
            ddl.ValueType = valueType;
            ddl.DataBind();
        }
        else
        {
            ddl.Items.Clear();
        }
        if (type != e0Type.DontNeed)
        {
            ddl.Items.Insert(0, new ListEditItem(Get0Type(type), string.Empty));
        }
    }

    public void InitCombo<M>(ASPxComboBox ddl, e0Type type)
        where M : IManagerDataSource
    {
        InitCombo(ddl, CreateManager<M>().Retrieve(), type);
    }

    public void InitCombo<M>(ASPxComboBox ddl)
        where M : IManagerDataSource
    {
        InitCombo<M>(ddl, e0Type.PlsSelect);
    }

    public void InitComboEnum<T>(ASPxComboBox ddl, e0Type type, List<T> pExcludeList = null)
        where T : struct
    {
        var items = GetListEditItemCollection(pExcludeList);
        InitCombo(ddl, items, "Value", "Text", type, typeof (int));
    }

    public List<ListEditItem> GetListEditItemCollection<T>(List<T> pExcludeList = null)
            where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("Method 'GetListEditItemCollection<T>' used for enums only!");
        if (pExcludeList == null)
            pExcludeList = new List<T>();
        Type utype = Enum.GetUnderlyingType(typeof(T));
        return (from Enum value in Enum.GetValues(typeof (T))
            let exItem = Enum.ToObject(typeof (T), value)
            where !pExcludeList.Contains((T) exItem)
            select new ListEditItem {Text = value.GetNameEx(), Value = Convert.ChangeType(value, utype)}).ToList();
    }

    public List<T> GetEnumList<T>()
        where T : struct 
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("Method 'GetListEditItemCollection<T>' used for enums only!");
        return Enum.GetValues(typeof (T)).Cast<T>().ToList();
    }

    #endregion

    #region -= Get Values =-

    #region Request Parameters

    protected T GetRequestParam<T>(string paramName)
    {
        string v = Request[paramName];
        return GetValue<T>(string.IsNullOrEmpty(v) || v == "null" ? null : v);
    }
    protected T GetRequestParam<T>(string paramName, T defaultValue)
    {
        string v = Request[paramName];
        return GetValue(string.IsNullOrEmpty(v) ? null : v, defaultValue);
    }

    #endregion

    #region ASPxEdit Values

    protected T GetValue<T>(ASPxEdit pEdit)
    {
        return GetValue<T>(pEdit == null ? null : pEdit.Value);
    }
    protected T GetValue<T>(ASPxEdit pEdit, T defaultValue)
    {
        return GetValue(pEdit == null ? null : pEdit.Value, defaultValue);
    }

    #endregion

    protected T GetValue<T>(object source)
    {
        if (typeof(T) == typeof(string))
            return GetValueEx<T>(source);
        return GetValue(source, Activator.CreateInstance<T>());
    }

    protected T GetValue<T>(object source, T defaultValue)
    {
        if (source == null)
            return defaultValue;
        return GetValueEx<T>(source);
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