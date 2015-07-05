using System;
using System.Linq;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_EmployeeEdit : BaseEditControl<EmployeeManager, EmployeeController, Employee>
{
    private string _Password
    {
        get { return Storage["Password"] != null ? Storage["Password"].ToString() : null; }
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
        gridList.DataBind();
    }

    protected override void InitControlsByModelData(Employee model)
    {
        base.InitControlsByModelData(model);
        gridList.Selection.SelectRowByKey(CurrentOffice.ID);
        if (!model.IsNew)
        {
            chAdmin.Enabled = chIsBlocked.Enabled = chSuperAdmin.Enabled = model.ID != CurrentEmployee.ID;
            var list = CreateManager<EmployeeOfficesManager>().GetByEmployeeID(model.ID);
            foreach (var office in list)
            {
                gridList.Selection.SelectRowByKey(office.OfficeID);
            }

            txtPassword.Visible = false;
            btnChangePassword.Visible = true;
        }

        chSuperAdmin.Enabled = CurrentEmployee.SuperAdmin & chSuperAdmin.Enabled;
        frmEditForm.FindItemOrGroupByName("groupOffices").Visible = CurrentEmployee.SuperAdmin;
    }

    protected override void LoadModelDataFromControls(Employee model)
    {
        if (model.IsNew)
        {
            model.OfficeID = CurrentOffice.OfficeID;
        }

        model.FirstName = GetValue<string>(txtFirstName);
        model.LastName = GetValue<string>(txtLastName);
        model.MiddleName = GetValue<string>(txtMiddleName);
        model.Login = GetValue<string>(txtLogin);
        if (model.IsNew)
            model.Password = GetValue<string>(txtPassword);
        else if (!string.IsNullOrEmpty(_Password))
        {
            model.Password = _Password;
        }

        model.IsAdmin = chAdmin.Checked;
        model.SuperAdmin = chSuperAdmin.Checked;
        model.IsBlocked = chIsBlocked.Checked;
    }

    public override Employee SaveAction(EmployeeManager manager)
    {
        var list =
            (from Guid value in gridList.GetSelectedFieldValues("ID") 
             select new EmployeeOffices {OfficeID = value})
                .ToList();
        return manager.SaveWithOffices(list);
    }

    protected void gridList_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridList.DataSource = CreateManager<OfficeManager>().GetAll("OfficeName");
    }

    protected void gridList_OnCommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
    {
        if ((Guid) gridList.GetRowValues(e.VisibleIndex, "OfficeID") == CurrentOffice.ID)
        {
            e.Enabled = false;
        }
    }
}