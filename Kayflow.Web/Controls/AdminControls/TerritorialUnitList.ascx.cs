using System;
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Data;
using Kayflow.Manager;

public partial class Controls_AdminControls_TerritorialUnitList : BaseControl
{
    protected override void DoInitialize(object data, bool loadData)
    {
        base.DoInitialize(data, loadData);
        if (loadData || treeUnits.IsCallback)
            BindTree();
    }

    private void BindTree()
    {
        treeUnits.DataSource = CreateManager<TerritorialUnitManager>().GetAll("UnitType, UnitName");
        treeUnits.DataBind();
    }

    protected void treeUnits_OnCustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        BindTree();
    }

    protected void treeUnits_OnNodeDeleting(object sender, ASPxDataDeletingEventArgs e)
    {
        try
        {
            var id = (Guid)e.Values[treeUnits.KeyFieldName];
            CreateManager<TerritorialUnitManager>().Delete(id);
            BindTree();
        }
        finally
        {
            e.Cancel = true;
        }
    }

    protected void treeUnits_OnHtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
    {
        if (e.RowKind == TreeListRowKind.Data)
        {
            button_SetClick(e.NodeKey, "btnEdit", string.Format("Edit('{0}');", e.GetValue("ID")));
            button_SetClick(e.NodeKey, "btnDelete", string.Format("Delete('{0}');", e.NodeKey));
        }
    }

    private void button_SetClick(string nodeKey, string buttonName, string script)
    {
        var button = treeUnits.FindDataCellTemplateControl(nodeKey, null, buttonName) as ASPxButton;
        if (button != null)
        {
            button.ClientSideEvents.Click = jsFunctionOverlay(script);
        }
    }

    protected void treeUnits_OnHtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
    {
        if (e.Column.Name == "columnButtons")
        {
            button_SetClick(e.NodeKey, "btnEdit", string.Format("Edit('{0}');", e.GetValue("ID")));
            button_SetClick(e.NodeKey, "btnDelete", string.Format("Delete('{0}');", e.NodeKey));
        }
    }

    protected void btnRelation_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("{0}?view=OfficeTerritorialUnitList", Request.Path));
    }
}