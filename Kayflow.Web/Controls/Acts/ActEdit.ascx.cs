using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Utils;
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
                        GroupOrdNum = item.GroupOrdNum,
                        ShowComments = item.ShowComments
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
        model.SalaryPaidDate = GetValue<DateTime?>(txtSalaryPaidDate);
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
        var tabMain = frmEditForm.FindItemOrGroupByName("tabMain") as TabbedLayoutGroup;
        if (tabMain==null)
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
            var @group = tabMain.Items.Add<LayoutGroup>(documentItem.DocGroup.GroupName,
                string.Format("group{0}", documentItem.GroupId));
            //@group.Height = Unit.Pixel(420);
            @group.ColCount = 2;
            @group.GroupBoxStyle.VerticalAlign = VerticalAlign.Top;
            foreach (var document in documentItem.Documents.OrderBy(d => d.OrdNum))
            {
                var itemContainer = @group;
                if (document.ShowComments)
                {
                    itemContainer = @group.Items.Add<LayoutGroup>(document.DocumentName,
                        string.Format("itemGroup{0}", document.ID));
                    itemContainer.ShowCaption = DefaultBoolean.False;
                    itemContainer.GroupBoxStyle.Border.BorderStyle = BorderStyle.None;
                    itemContainer.Paddings.Padding = Unit.Pixel(0);
                    itemContainer.CellStyle.Paddings.Padding = Unit.Pixel(0);
                    itemContainer.GroupBoxDecoration = GroupBoxDecoration.None;
                }

                #region -= Item =-
                var item = itemContainer.Items.Add<LayoutItem>(document.DocumentName, string.Format("item{0}", document.ID));
                var edit = GetEdit(document.ID.ToString(), document.ValueSetID);
                var actDocument = _actDocuments.Find(l => l.DocumentID == document.ID);
                if (actDocument != null)
                {
                    edit.Value = actDocument.DocumentValueID;
                }

                item.Controls.Add(edit); 
                #endregion

                if (document.ShowComments)
                {
                    var itemComment = itemContainer.Items.Add<LayoutItem>("Коментар", string.Format("itemComment{0}", document.ID));
                    var commentEdit = GetEdit(document.ID.ToString());
                    if (actDocument != null)
                    {
                        commentEdit.Value = actDocument.Comment;
                    }

                    itemComment.Controls.Add(commentEdit); 
                }
            }
        }
    }

    private void SetPayments()
    {
        var settings = CreateManager<PaymentDataSettingsManager>().GetByOffice(CurrentOffice.ID);
        foreach (var item in Enum.GetValues(typeof(ePaymentDataField)).Cast<ePaymentDataField>().ToList())
        {
            var layoutItem = frmEditForm.FindItemByFieldName(item.ToString());
            if (layoutItem == null)
                continue;
            var txt = layoutItem.Controls.OfType<ASPxButtonEditBase>().FirstOrDefault();
            if (txt == null)
                continue;
            if (!settings.Find(i => i.PaymentFieldID == item).Show)
            {
                layoutItem.Visible = false;
            }
        }

        var salaryGroup = frmEditForm.FindItemOrGroupByName("SalaryGroup") as LayoutGroup;
        if (salaryGroup != null)
        {
            salaryGroup.Visible = salaryGroup.Items.Cast<LayoutItem>().Any(i => i.Visible);
        }

        var salaryTab = frmEditForm.FindItemOrGroupByName("SalaryTab") as LayoutGroup;
        if (salaryTab != null)
        {
            salaryTab.Visible = salaryTab.Items.Cast<LayoutItemBase>().Any(i => i.Visible);
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
                case ePaymentDataField.SalaryCalculated:
                    pModel.SalaryCalculated = GetValue<double?>(txt);
                    break;
                case ePaymentDataField.CalculatedMain:
                    pModel.CalculatedMain = GetValue<double?>(txt);
                    break;
            }
        }
    }

    private List<ActDocument> getActDocuments()
    {
        var result = new List<ActDocument>();
        var tabMain = frmEditForm.FindItemOrGroupByName("tabMain") as TabbedLayoutGroup;
        if (tabMain == null)
            return result;

        foreach (var @group in tabMain.Items.Cast<LayoutGroup>().Where(g => g.Name.StartsWith("group")))
        {
            foreach (var container in @group.Items.Cast<LayoutItemBase>())
            {
                if (container is LayoutGroup)
                {
                    ActDocument document = null;
                    var skipStep = false;
                    foreach (var item in (container as LayoutGroup).Items.Cast<LayoutItem>())
                    {
                        if (skipStep)
                            continue;

                        foreach (var edit in item.Controls.Cast<ASPxEdit>())
                        {
                            if (document == null)
                            {
                                var value = GetValue<Guid?>(edit);
                                if (!value.HasValue)
                                {
                                    skipStep = true;
                                    continue;
                                }

                                document = new ActDocument
                                {
                                    DocumentID = Guid.Parse(edit.ID),
                                    DocumentValueID = value.Value
                                };
                                result.Add(document);
                            }
                            else
                            {
                                    document.Comment = GetValue<string>(edit);
                            }
                        }
                    }
                }

                if (container is LayoutItem)
                {
                    foreach (var edit in (container as LayoutItem).Controls.Cast<ASPxEdit>())
                    {
                        var document = new ActDocument();
                        var value = GetValue<Guid?>(edit);
                        if (value.HasValue)
                        {
                            document.DocumentID = Guid.Parse(edit.ID);
                            document.DocumentValueID = GetValue<Guid>(edit);
                            result.Add(document);
                        }
                    }
                }
            }
        }
        return result;
    }

    private ASPxComboBox GetEdit(string id, Guid valueSetId)
    {
        var comboBox = new ASPxComboBox
        {
            Width = Unit.Pixel(225),
            ID = id,
            ValueType = typeof(Guid)
        };
        InitCombo(comboBox, CreateManager<DocumentValueManager>().GetBySet(valueSetId), e0Type.PlsSelect);
        return comboBox;
    }

    private ASPxTextBox GetEdit(string id)
    {
        return new ASPxTextBox
        {
            Width = Unit.Pixel(225),
            ID = String.Format("txtComment{0}", id),
            MaxLength = 256
        }; ;
    }
}