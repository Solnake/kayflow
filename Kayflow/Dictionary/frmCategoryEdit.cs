using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmCategoryEdit : BaseEditForm
    {
        public frmCategoryEdit()
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
            txtCategoryName.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtCategoryName.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<CategoryController>().Get(DocID);
            if (model != null)
            {
                txtCategoryName.Text = model.CategoryName;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<CategoryManager>();
            var model = manager.InitializeModel(DocID);
            model.CategoryName = txtCategoryName.Text;
            model.OfficeID = CurrentInfo.OfficeID;
            return manager.Save();
        }
    }
}
