using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_SetPassword : BaseEditControl<EmployeeManager, EmployeeController, Employee>
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

    protected override void DoInitialize(object data, bool loadData)
    {
        Storage.StorageID = GetRequestParam<string>("StorageID");
        base.DoInitialize(data, loadData);
    }

    protected override object DoSave(object data)
    {
        Storage["Password"] = GetValue<string>(txtPassword);
        return null;
    }

    protected override void LoadModelDataFromControls(Employee model)
    {
        throw new NotImplementedException();
    }
}