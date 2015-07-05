using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmActActionEdit : BaseEditForm
    {
        public frmActActionEdit()
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
            txtActionName.TextChanged += Update_Actions;
            txtOrdNum.TextChanged += Update_Actions;
            chShow.CheckedChanged += Update_Actions;
            txtAlertDays.TextChanged += Update_Actions;
            txtRelativeAlertDays.TextChanged += Update_Actions;
            ddlAlertColor.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtActionName.Text)
                   && !string.IsNullOrEmpty(txtAlertDays.Text)
                   && !string.IsNullOrEmpty(txtRelativeAlertDays.Text)
                   && ddlAlertColor.EditValue != null
                   && !string.IsNullOrEmpty(txtOrdNum.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var manager = Factory.Manager<ActActionManager>();
            var model = manager.Controller.Get(DocID);
            if (model != null)
            {
                txtActionName.Text = model.ActionName;
                txtOrdNum.Value = model.OrdNum;
                chShow.Checked = model.Show;
                txtAlertDays.EditValue = model.AlertDays;
                txtRelativeAlertDays.EditValue = model.RelativeAlertDays;
                ddlAlertColor.EditValue = model.AlertColor;
            }
            else
            {
                chShow.Checked = true;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<ActActionManager>();
            var model = manager.InitializeModel(DocID);
            model.OfficeID = CurrentInfo.OfficeID;
            model.ActionName = txtActionName.Text;
            model.OrdNum = GetValue<int>(txtOrdNum);
            model.Show = chShow.Checked;
            model.AlertDays = GetValue<int>(txtAlertDays);
            model.RelativeAlertDays = GetValue<int>(txtRelativeAlertDays);
            if (ddlAlertColor.Color.IsEmpty)
                model.AlertColor = null;
            else
                model.AlertColor = GetValue<int>(ddlAlertColor);
            return manager.Save();
        }
    }
}
