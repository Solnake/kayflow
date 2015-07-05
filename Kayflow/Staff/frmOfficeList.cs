using System;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow.Staff
{
    public partial class frmOfficeList : BaseListForm
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
                return viewOffice;
            }
        }

        public frmOfficeList()
        {
            InitializeComponent();
        }

        protected override void BaseListForm_Load(object sender, EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            DefaultPage.Text = Resources.officeList;
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<OfficeManager>().GetAll("IsDefault desc, OfficeName");
        }

        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmOfficeEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmOfficeEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<OfficeManager, OfficeController, Office>();
            CurrentInfo.RefreshOffice();
        }

        protected override void SaveComplited(object sender, EventArgs e)
        {
            base.SaveComplited(sender, e);
            CurrentInfo.RefreshOffice();
        }
    }
}
