using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_DocumentEdit : BaseEditControl<DocumentManager, DocumentController, Document>
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

    protected override void LoadModelDataFromControls(Document model)
    {
        model.DocumentGroupID = GetValue<Guid>(ddlDocumentGroup);
        model.DocumentName = GetValue<string>(txtName);
        model.Show = chShow.Checked;
        model.OrdNum = GetValue<int>(txtOrdNum);
        model.ValueSetID = GetValue<Guid>(ddlValueSet);
        model.ShowComments = chShowComments.Checked;
    }

    protected override void InitControlsByModelData(Document model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            chShow.Checked = true;
        }
    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo<DocumentGroupManager>(ddlDocumentGroup, e0Type.PlsSelect);
        InitCombo(ddlValueSet, CreateManager<ValueSetManager>().GetAll(), e0Type.PlsSelect);
    }
}