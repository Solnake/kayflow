using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Expense_ExpenseEdit : BaseEditControl<ExpenseManager, ExpenseController, Expense>
{
    #region -= Dialog =-
    protected override ASPxCallback GetCallbackControl()
    {
        return clbkSave;
    }

    protected override ASPxButton GetCancelButton()
    {
        return btnCancel;
    }

    protected override ASPxButton GetOkButton()
    {
        return btnOk;
    }

    protected override ASPxFormLayout Layout
    {
        get { return frmEditForm; }
    } 
    #endregion

    private IEnumerable<Cost> _costs
    {
        get
        {
            var costs = Storage["Costs"] as List<Cost>;
            if (costs == null)
            {
                costs = CreateManager<CostManager>().GetByOffice(CurrentOffice.ID);

                if (_expenses.Any())
                {
                    var addList = new List<Cost>();
                    foreach (var item in _expenses.FindAll(c => costs.All(l => l.ID != c.CostID)))
                    {
                        costs.Add(new Cost
                        {
                            CostName = item.CostName,
                            Hidden = false,
                            OfficeID = CurrentOffice.OfficeID,
                            ID = item.CostID
                        });
                    }

                    if (addList.Any())
                        costs.AddRange(addList);
                }

                Storage["Costs"] = costs;
            }

            return costs;
        }
    }

    private List<ExpenseCost> _expenses
    {
        get
        {
            var expenses = Storage["Expenses"] as List<ExpenseCost>;
            if (expenses == null)
            {
                expenses = CreateManager<ExpenseCostManager>().GetAll(DocID);
                Storage["Expenses"] = expenses;
            }

            return expenses;
        }
    }

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo<EmployeeManager>(ddlEmployees, e0Type.PlsSelect);
        if (frmEditForm.Items.Count > 4)
            frmEditForm.Items.Move(frmEditForm.FindItemOrGroupByName("itemButtons").Index, frmEditForm.Items.Count - 1);
    }

    protected override void InitControlsByModelData(Expense model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            ddlEmployees.Value = CurrentEmployee.ID;
            txtOnDate.Value = DateTime.Now;
        }
    }

    protected override void LoadModelDataFromControls(Expense model)
    {
        if (model.IsNew)
            model.OfficeID = CurrentOffice.ID;
        model.EmployeeID = GetValue<Guid>(ddlEmployees);
        model.OnDate = GetValue<DateTime>(txtOnDate);
        model.Distance = GetValue<int?>(txtDistance);
    }

    public override Expense SaveAction(ExpenseManager manager)
    {
        return manager.SaveAll(GetExpenses());
    }

    private List<ExpenseCost> GetExpenses()
    {
        if (frmEditForm.Items.Count == 4)
            return new List<ExpenseCost>();

        var list = _expenses ?? new List<ExpenseCost>();
        for (var i = 3; i < frmEditForm.Items.Count-1; i++)
        {
            var item = frmEditForm.Items[i] as LayoutItem;
            if (item != null)
            {
                foreach (var control in item.Controls.Cast<ASPxSpinEdit>())
                {
                    var costID = Guid.Parse(control.ID);
                    var expense = list.Find(e => e.CostID == costID) ?? new ExpenseCost
                    {
                        CostID = costID
                    };
                    expense.Amount = GetValue<double>(control);
                    if (list.All(e => e.CostID != costID))
                    {
                        list.Add(expense);
                    }
                }
            }
        }

        return list;
    }

    protected void frmEditForm_OnInit(object sender, EventArgs e)
    {
        if (_costs.Any())
        {
            foreach (var cost in _costs)
            {
                var item = frmEditForm.Items.Add<LayoutItem>(cost.Name, string.Format("item{0}", cost.ID));
                var edit = GetEdit(cost.ID.ToString());
                var value = _expenses.Find(c => c.CostID == cost.ID);
                if (value != null)
                {
                    edit.Value = value.Amount;
                }

                item.Controls.Add(edit);
            }
        }
    }

    private ASPxSpinEdit GetEdit(string id)
    {
        return new ASPxSpinEdit
        {
            NumberType = SpinEditNumberType.Float,
            MinValue = 0,
            MaxValue = 100000,
            Width = Unit.Pixel(225),
            ID = id
        };
    }
}