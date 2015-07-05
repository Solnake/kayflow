using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Expenses
{
    public partial class frmExpenseList : BaseListForm
    {
        #region -= Properties =-
        protected override GridControl Grid
        {
            get
            {
                return gridList;
            }
        }

        protected override GridView View
        {
            get
            {
                return viewExpense;
            }
        }
        #endregion

        public frmExpenseList()
        {
            InitializeComponent();
        }

        protected override void BaseListForm_Load(object sender, EventArgs e)
        {
            base.BaseListForm_Load(sender, e);
            RefreshHelper = new GridCointrolState(new[]
                {
                    new GridCointrolState.ViewDescriptor("", "ID"),
                    new GridCointrolState.ViewDescriptor("Costs", "CostID")
                });
        }

        protected override void BindData()
        {
            gridList.DataSource =
                Factory.Manager<ExpenseManager>().GetByOffice(CurrentInfo.OfficeID);
        }

        #region -= Buttons =-
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmExpenseEdit());
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowEditForm(new frmExpenseEdit(), GetFocusedValue());
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteHandler<ExpenseManager, ExpenseController, Expense>();
        }
        #endregion

        private void viewExpense_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            switch (gridList.LevelTree.Nodes[e.RelationIndex].RelationName)
            {
                case "Costs":
                    e.ChildList = Factory.Manager<ExpenseCostManager>().GetAll(GetGridValue(viewExpense, e.RowHandle));
                    break;
            }
        }

        private void viewExpense_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = gridList.LevelTree.Nodes.Count;
        }

        private void viewExpense_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = gridList.LevelTree.Nodes[e.RelationIndex].RelationName;
        }

        private void viewExpense_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            switch (gridList.LevelTree.Nodes[e.RelationIndex].RelationName)
            {
                case "Costs":
                    e.RelationName = "Затрати";
                    break;
            }
        }
    }
}
