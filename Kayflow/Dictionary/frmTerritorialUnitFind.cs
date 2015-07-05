using System;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmTerritorialUnitFind : BaseEditForm
    {
        public frmTerritorialUnitFind()
        {
            InitializeComponent();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            treeUnits.FocusedNodeChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && (GetFocusedModel() != null
                       && GetFocusedModel().UnitType == eUnitType.Locality);
        }

        protected override void LoadData()
        {
            treeUnits.DataSource = Factory.Manager<TerritorialUnitManager>().GetByOffice(CurrentInfo.OfficeID);
        }

        private TerritorialUnit GetFocusedModel()
        {
            return ((treeUnits.GetDataRecordByNode(treeUnits.FocusedNode)) as TerritorialUnit);
        }

        protected override BaseModel DoSave()
        {
            return GetFocusedModel();
        }

        private void treeUnits_DoubleClick(object sender, EventArgs e)
        {
            if (IsAllowSave())
                btnSave_Click(sender, e);
        }
    }
}
