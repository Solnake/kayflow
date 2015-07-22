using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_CompanyMessageEdit : BaseEditControl<CompanyMessageManager, CompanyMessageController, CompanyMessage>
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

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo(ddlOffice, CreateManager<OfficeManager>().GetAll(), e0Type.PlsSelect);
    }

    protected override void LoadModelDataFromControls(CompanyMessage model)
    {
        model.OfficeID = GetValue<Guid>(ddlOffice);
        model.MessageText = GetValue<string>(txtMessageText);
    }
}