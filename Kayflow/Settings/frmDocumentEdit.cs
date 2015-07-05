using System;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmDocumentEdit : BaseEditForm
    {
        public frmDocumentEdit()
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
            ddlGroup.TextChanged += Update_Actions;
            txtDocumentName.TextChanged += Update_Actions;
            txtOrdNum.TextChanged += Update_Actions;
            chShow.CheckedChanged += Update_Actions;
            ddlValueSet.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtDocumentName.Text)
                   && ddlGroup.EditValue != null
                   && ddlValueSet.EditValue != null
                   && !string.IsNullOrEmpty(txtOrdNum.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlGroup.Properties.DataSource = Factory.Manager<DocumentGroupManager>().GetByOffice(CurrentInfo.OfficeID);
            ddlValueSet.Properties.DataSource = Factory.Manager<ValueSetManager>().GetAll("SetName");
            var manager = Factory.Manager<DocumentManager>();
            var model = manager.Controller.Get(DocID);
            if (model != null)
            {
                ddlGroup.EditValue = model.DocumentGroupID;
                txtDocumentName.Text = model.DocumentName;
                txtOrdNum.Value = model.OrdNum;
                chShow.Checked = model.Show;
                ddlValueSet.EditValue = model.ValueSetID;
            }
            else
            {
                chShow.Checked = true;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<DocumentManager>();
            var model = manager.InitializeModel(DocID);
            model.DocumentGroupID = GetValue<Guid>(ddlGroup);
            model.DocumentName = txtDocumentName.Text;
            model.OrdNum = GetValue<int>(txtOrdNum);
            model.Show = chShow.Checked;
            model.ValueSetID = GetValue<Guid>(ddlValueSet);
            return manager.Save();
        }
    }
}
