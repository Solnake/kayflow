using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow
{
    public partial class frmLogin : BaseEditForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            txtLogin.TextChanged += Update_Actions;
            txtPassword.TextChanged += Update_Actions;
            ddlOffice.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtLogin.Text)
                   && !string.IsNullOrEmpty(txtPassword.Text)
                   && ddlOffice.EditValue != null;
        }

        protected override void LoadData()
        {
            base.LoadData();
            List<Office> offices = Factory.Manager<OfficeManager>().GetAll("OfficeName");
            ddlOffice.Properties.DataSource = offices;
            if (offices.Any())
                ddlOffice.EditValue = offices.First().ID;
        }

        protected override BaseModel DoSave()
        {
            var model = Factory.Manager<EmployeeManager>().CheckLogin(
                GetValue<string>(txtLogin),
                GetValue<string>(txtPassword),
                GetValue<Guid>(ddlOffice));
            if (model == null)
                throw new CustomException(Resources.loginCheckError);
            return model;
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            base.BaseEditForm_Shown(sender, e);
            new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
        }
    }
}
