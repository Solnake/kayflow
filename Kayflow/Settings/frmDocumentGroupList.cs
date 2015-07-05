using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Settings
{
    public partial class frmDocumentGroupList : BaseListForm
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
                return viewDocumentGroup;
            }
        }

        public frmDocumentGroupList()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<DocumentGroupManager>().GetForDictionary(CurrentInfo.OfficeID);
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmDocumentGroupEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmDocumentGroupEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<DocumentGroupManager, DocumentGroupController, DocumentGroup>();
        }
    }
}
