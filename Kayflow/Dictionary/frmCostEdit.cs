using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmCostEdit : BaseEditForm
    {
        public frmCostEdit()
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
            txtCostName.TextChanged += Update_Actions;
            chShow.CheckedChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtCostName.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<CostController>().Get(DocID);
            if (model != null)
            {
                txtCostName.Text = model.CostName;
                chShow.Checked = model.Show;
            }
            else
            {
                chShow.Checked = true;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<CostManager>();
            var model = manager.InitializeModel(DocID);
            model.CostName = txtCostName.Text;
            model.Show = chShow.Checked;
            model.OfficeID = CurrentInfo.OfficeID;
            return manager.Save();
        }
    }
}
