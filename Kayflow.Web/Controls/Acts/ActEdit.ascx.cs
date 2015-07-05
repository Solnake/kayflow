using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_ActEdit : BaseEditControl<ActManager, ActController, Act>
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

    #region -= Documents =-

    private IEnumerable<Document> _documents
    {
        get
        {
            var documents = Storage["Documents"] as List<Document>;
            if (documents == null)
            {
                documents = CreateManager<DocumentManager>().GetByOffice(CurrentOffice.ID);
                foreach (var item in _actDocuments.FindAll(l => documents.All(d => d.DocumentID != l.DocumentID)))
                {
                    documents.Add(new Document
                    {
                        DocumentID = item.DocumentID,
                        DocumentName = item.DocumentName,
                        DocumentGroupID = item.DocumentGroupID,
                        OrdNum = item.DocumentOrdNum,
                        Hidden = false,
                        ValueSetID = item.ValueSetID,
                        GroupName = item.GroupName,
                        GroupOrdNum = item.GroupOrdNum
                    });
                }

                Storage["Documents"] = documents;
            }

            return documents;
        }
    }

    private List<ActDocument> _actDocuments
    {
        get
        {
            var documents = Storage["actDocuments"] as List<ActDocument>;
            if (documents == null)
            {
                documents = CreateManager<ActDocumentManager>().GetForAct(DocID);
                Storage["actDocuments"] = documents;
            }

            return documents;
        }
    }

    #endregion

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitCombo<EmployeeManager>(ddlEmployees, e0Type.PlsSelect);
        InitCombo(ddlTerritorialUnits,
            CreateManager<TerritorialUnitManager>().GetByType(CurrentOffice.OfficeID, eUnitType.Locality),
            e0Type.PlsSelect);
        InitCombo<CategoryManager>(ddlCategories, e0Type.PlsSelect);
        ddlEmployees.Enabled = CurrentEmployee.IsAdmin;
    }

    protected override void DoInitialize_4_LoadDataFinal()
    {
        base.DoInitialize_4_LoadDataFinal();
        SetPayments();
    }

    protected override void InitControlsByModelData(Act model)
    {
        base.InitControlsByModelData(model);
        if (model.IsNew)
        {
            txtMeteringDate.Date = DateTime.Now;
            ddlEmployees.Value = CurrentEmployee.ID;
        }
    }

    protected override void LoadModelDataFromControls(Act model)
    {
        if (model.IsNew)
        {
            model.OfficeID = CurrentOffice.ID;
            model.EmployeeID = CurrentEmployee.ID;
        }
        model.MeteringDate = GetValue<DateTime>(txtMeteringDate);
        model.TerritorialUnitID = GetValue<Guid>(ddlTerritorialUnits);
        model.Address = GetValue<string>(txtAddress);
        model.CustomerName = GetValue<string>(txtCustomerName);
        model.CustomerPhone = GetValue<string>(txtCustomerPhone);
        model.AreaAmount = GetValue<int>(txtAreaAmount);
        model.ActAmount = GetValue<int>(txtActAmount);
        model.CategoryID = GetValue<Guid>(ddlCategories);
        model.ActDate = GetValue<DateTime?>(txtActDate);
        model.ActNum = GetValue<string>(txtActNum);
        FillPayments(model);
        model.SalaryCalculated = GetValue<double>(txtSalaryCalculated);
        model.SalaryPaidDate = GetValue<DateTime?>(txtSalaryPaidDate);
        model.CalculatedMain = GetValue<double>(txtCalculatedMain);
        model.PaidMainDate = GetValue<DateTime?>(txtPaidMainDate);
        model.Description = GetValue<string>(txtDescription);
        model.IsClosed = chIsClosed.Checked;
        model.IgnoreTherms = chIgnoreTerms.Checked;
    }

    public override Act SaveAction(ActManager manager)
    {
        return manager.Save(getActDocuments());
    }

    protected void frmEditForm_OnInit(object sender, EventArgs e)
    {
        var groupDocs = frmEditForm.FindItemOrGroupByName("groupDocs") as LayoutGroup;
        if (groupDocs == null)
            return;
        foreach (var documentItem in _documents.GroupBy(d => d.DocumentGroupID, (key, documents) =>
        {
            var enumerable = documents as IList<Document> ?? documents.ToList();
            var document = enumerable.First();
            return new
            {
                GroupId = key,
                DocGroup = new { GroupOrdNum = document.DocumentGroupID, document.GroupName },
                Documents = enumerable
            };
        }).OrderBy(d => d.DocGroup.GroupOrdNum))
        {
            var @group = groupDocs.Items.Add<LayoutGroup>(documentItem.DocGroup.GroupName,
                string.Format("group{0}", documentItem.GroupId));
            @group.GroupBoxDecoration = GroupBoxDecoration.HeadingLine;
            foreach (var document in documentItem.Documents.OrderBy(d => d.OrdNum))
            {
                var item = @group.Items.Add<LayoutItem>(document.DocumentName, string.Format("item{0}", document.ID));
                var edit = GetEdit(document.ID.ToString(), document.ValueSetID);
                var actDocument = _actDocuments.Find(l => l.DocumentID == document.ID);
                if (actDocument != null)
                {
                    edit.Value = actDocument.DocumentValueID;
                }

                item.Controls.Add(edit);
            }
        }
        groupDocs.Visible = groupDocs.Items.Count > 0;
    }

    private void SetPayments()
    {
        var settings = CreateManager<PaymentDataSettingsManager>().GetByOffice(CurrentOffice.ID);
        foreach (var item in Enum.GetValues(typeof(ePaymentDataField)).Cast<ePaymentDataField>().ToList())
        {
            var layoutItem = frmEditForm.FindItemByFieldName(item.ToString());
            if (layoutItem == null)
                continue;
            var txt = layoutItem.Controls.OfType<ASPxSpinEdit>().FirstOrDefault();
            if (txt == null)
                continue;
            if (!settings.Find(i => i.PaymentFieldID == item).Show && txt.Value == null)
            {
                layoutItem.Visible = false;
            }
        }
    }

    private void FillPayments(Act pModel)
    {
        if (pModel == null)
            return;
        foreach (var item in Enum.GetValues(typeof(ePaymentDataField)).Cast<ePaymentDataField>().ToList())
        {
            var layoutItem = frmEditForm.FindItemByFieldName(item.ToString());
            if (layoutItem == null)
                continue;
            var txt = layoutItem.Controls.OfType<ASPxSpinEdit>().FirstOrDefault();
            if (txt == null)
                continue;
            switch (item)
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

    private List<ActDocument> getActDocuments()
    {
        var result = new List<ActDocument>();
        var groupDocs = frmEditForm.FindItemOrGroupByName("groupDocs") as LayoutGroup;
        if (groupDocs == null)
            return result;
        result.AddRange(from @group in groupDocs.Items.Cast<LayoutGroup>()
            from item in @group.Items.Cast<LayoutItem>()
            from ddl in item.Controls.Cast<ASPxComboBox>()
            let value = GetValue<Guid?>(ddl)
            where value.HasValue
            select new ActDocument
            {
                DocumentID = Guid.Parse(ddl.ID),
                DocumentValueID = value.Value
            });
        return result;
    }

    private ASPxComboBox GetEdit(string id, Guid valueSetId)
    {
        var comboBox = new ASPxComboBox
        {
            Width = Unit.Pixel(225),
            ID = id,
            ValueType = typeof (Guid)
        };
        InitCombo(comboBox, CreateManager<DocumentValueManager>().GetBySet(valueSetId), e0Type.PlsSelect);
        return comboBox;
    }
}