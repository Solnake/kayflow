using System;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;
using Kayflow.Properties;

namespace Kayflow.Dictionary
{
    public partial class frmTerritorialUnitList : BaseListForm
    {
        public frmTerritorialUnitList()
        {
            InitializeComponent();
        }

        protected override void BaseListForm_Load(object sender, EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            DefaultPage.Text = Resources.territorialUnitList;
        }

        protected override void BindData()
        {
            treeUnits.DataSource = Factory.Manager<TerritorialUnitManager>().GetByOffice(CurrentInfo.OfficeID);
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmTerritorialUnitEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmTerritorialUnitEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(Resources.confirmDelete,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            var handle = treeUnits.FocusedNode.Id;
            try
            {
                Factory.Manager<TerritorialUnitManager>().Delete(GetFocusedValue());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                MessageBox.Show(Resources.relaterDeleteError,
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            BindData();
            if (handle > 0)
                treeUnits.SetFocusedNode(treeUnits.FindNodeByID(handle - 1));
        }

        private void treeUnits_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            btnEdit.Enabled = treeUnits.FocusedNode != null;
            btnDelete.Enabled = btnEdit.Enabled;
            menuItemEdit.Enabled = btnEdit.Enabled;
            menuItemDelete.Enabled = btnDelete.Enabled;
        }

        private void treeUnits_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_ItemClick(sender, null);
        }

        protected override void ReloadWithLocate(Guid pID)
        {
            BindData();
            treeUnits.ForceInitialize();
            treeUnits.SetFocusedNode(treeUnits.FindNodeByFieldValue("ID", pID));
        }

        protected override Guid GetFocusedValue()
        {
            var model = ((treeUnits.GetDataRecordByNode(treeUnits.FocusedNode)) as ModelBaseSinglePK<Guid>);
            return model != null ? model.ID : Guid.Empty;
        }

        private void treeUnits_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var treeList = sender as TreeList;
            if (treeList != null)
            {
                var hitInfo = treeList.CalcHitInfo(e.Point);
                if (hitInfo.Node != null)
                {
                    treeList.FocusedNode = hitInfo.Node;
                    menuGrid.Show(treeList, e.Point);
                }
            }
        }
    }
}
