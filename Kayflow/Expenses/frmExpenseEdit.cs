using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Expenses
{
    public partial class frmExpenseEdit : BaseEditForm
    {
        public frmExpenseEdit()
        {
            InitializeComponent();
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            base.BaseEditForm_Shown(sender, e);
            new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            txtOnDate.TextChanged += Update_Actions;
            ddlEmployee.TextChanged += Update_Actions;
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && !string.IsNullOrEmpty(txtOnDate.Text)
                   && ddlEmployee.EditValue != null;
        }

        protected override void LoadData()
        {
            base.LoadData();
            var model = Factory.Controller<ExpenseController>().Get(DocID);
            ddlEmployee.Properties.DataSource = Factory.Manager<EmployeeManager>().GetByOffice(CurrentInfo.OfficeID);
            if (model != null)
            {
                ddlEmployee.EditValue = model.EmployeeID;
                txtOnDate.EditValue = model.OnDate;
                txtDistance.EditValue = model.Distance;
            }
            else
            {
                txtOnDate.EditValue = DateTime.Now;
                ddlEmployee.EditValue = CurrentInfo.EmployeeID;
            }
            SetCosts();
            ddlEmployee.Enabled = CurrentInfo.Permission == ePermissions.Admin;
        }

        private void SetCosts()
        {
            var list = Factory.Manager<CostManager>().GetByOffice(CurrentInfo.OfficeID);
            var costs = Factory.Manager<ExpenseCostManager>().GetAll(DocID);
            if (costs.Any())
            {
                var addList = new List<Cost>();
                foreach (var item in costs.FindAll(c => list.All(l => l.ID != c.CostID)))
                {
                    list.Add(new Cost
                        {
                            CostName = item.CostName,
                            Hidden = false,
                            OfficeID = CurrentInfo.OfficeID,
                            ID = item.CostID
                        });
                }
                if (addList.Any())
                    list.AddRange(addList);
            }
            layoutMain.BeginUpdate();
            try
            {
                foreach (var cost in list)
                {
                    var item = layoutMain.Root.AddItem(cost.CostName);
                    item.Tag = cost;
                    var txt = new SpinEdit();
                    txt.Properties.Mask.Assign(new MaskProperties() {MaskType = MaskType.Numeric, EditMask = "n"});
                    item.Control = txt;
                    var value = costs.Find(c => c.CostID == cost.ID);
                    if (value != null)
                    {
                        txt.EditValue = value.Amount;
                        txt.Tag = value;
                    }
                }
                layoutMain.BestFit();
                ClientSize = layoutMain.Root.MinSize.Height < 400
                                 ? new Size(ClientSize.Width, layoutMain.Root.MinSize.Height + 40)
                                 : new Size(ClientSize.Width, 440);
            }
            finally
            {
                layoutMain.EndUpdate();
            }
        }

        private List<ExpenseCost> GetCosts()
        {
            var list = new List<ExpenseCost>();
            foreach (var item in layoutMain.Root.Items.Cast<LayoutControlItem>().ToList().Where(i => i.Tag is Cost))
            {
                var txt = item.Control as SpinEdit;
                var cost = item.Tag as Cost;
                if (txt!=null && cost!=null)
                {
                    var value = txt.Tag as ExpenseCost ?? new ExpenseCost()
                        {
                            CostID = cost.ID
                        };
                    value.Amount = GetValue<double>(txt);
                    list.Add(value);
                }
            }
            return list;
        }

        protected override BaseModel DoSave()
        {
            var manager = Factory.Manager<ExpenseManager>();
            var model = manager.InitializeModel(DocID);
            model.EmployeeID = CurrentInfo.EmployeeID;
            model.OnDate = GetValue<DateTime>(txtOnDate);
            model.Distance = GetValue<int?>(txtDistance);
            return manager.SaveAll(GetCosts());
        }
    }
}
