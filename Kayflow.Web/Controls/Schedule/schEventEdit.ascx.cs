using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Schedule_schEventEdit : BaseEditControl<schEventManager, schEventController, schEvent>
{

    protected Guid EmployeeID
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

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo<EmployeeManager>(ddlEmployees, e0Type.PlsSelect);
    }

    protected override void InitControlsByModelData(schEvent model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            txtOnDate.Value = Convert.ToDateTime(GetRequestParam<string>("data"));
            ddlEmployees.Value = Guid.Parse(GetRequestParam<string>("EmployeeID"));
        }
    }

    protected override void LoadModelDataFromControls(schEvent model)
    {
        model.EmployeeID = GetValue<Guid>(ddlEmployees);
        model.StartDate = GetValue<DateTime>(txtOnDate);
        model.Subject = GetValue<string>(txtSubject);
    }
}