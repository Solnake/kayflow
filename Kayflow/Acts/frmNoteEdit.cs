using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Acts
{
    public partial class frmNoteEdit : BaseEditForm
    {
        public Guid ActID { get; set; }

        public frmNoteEdit()
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
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtDescription.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<NoteController>().Get(DocID);
            if (model != null)
            {
                txtDescription.Text = model.Description;
                txtOnDate.EditValue = model.OnDate;
            }
            else
            {
                txtOnDate.EditValue = DateTime.Now;
            }
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<NoteManager>();
            var model = manager.InitializeModel(DocID);
            model.ActID = ActID;
            model.EmployeeID = CurrentInfo.EmployeeID;
            model.OnDate = GetValue<DateTime>(txtOnDate);
            model.Description = txtDescription.Text;
            return manager.Save();
        }
    }
}
