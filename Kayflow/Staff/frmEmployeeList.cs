using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow.Staff
{
    public partial class frmEmployeeList : BaseListForm
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
                return viewEmployee;
            }
        }

        public frmEmployeeList()
        {
            InitializeComponent();
        }

        protected override void BaseListForm_Load(object sender, System.EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            DefaultPage.Text = Resources.employeeList;
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<EmployeeManager>().GetByOffice(CurrentInfo.OfficeID);
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmEmployeeEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmEmployeeEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<EmployeeManager, EmployeeController, Employee>();
        }
    }
}
