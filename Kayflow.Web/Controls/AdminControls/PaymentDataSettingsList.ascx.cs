using System;
using DevExpress.Web;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_PaymentDataSettingsList : BaseControl
{
    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        gridList.DataBind();
    }

    protected void gridList_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        gridList.DataSource = CreateManager<PaymentDataSettingsManager>().GetForDictionary(CurrentOffice.ID);
    }

    protected void gridList_OnHtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data)
        {
            var visibleIndex = e.VisibleIndex;
            var chShow = gridList.FindRowCellTemplateControl(visibleIndex, null, "chShow") as ASPxCheckBox;
            if (chShow != null)
            {
                chShow.Checked = (bool) e.GetValue("Show");
                chShow.ClientSideEvents.ValueChanged =
                    jsFunctionOverlay(string.Format("ShowPaymentData_Change(s.GetValue(), '{0}');", e.KeyValue));
            }
        }
    }

    protected void gridList_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var arrParams = e.Parameters.Split('|');
        ePaymentDataField id;
        bool value;
        if (Enum.TryParse(arrParams[1], out id) && Boolean.TryParse(arrParams[0], out value))
        {
            var manager = CreateManager<PaymentDataSettingsManager>();
            var model = manager.GetDataSettings(CurrentOffice.ID, id);
            model.Show = value;
            manager.Model = model;
            manager.Save();
        }

        gridList.DataBind();
    }
}