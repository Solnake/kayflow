using System;
using System.Linq;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmTerritorialUnitEdit : BaseEditForm
    {
        public frmTerritorialUnitEdit()
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
            ddlUnitType.TextChanged += Update_Actions;
            txtUnitName.TextChanged += Update_Actions;
            ddlParentType.TextChanged += Update_Actions;
            ddlParentUnit.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtUnitName.Text)
                   && (GetValue<eUnitType>(ddlUnitType) == eUnitType.Region
                       || ddlParentUnit.EditValue != null);
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlUnitType.Properties.DataSource = GetListEditItemCollection<eUnitType>();
            var model = Factory.Controller<TerritorialUnitController>().Get(DocID);
            if (model != null)
            {
                txtUnitName.Text = model.UnitName;
                ddlUnitType.EditValue = (int)model.UnitType;
                if (model.ParentUnitType.HasValue)
                    ddlParentType.EditValue = (int) model.ParentUnitType.Value;
                ddlParentUnit.EditValue = model.ParentID;
            }
        }

        private void ddlUnitType_EditValueChanged(object sender, EventArgs e)
        {
            var list = GetListEditItemCollection<eUnitType>().FindAll(
                u => (int) u.Value < GetValue<int>(ddlUnitType));
            ddlParentType.Properties.DataSource = list;
            ddlParentType.EditValue = list.Count == 1 ? list.First().Value : null;
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<TerritorialUnitManager>();
            var model = manager.InitializeModel(DocID);
            model.UnitName = txtUnitName.Text;
            model.UnitType = GetValue<eUnitType>(ddlUnitType);
            model.ParentID = GetValue<Guid?>(ddlParentUnit);
            model.OfficeID = CurrentInfo.OfficeID;
            return manager.Save();
        }

        private void ddlParentType_EditValueChanged(object sender, EventArgs e)
        {
            var parentUnit = GetValue<eUnitType?>(ddlParentType);
            if (parentUnit.HasValue)
            {
                ddlParentUnit.Properties.DataSource = Factory.Manager<TerritorialUnitManager>().GetByType(
                    CurrentInfo.OfficeID,
                    parentUnit.Value);
                ddlParentUnit.EditValue = null;
            }
            else
            {
                ddlParentUnit.Properties.DataSource = null;
            }
        }
    }
}
