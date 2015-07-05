using System.Linq;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_ActActionEdit : BaseEditControl<ActActionManager, ActActionController, ActAction>
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

    protected override void LoadModelDataFromControls(ActAction model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.OfficeID;
        model.ActionName = GetValue<string>(txtName);
        model.Show = chShow.Checked;
        model.OrdNum = GetValue<int>(txtOrdNum);
        model.AlertDays = GetValue<int?>(txtAlertDays);
        model.RelativeAlertDays = GetValue<int?>(txtRelativeAlertDays);
        if (!txtAlertColor.Color.IsEmpty)
        {
            model.AlertColor = txtAlertColor.Color.ToArgb();
        }
        else
        {
            model.AlertColor = null;
        }
    }

    protected override void InitControlsByModelData(ActAction model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            chShow.Checked = true;
            var list = CreateManager<ActActionManager>().GetForDictionary(CurrentOffice.OfficeID);
            if (list.Count == 0)
                txtOrdNum.Value = 1;
            else
                txtOrdNum.Value = list.Max(g => g.OrdNum) + 1;
        }
    }
}