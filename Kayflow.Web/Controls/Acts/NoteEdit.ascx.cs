using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_NoteEdit : BaseEditControl<NoteManager, NoteController, Note>
{

    protected Guid ActID
    {
        get
        {
            Guid id;
            Guid.TryParse(GetRequestParam<string>("ActID"), out id);
            return id;
        }
    }

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

    protected override void InitControlsByModelData(Note model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
            txtOnDate.Value = DateTime.Now;
    }

    protected override void LoadModelDataFromControls(Note model)
    {
        if (model.IsNew)
            model.EmployeeID = CurrentEmployee.ID;
        model.ActID = ActID;
        model.OnDate = GetValue<DateTime>(txtOnDate);
        model.Description = GetValue<string>(txtDescription);
    }
}