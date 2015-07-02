using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public interface IEditScriptabe
{
    string CancelScript { set; }
    string OKScript { set; }
}

/// <summary>
/// Summary description for BaseEditControl
/// </summary>
public abstract class BaseEditControl<T, C, M> : BaseControl, IEditScriptabe
    where M : BaseModel, new()
    where C : KayflowController<M>, new()
    where T : KayflowManager<C, M>, new()
{
    #region Properties

    protected abstract ASPxCallback GetCallbackControl();

    protected abstract ASPxButton GetCancelButton();

    protected abstract ASPxButton GetOkButton();

    protected virtual ASPxFormLayout Layout { get; set; }

    protected virtual M CurrentModel { get; set; }

    protected virtual string ValidationGroupName { get { return "vgSave"; } }

    protected virtual string BackUrl { get; set; }

    #endregion

    #region -= Initialize =-
    protected override void DoInitialize_1_BeforeLoadData()
    {
        base.DoInitialize_1_BeforeLoadData();
        if (GetCallbackControl() != null)
            GetCallbackControl().Callback += cbSave_Callback;
    }

    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        CurrentModel = CreateManager<T>().InitializeModel(DocID);
        InitControlsByModelData(CurrentModel);
    }

    protected override void DoInitialize_4_LoadDataFinal()
    {
        base.DoInitialize_4_LoadDataFinal();

        #region -= OK button =-

        if (GetOkButton() != null && GetCallbackControl() != null)
        {
            if (string.IsNullOrEmpty(ValidationGroupName))
            {
                GetOkButton().ClientSideEvents.Click = jsFunctionOverlayFormat(
                    "gfGetElement('{0}').PerformCallback();",
                    GetCallbackControl().ClientID);
            }
            else
            {
                GetOkButton().ClientSideEvents.Click = jsFunctionOverlayFormat(
                    "if (ASPxClientEdit.ValidateGroup('{1}', true)) {{ gfGetElement('{0}').PerformCallback(); }}",
                    GetCallbackControl().ClientID, ValidationGroupName);
            }
        }

        if (!IsDialog && !string.IsNullOrEmpty(BackUrl))
        {
            var script = string.Format("window.location = '{0}';", BackUrl);
            CancelScript = script;
            OKScript = script;
        }

        #endregion
    }
    #endregion

    #region -= Save =-
    protected virtual void cbSave_Callback(object source, CallbackEventArgs e)
    {
        object result = DoSave(DocID);
        e.Result = (result ?? "").ToString();
    }

    protected virtual object DoSave(object data)
    {
        object result = null;
        ExceptionCheck(delegate
        {
            var model = Save(data);
            if (model != null)
                result = model.ID;
        });
        return result;
    }

    public M Save(object data)
    {
        var manager = CreateManager<T>();
        M model = manager.InitializeModel(DocID);
        LoadModelDataFromControls(model);
        var result = SaveAction(manager);
        return result ?? manager.Model;
    }

    public virtual M SaveAction(T manager)
    {
        return manager.Save();
    }
    #endregion

    #region -= Scriptable =-
    public string CancelScript
    {
        set
        {
            if (GetCancelButton() != null)
                GetCancelButton().ClientSideEvents.Click = jsFunctionOverlay(value);
        }
    }

    public string OKScript
    {
        set
        {
            string script = value;
            if (GetCallbackControl() != null)
            {
                GetCallbackControl().ClientSideEvents.CallbackComplete = "function(s,e){var dialogResult = e.result;" + script + " }";
                if (string.IsNullOrEmpty(GetCallbackControl().ClientSideEvents.BeginCallback))
                    GetCallbackControl().ClientSideEvents.BeginCallback = "function(s,e){DialogLoadingPanel.Show(); }";
                if (string.IsNullOrEmpty(GetCallbackControl().ClientSideEvents.EndCallback))
                    GetCallbackControl().ClientSideEvents.EndCallback = "function(s,e){DialogLoadingPanel.Hide(); }";
                else
                {
                    string fnc = GetCallbackControl().ClientSideEvents.EndCallback;
                    fnc = fnc.Substring(fnc.IndexOf('{') + 1, fnc.Length - fnc.IndexOf('{') + fnc.Length - fnc.LastIndexOf('}') - 3);
                    string fnc1 = "function(s,e){DialogLoadingPanel.Hide();" + fnc.Trim() + " }";
                    GetCallbackControl().ClientSideEvents.EndCallback = fnc1;
                }
            }
        }
    }
    #endregion

    protected virtual void InitControlsByModelData(M model)
    {
        if (Layout != null && model != null && !model.IsNew)
        {
            Layout.DataSource = model;
            Layout.DataBind();
        }
    }

    protected abstract void LoadModelDataFromControls(M model);

}