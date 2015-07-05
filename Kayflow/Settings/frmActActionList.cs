using System.Drawing;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmActActionList : BaseListForm
    {
        public frmActActionList()
        {
            InitializeComponent();
        }

        protected override DevExpress.XtraGrid.GridControl Grid
        {
            get
            {
                return gridList;
            }
        }

        protected override DevExpress.XtraGrid.Views.Grid.GridView View
        {
            get
            {
                return viewActAction;
            }
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<ActActionManager>().GetForDictionary(CurrentInfo.OfficeID);
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmActActionEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmActActionEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<ActActionManager, ActActionController, ActAction>();
        }

        private void viewActAction_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var model = (viewActAction.GetRow(e.RowHandle) as ActAction);
            if ((e.Column.FieldName == "AlertDays" || e.Column.FieldName == "RelativeAlertDays")
                && model != null && model.AlertColor.HasValue)
            {
                e.Appearance.BackColor = Color.FromArgb(model.AlertColor.Value);
            }
        }
    }
}
