using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using Framework.SqlDataAccess.Manager;
using Kayflow.Dictionary;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow.Acts
{
    public partial class frmActEdit : BaseEditForm
    {
        public frmActEdit()
        {
            InitializeComponent();
        }

        protected override void AttachEventHandlers()
        {
            base.AttachEventHandlers();
            ddlEmployee.TextChanged += Update_Actions;
            txtMeteringDate.TextChanged += Update_Actions;
            ddlTerritorialUnit.TextChanged += Update_Actions;
            txtCustomerName.TextChanged += Update_Actions;
            txtCustomerPhone.TextChanged += Update_Actions;
            txtAreaAmount.TextChanged += Update_Actions;
            txtActAmount.TextChanged += Update_Actions;
            ddlCategory.TextChanged += Update_Actions;
            txtSalaryCalculated.TextChanged += Update_Actions;
            txtCalculatedMain.TextChanged += Update_Actions;
        }

        protected override void BaseEditForm_Shown(object sender, EventArgs e)
        {
            base.BaseEditForm_Shown(sender, e);
            new CustomFocusHelper(layoutMain).FocusFirstEditableControl();
        }

        protected override bool IsAllowSave()
        {
            return base.IsAllowSave()
                   && ddlEmployee.EditValue != null
                   && ddlTerritorialUnit.EditValue != null
                   && ddlCategory.EditValue != null
                   && !string.IsNullOrEmpty(txtMeteringDate.Text)
                   && !string.IsNullOrEmpty(txtCustomerName.Text)
                   && !string.IsNullOrEmpty(txtCustomerPhone.Text)
                   && !string.IsNullOrEmpty(txtAreaAmount.Text)
                   && !string.IsNullOrEmpty(txtActAmount.Text)
                   && !string.IsNullOrEmpty(txtSalaryCalculated.Text)
                   && !string.IsNullOrEmpty(txtCalculatedMain.Text);
        }

        protected override void LoadData()
        {
            base.LoadData();
            ddlEmployee.Properties.DataSource = Factory.Manager<EmployeeManager>().GetByOffice(CurrentInfo.OfficeID);
            ddlTerritorialUnit.Properties.DataSource =
                Factory.Manager<TerritorialUnitManager>().GetByType(CurrentInfo.OfficeID, eUnitType.Locality);
            ddlCategory.Properties.DataSource = Factory.Manager<CategoryManager>().GetByOffice(CurrentInfo.OfficeID);
            var manager = Factory.Manager<ActManager>();
            var model = manager.Controller.Get(DocID);
            if (model != null)
            {
                ddlEmployee.EditValue = model.EmployeeID;
                txtMeteringDate.EditValue = model.MeteringDate;
                ddlTerritorialUnit.EditValue = model.TerritorialUnitID;
                txtAddress.Text = model.Address;
                txtCustomerName.Text = model.CustomerName;
                txtCustomerPhone.Text = model.CustomerPhone;
                txtAreaAmount.EditValue = model.AreaAmount;
                txtActAmount.EditValue = model.ActAmount;
                ddlCategory.EditValue = model.CategoryID;
                txtActNum.Text = model.ActNum;
                txtActDate.EditValue = model.ActDate;
                txtSalaryCalculated.EditValue = model.SalaryCalculated;
                txtSalaryPaidDate.EditValue = model.SalaryPaidDate;
                txtCalculatedMain.EditValue = model.CalculatedMain;
                txtPaidMainDate.EditValue = model.PaidMainDate;
                txtDescription.Text = model.Description;
                chIsClosed.Checked = model.IsClosed;
            }
            else
            {
                txtMeteringDate.EditValue = DateTime.Now;
                ddlEmployee.EditValue = CurrentInfo.EmployeeID;
            }

            ddlEmployee.Enabled = CurrentInfo.Permission == ePermissions.Admin;
            SetPayments(model);
            SetDocuments(model);
        }

        private void SetPayments(Act pModel)
        {
            var list = Factory.Manager<PaymentDataSettingsManager>().GetByOffice(CurrentInfo.OfficeID);
            foreach (var item in Enum.GetValues(typeof(ePaymentDataField)).Cast<ePaymentDataField>().ToList())
            {
                var layout = groupPayment.Items.Cast<LayoutControlItem>().ToList().Find(
                    i => i.Tag.ToString() == item.ToString());
                var txt = layout.Control as TextEdit;
                if (txt == null) continue;
                switch (item)
                {
                    case ePaymentDataField.TotalCost:
                        txt.EditValue = pModel != null ? pModel.TotalCost : null;
                        break;
                    case ePaymentDataField.PaidOn:
                        txt.EditValue = pModel != null ? pModel.PaidOn : null;
                        break;
                    case ePaymentDataField.LeftOn:
                        txt.EditValue = pModel != null ? pModel.LeftOn : null;
                        break;
                    case ePaymentDataField.Approval1:
                        txt.EditValue = pModel != null ? pModel.Approval1 : null;
                        break;
                    case ePaymentDataField.KailasPaid1:
                        txt.EditValue = pModel != null ? pModel.KailasPaid1 : null;
                        break;
                    case ePaymentDataField.KailasDue:
                        txt.EditValue = pModel != null ? pModel.KailasDue : null;
                        break;
                    case ePaymentDataField.PaidDue:
                        txt.EditValue = pModel != null ? pModel.PaidDue : null;
                        break;
                    case ePaymentDataField.Approval2:
                        txt.EditValue = pModel != null ? pModel.Approval2 : null;
                        break;
                    case ePaymentDataField.KailasPaid2:
                        txt.EditValue = pModel != null ? pModel.KailasPaid2 : null;
                        break;
                }

                if (!list.Find(i=>i.PaymentFieldID==item).Show && txt.EditValue == null)
                {
                    layout.HideToCustomization();
                }
            }
        }

        private void FillPayments(Act pModel)
        {
            if (pModel == null)
                return;
            foreach (var item in groupPayment.Items.Cast<LayoutControlItem>().ToList().FindAll(i => !i.IsHidden))
            {
                var txt = item.Control as TextEdit;
                if (txt == null) continue;
                switch ((ePaymentDataField)Enum.Parse(typeof(ePaymentDataField), item.Tag.ToString()))
                {
                    case ePaymentDataField.TotalCost:
                        pModel.TotalCost = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.PaidOn:
                        pModel.PaidOn = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.LeftOn:
                        pModel.LeftOn = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.Approval1:
                        pModel.Approval1 = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.KailasPaid1:
                        pModel.KailasPaid1 = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.KailasDue:
                        pModel.KailasDue = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.PaidDue:
                        pModel.PaidDue = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.Approval2:
                        pModel.Approval2 = GetValue<double?>(txt);
                        break;
                    case ePaymentDataField.KailasPaid2:
                        pModel.KailasPaid2 = GetValue<double?>(txt);
                        break;
                }
            }
        }

        private void SetDocuments(Act pModel)
        {
            var groups = Factory.Manager<DocumentGroupManager>().GetByOffice(CurrentInfo.OfficeID);
            var documents = Factory.Manager<DocumentManager>().GetByOffice(CurrentInfo.OfficeID);
            var list = new List<ActDocument>();
            if (pModel != null)
            {
                list = Factory.Manager<ActDocumentManager>().GetForAct(pModel.ID);
                var addList = new List<Document>();
                foreach (var item in list.FindAll(l=>documents.All(d=>d.DocumentID!=l.DocumentID)))
                {
                    addList.Add(new Document
                        {
                            DocumentID = item.DocumentID,
                            DocumentName = item.DocumentName,
                            DocumentGroupID = item.DocumentGroupID,
                            OrdNum = item.DocumentOrdNum,
                            Hidden = false,
                            ValueSetID = item.ValueSetID
                        });
                    if (groups.All(g => g.ID != item.DocumentGroupID))
                    {
                        groups.Add(new DocumentGroup
                            {
                                DocumentGroupID = item.DocumentGroupID,
                                GroupName = item.GroupName,
                                OrdNum = item.GroupOrdNum,
                                Hidden = false
                            });
                    }
                }
                if (addList.Count > 0)
                    documents.AddRange(addList);
            }
            layoutDocuments.BeginUpdate();
            try
            {
                foreach (var grp in groups.OrderBy(g => g.OrdNum))
                {
                    var layoutGroup = layoutDocuments.Root.AddGroup(grp.GroupName);
                    layoutGroup.Tag = grp.ID;
                    foreach (var document in documents.Where(d => d.DocumentGroupID == grp.ID).OrderBy(d=>d.OrdNum))
                    {
                        var item = layoutGroup.AddItem(document.DocumentName);
                        item.TextLocation = Locations.Left;
                        item.Tag = document.ID;
                        var ddl = new LookUpEdit();
                        ddl.Properties.ValueMember = "ID";
                        ddl.Properties.DisplayMember = "DocValue";
                        ddl.Properties.NullText = Resources.nullText;
                        ddl.Properties.Columns.Add(new LookUpColumnInfo
                            {
                                FieldName = "DocValue"
                            });
                        ddl.Properties.ShowHeader = false;
                        ddl.Properties.ShowFooter = false;
                        ddl.Properties.DataSource =
                            Factory.Manager<DocumentValueManager>().GetBySet(document.ValueSetID);
                        item.Control = ddl;
                        var value = list.Find(l => l.DocumentID == document.ID);
                        if (value != null)
                            ddl.EditValue = value.DocumentValueID;
                    }
                }
            }
            finally
            {
                layoutDocuments.EndUpdate();
            }
        }

        private List<ActDocument> GetDocuments()
        {
            return (from @group in layoutDocuments.Root.Items.Cast<LayoutControlGroup>().ToList()
                    from item in @group.Items.Cast<LayoutControlItem>()
                    let ddl = item.Control as LookUpEdit
                    where ddl != null
                    let value = GetValue<Guid?>(ddl)
                    where value.HasValue
                    select new ActDocument
                        {
                            DocumentID = (Guid) item.Tag,
                            DocumentValueID = value.Value
                        }).ToList();
        }

        protected override BaseModel DoSave()
        {
            var manager = CreateManager<ActManager>();
            var model = manager.InitializeModel(DocID);
            if (model.IsNew)
                model.OfficeID = CurrentInfo.OfficeID;
            model.EmployeeID = GetValue<Guid>(ddlEmployee);
            model.MeteringDate = GetValue<DateTime>(txtMeteringDate);
            model.TerritorialUnitID = GetValue<Guid>(ddlTerritorialUnit);
            model.Address = GetValue<string>(txtAddress);
            model.CustomerName = GetValue<string>(txtCustomerName);
            model.CustomerPhone = GetValue<string>(txtCustomerPhone);
            model.AreaAmount = GetValue<int>(txtAreaAmount);
            model.ActAmount = GetValue<int>(txtActAmount);
            model.CategoryID = GetValue<Guid>(ddlCategory);
            model.ActDate = GetValue<DateTime?>(txtActDate);
            model.ActNum = GetValue<string>(txtActNum);
            FillPayments(model);
            model.SalaryCalculated = GetValue<double>(txtSalaryCalculated);
            model.SalaryPaidDate = GetValue<DateTime?>(txtSalaryPaidDate);
            model.CalculatedMain = GetValue<double>(txtCalculatedMain);
            model.PaidMainDate = GetValue<DateTime?>(txtPaidMainDate);
            model.Description = GetValue<string>(txtDescription);
            model.IsClosed = chIsClosed.Checked;
            return manager.Save(GetDocuments());
        }

        #region -= Units =-
        private void ddlTerritorialUnit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Glyph)
            {
                var form = new frmTerritorialUnitFind();
                form.SaveComplited += FindUnitComplited;
                form.CurrentInfo = CurrentInfo;
                form.ShowDialog(this);
            }
        }

        private void FindUnitComplited(object sender, EventArgs e)
        {
            var dialog = sender as BaseEditForm;
            if (dialog != null)
            {
                ddlTerritorialUnit.Refresh();
                ddlTerritorialUnit.EditValue = dialog.DocID;
            }
        } 
        #endregion
    }
}
