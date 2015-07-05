using System;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Staff
{
    public partial class frmEmployeeEdit : BaseEditForm
    {
        public frmEmployeeEdit()
        {
            InitializeComponent();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            base.BaseEditForm_Shown(sender, e);
            new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            txtLastName.TextChanged += Update_Actions;
            txtFirstName.TextChanged += Update_Actions;
            txtMiddleName.TextChanged += Update_Actions;
            txtLogin.TextChanged += Update_Actions;
            txtPassword.TextChanged += Update_Actions;
            ddlOffice.TextChanged += Update_Actions;
            chPermission.EditValueChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtLastName.Text)
                   && !string.IsNullOrEmpty(txtFirstName.Text)
                   && !string.IsNullOrEmpty(txtMiddleName.Text)
                   && !string.IsNullOrEmpty(txtLogin.Text)
                   && !string.IsNullOrEmpty(txtPassword.Text)
                   && ddlOffice.EditValue != null;
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlOffice.Properties.DataSource = Factory.Manager<OfficeManager>().GetAll("OfficeName");
            var model = Factory.Controller<EmployeeController>().Get(DocID);
            if (model != null)
            {
                ddlOffice.EditValue = model.OfficeID;
                txtLastName.Text = model.LastName;
                txtFirstName.Text = model.FirstName;
                txtMiddleName.Text = model.MiddleName;
                txtLogin.Text = model.Login;
                txtPassword.Text = model.Password;
                chPermission.Checked = model.IsAdmin;
            }
            else
            {
                ddlOffice.EditValue = CurrentInfo.OfficeID;
                chPermission.Checked = CurrentInfo.EmployeeID == Guid.Empty;
                chPermission.Enabled = CurrentInfo.EmployeeID != Guid.Empty;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<EmployeeManager>();
            var model = manager.InitializeModel(DocID);
            model.OfficeID = GetValue<Guid>(ddlOffice);
            model.LastName = GetValue<string>(txtLastName);
            model.FirstName = GetValue<string>(txtFirstName);
            model.MiddleName = GetValue<string>(txtMiddleName);
            model.Login = GetValue<string>(txtLogin);
            model.Password = GetValue<string>(txtPassword);
            model.IsAdmin = chPermission.Checked;
            return manager.Save();
        }
    }
}
