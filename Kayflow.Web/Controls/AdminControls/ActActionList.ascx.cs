using System.Drawing;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_ActActionList : BaseListControl<ActActionManager, ActActionController, ActAction>
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
        return "етап";
    }

    protected void gridList_OnHtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
    {
        if (e.DataColumn.FieldName == "AlertDays" || e.DataColumn.FieldName == "RelativeAlertDays")
        {
            var color = (int?) e.GetValue("AlertColor");
            if (color.HasValue)
            {
                e.Cell.BackColor = Color.FromArgb(color.Value);
            }
        }
    }
}