using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kayflow.Acts
{
    public partial class frmStateHistoryEdit : Kayflow.BaseEditForm
    {
        public Guid ActID { get; set; }

        public frmStateHistoryEdit()
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
            txtDescription.TextChanged += Update_Actions;
            ddlState.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtDescription.Text)
                   && (ddlState.EditValue != null);
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlState.Properties.DataSource = CreateManager<StateManager>().GetByOffice(CurrentInfo.OfficeID);
            var model = Factory.Controller<StateHistoryController>().Get(DocID);
            if (model != null)
            {
                txtDescription.Text = model.Description;
                txtOnDate.EditValue = model.OnDate;
                ddlState.EditValue = model.StateID;
            }
            else
            {
                txtOnDate.EditValue = DateTime.Now;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = CreateManager<StateHistoryManager>();
            var model = manager.InitializeModel(DocID);
            model.ActID = ActID;
            model.EmployeeID = CurrentInfo.EmployeeID;
            model.StateID = GetValue<Guid>(ddlState);
            model.StateName = ddlState.Text;
            model.OnDate = GetValue<DateTime>(txtOnDate);
            model.Description = txtDescription.Text;
            return manager.Save();
        }
    }
}
