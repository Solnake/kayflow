using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmStateEdit : BaseEditForm
    {
        public frmStateEdit()
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
            txtStateName.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtStateName.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<StateController>().Get(DocID);
            if (model != null)
            {
                txtStateName.Text = model.StateName;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<StateManager>();
            var model = manager.InitializeModel(DocID);
            model.StateName = txtStateName.Text;
            model.OfficeID = CurrentInfo.OfficeID;
            return manager.Save();
        }
    }
}
