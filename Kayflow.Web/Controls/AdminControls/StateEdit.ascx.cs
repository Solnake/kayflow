using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_StateEdit : BaseEditControl<Kayflow.Manager.StateManager, StateController, State>
{
    protected override ASPxCallback GetCallbackControl()
    {
        return clbkSave;
    }

    protected override ASPxButton GetCancelButton()
    {
        return btnCancel;
    }

    protected override ASPxButton GetOkButton()
    {
        return btnOk;
    }

    protected override ASPxFormLayout Layout
    {
        get { return frmEditForm; }
    }

    protected override void LoadModelDataFromControls(State model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.OfficeID;
        model.StateName = GetValue<string>(txtName);
    }
}