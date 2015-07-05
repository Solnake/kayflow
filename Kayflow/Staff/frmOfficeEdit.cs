using System;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Staff
{
    public partial class frmOfficeEdit : BaseEditForm
    {
        public frmOfficeEdit()
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
            txtOfficeName.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtOfficeName.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<OfficeController>().Get(DocID);
            if (model!=null)
            {
                txtOfficeName.Text = model.OfficeName;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<OfficeManager>();
            var model = manager.InitializeModel(DocID);
            model.OfficeName = txtOfficeName.Text;
            return manager.Save();
        }
    }
}
