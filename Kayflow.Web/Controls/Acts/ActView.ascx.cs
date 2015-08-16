using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_ActView : BaseControl
{
    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        var model = CreateManager<ActManager>().Controller.GetByIDEx(CurrentOffice.OfficeID, DocID);
        if (model == null)
            return;
        ShowTitle(string.Format("Справа від {0:d} ({1})", model.MeteringDate, model.EmployeeName));
        LoadMainData(model);
        gridSteps.DataBind();
        gridActDocument.DataBind();
        gridActDocument.ExpandAll();
        gridHistory.DataBind();
        LoadPaymentData(model);
    }

    private void LoadPaymentData(Act model)
    {
        var settings = CreateManager<PaymentDataSettingsManager>().GetByOffice(CurrentOffice.ID);
        foreach (var item in Enum.GetValues(typeof(ePaymentDataField)).Cast<ePaymentDataField>().ToList())
        {
            switch (item)
            {
                case ePaymentDataField.Approval1:
                    ApplyPayment(settings, item, model.Approval1, panApproval1, lblApproval1);
                    break;
                case ePaymentDataField.Approval2:
                    ApplyPayment(settings, item, model.Approval2, panApproval2, lblApproval2);
                    break;
                case ePaymentDataField.KailasDue:
                    ApplyPayment(settings, item, model.KailasDue, panKailasDue, lblKailasDue);
                    break;
                case ePaymentDataField.KailasPaid1:
                    ApplyPayment(settings, item, model.KailasPaid1, panKailasPaid1, lblKailasPaid1);
                    break;
                case ePaymentDataField.KailasPaid2:
                    ApplyPayment(settings, item, model.KailasPaid2, panKailasPaid2, lblKailasPaid2);
                    break;
                case ePaymentDataField.LeftOn:
                    ApplyPayment(settings, item, model.LeftOn, panLeftOn, lblLeftOn);
                    break;
                case ePaymentDataField.PaidDue:
                    ApplyPayment(settings, item, model.PaidDue, panPaidDue, lblPaidDue);
                    break;
                case ePaymentDataField.PaidOn:
                    ApplyPayment(settings, item, model.PaidOn, panPaidOn, lblPaidOn);
                    break;
                case ePaymentDataField.TotalCost:
                    ApplyPayment(settings, item, model.TotalCost, panTotalCost, lblTotalCost);
                    break;
                case ePaymentDataField.CalculatedMain:
                    ApplyPayment(settings, item, model.CalculatedMain, panCalculatedMain, lblCalculatedMain);
                    break;
                case ePaymentDataField.SalaryCalculated:
                    ApplyPayment(settings, item, model.SalaryCalculated, panSalaryCalculated, lblSalaryCalculated);
                    break;
                case ePaymentDataField.PaidMainDate:
                    ApplyPayment(settings, item, model.PaidMainDate, panPaidMainDate, lblPaidMainDate);
                    break;
                case ePaymentDataField.SalaryPaidDate:
                    ApplyPayment(settings, item, model.SalaryPaidDate, panSalaryPaidDate, lblSalaryPaidDate);
                    break;
            }
        }
    }

    private void ApplyPayment(List<PaymentDataSettings> settings, ePaymentDataField item, double? value, Panel pan, Label lbl)
    {
        var show = settings.Find(i => i.PaymentFieldID == item).Show
                   || value.HasValue;
        pan.Visible = show;
        if (show && value.HasValue)
        {
            lbl.Text = value.Value.ToString("n", CultureInfo.InvariantCulture);
        }

        paymentVisibleSet(show);
    }

    private void paymentVisibleSet(bool show)
    {
        var tabPayments = pageActView.TabPages.FindByName("tabPayments");
        tabPayments.Visible = show || tabPayments.Visible;
    }

    private void ApplyPayment(List<PaymentDataSettings> settings, ePaymentDataField item, DateTime? value, Panel pan, Label lbl)
    {
        var show = settings.Find(i => i.PaymentFieldID == item).Show
                   || value.HasValue;
        pan.Visible = show;
        if (show && value.HasValue)
        {
            lbl.Text = value.Value.ToShortDateString();
        }

        paymentVisibleSet(show);
    }

    private void LoadMainData(Act model)
    {
        lblEmployeeName.Text = model.EmployeeName;
        lblUnitName.Text = model.UnitName;
        lblMeteringDate.Text = model.MeteringDate.ToShortDateString();
        lblAddress.Text = model.Address;
        lblCategoryName.Text = model.CategoryName;
        lblDescription.Text = model.Description;
        lblCustomerName.Text = model.CustomerName;
        lblCustomerPhone.Text = model.CustomerPhone;
        lblActNum.Text = model.ActNum;
        if (model.ActDate.HasValue)
            lblActDate.Text = model.ActDate.Value.ToShortDateString();
        lblAreaAmount.Text = model.AreaAmount.ToString(CultureInfo.InvariantCulture);
        lblActAmount.Text = model.ActAmount.ToString(CultureInfo.InvariantCulture);
        if (model.SalaryPaidDate.HasValue)
            lblSalaryPaidDate.Text = model.SalaryPaidDate.Value.ToShortDateString();
        if (model.PaidMainDate.HasValue)
            lblPaidMainDate.Text = model.PaidMainDate.Value.ToShortDateString();
        chIsClosed.Checked = model.IsClosed;
        chIgnoreTerms.Checked = model.IgnoreTherms;
        lblActStatus.Text = model.StateName;
        var note = CreateManager<NoteManager>().GetLast(DocID);
        if (note != null)
        {
            lblDelayReason.Text = note.Description;
        }
    }

    protected void gridSteps_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridSteps.DataSource = CreateManager<StepManager>().GetForAct(DocID);
    }

    protected void gridSteps_OnHtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data)
        {
            var color = (int?)e.GetValue("AlertColor");
            var days = (int?)e.GetValue("AlertDays");
            if (color.HasValue && days.HasValue && days.Value > 0)
            {
                e.Row.BackColor = Color.FromArgb(color.Value);
            }
        }
    }

    protected void gridActDocument_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridActDocument.DataSource = CreateManager<ActDocumentManager>().GetForActAll(DocID, CurrentOffice.ID);
    }

    protected void gridActDocument_OnHtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data)
        {
            var color = (int?)e.GetValue("DocColor");
            if (color.HasValue)
            {
                e.Row.BackColor = Color.FromArgb(color.Value);
            }
        }
    }

    protected void gridHistory_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridHistory.DataSource = CreateManager<ActHistoryManager>().GetForAct(DocID);
    }
}