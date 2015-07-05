using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Expense_ExpenseList : BaseListControl<ExpenseManager, ExpenseController, Expense>
{
    public override ASPxGridView GridView
    {
        get { return gridList; }
    }

    public override ASPxButton AddButton
    {
        get { return btnAdd; }
    }

    public override string GetEditPopupTitle(bool isEdit = false)
    {
        return "витрати";
    }
}