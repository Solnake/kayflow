using System;
using System.Linq;
using DevExpress.Web.ASPxTreeList;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_OfficeTerritorialUnitList : BaseControl
{
    protected override void DoInitialize_1_BeforeLoadData()
    {
        base.DoInitialize_1_BeforeLoadData();
        treeUnits.DataSource = CreateManager<TerritorialUnitManager>().GetAll("UnitType, UnitName");
        treeUnits.DataBind();
    }

    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        var list = CreateManager<OfficeTerritorialUnitManager>().GetByOffice(CurrentOffice.ID);
        var iterator = treeUnits.CreateNodeIterator();
        while (true)
        {
            var node = iterator.GetNext();
            if (node == null) break;
            if (list.Any(i => i.TerritorialUnitID == (Guid)node["ID"]))
                node.Selected = true;
        }
    }

    protected void treeUnits_OnCustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        var list = treeUnits.GetSelectedNodes().Select(node => new OfficeTerritorialUnit
        {
            OfficeID = CurrentOffice.ID,
            TerritorialUnitID = (Guid) node.GetValue("ID")
        }).ToList();
        CreateManager<OfficeTerritorialUnitManager>().SaveAll(list, CurrentOffice.ID);
    }
}