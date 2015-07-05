using System.Linq;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_DocumentGroupEdit : BaseEditControl<DocumentGroupManager, DocumentGroupController, DocumentGroup>
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

    protected override void LoadModelDataFromControls(DocumentGroup model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.OfficeID;
        model.GroupName = GetValue<string>(txtName);
        model.Show = chShow.Checked;
        model.OrdNum = GetValue<int>(txtOrdNum);
    }

    protected override void InitControlsByModelData(DocumentGroup model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            chShow.Checked = true;
            var list = CreateManager<DocumentGroupManager>().GetForDictionary(CurrentOffice.OfficeID);
            if (list.Count == 0)
                txtOrdNum.Value = 1;
            else
                txtOrdNum.Value = list.Max(g => g.OrdNum) + 1;
        }
    }
}