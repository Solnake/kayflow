using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_ActList : BaseListControl<ActManager, ActController, Act>
{
    public delegate List<Act> ActDataSourceEventHandler(object sender, EventArgs e);

    public event ActDataSourceEventHandler GetDataSource;

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
        return "справу";
    }

    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        var settings = CreateManager<ActListSettingManager>().GetForEmployee(CurrentOffice.ID, CurrentEmployee.ID);
        if (settings != null)
        {
            foreach (var item in settings.DisplayFields.FindAll(s=>!s.Show))
            {
                gridList.Columns[item.FieldName].Visible = false;
            }
        }
    }

    protected void gridList_OnHtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        if (e.RowType == GridViewRowType.Data)
        {
            var color = (int?)e.GetValue("AlertColor");
            var ignoreTerms = (bool?)e.GetValue("IgnoreTherms");
            if (ignoreTerms.HasValue && ignoreTerms.Value)
                return;
            if (color.HasValue)
            {
                e.Row.BackColor = Color.FromArgb(color.Value);
            }
        }
    }

    protected override void gvItems_BeforePerformDataSelect(object sender, EventArgs e)
    {
        if (GetDataSource != null)
            GridView.DataSource = GetDataSource(sender, e);
    }
}