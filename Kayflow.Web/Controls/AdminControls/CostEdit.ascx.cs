using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_CostEdit : BaseEditControl<CostManager, CostController, Cost>
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

    protected override void LoadModelDataFromControls(Cost model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.OfficeID;
        model.CostName = GetValue<string>(txtName);
        model.Show = chShow.Checked;
    }

    protected override void InitControlsByModelData(Cost model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            chShow.Checked = true;
        }
    } 
}