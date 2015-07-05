using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Dictionary
{
    public partial class frmStateList : BaseListForm
    {
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
                return viewState;
            }
        }

        public frmStateList()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<StateManager>().GetByOffice(CurrentInfo.OfficeID);
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmStateEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmStateEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<StateManager, StateController, State>();
        }
    }
}
