using System;
using System.Linq;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmDocumentGroupEdit : BaseEditForm
    {
        public frmDocumentGroupEdit()
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
            txtGroupName.TextChanged += Update_Actions;
            txtOrdNum.TextChanged += Update_Actions;
            chIsShow.CheckedChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtGroupName.Text)
                   && !string.IsNullOrEmpty(txtOrdNum.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var manager = Factory.Manager<DocumentGroupManager>();
            var model = manager.Controller.Get(DocID);
            if (model != null)
            {
                txtGroupName.Text = model.GroupName;
                txtOrdNum.Value = model.OrdNum;
                chIsShow.Checked = model.Show;
            }
            else
            {
                var list = manager.GetForDictionary(CurrentInfo.OfficeID);
                if (list.Count == 0)
                    txtOrdNum.Value = 1;
                else
                    txtOrdNum.Value = list.Max(g => g.OrdNum) + 1;
                chIsShow.Checked = true;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<DocumentGroupManager>();
            var model = manager.InitializeModel(DocID);
            model.GroupName = txtGroupName.Text;
            model.OrdNum = GetValue<int>(txtOrdNum);
            model.Show = chIsShow.Checked;
            model.OfficeID = CurrentInfo.OfficeID;
            return manager.Save();
        }
    }
}
