using System;
using System.Web;
using DevExpress.Web.ASPxTreeList;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_TerritorialUnitSearch : BaseControl, IEditScriptabe
{
    private Guid? _regionId
    {
        get { return Storage["SelectedRegionId"] != null ? (Guid?) Storage["SelectedRegionId"] : null; }
        set { Storage["SelectedRegionId"] = value; }
    }

    protected override void DoInitialize(object data, bool loadData)
    {
        base.DoInitialize(data, loadData);
        if (loadData)
        {
            InitCombo(ddlUnits, CreateManager<TerritorialUnitManager>().GetByType(eUnitType.Region), e0Type.All);

            HttpCookie cookie = Request.Cookies["RegionValue_" + UserID];
            if (cookie != null)
            {
                Guid regionId;
                if (Guid.TryParse(cookie.Value, out regionId))
                {
                    ddlUnits.Value = regionId;
                    _regionId = regionId;
                }
            }
        }

        if (loadData || treeUnits.IsCallback)
            BindTree();
    }

    private void BindTree()
    {
        var manager = CreateManager<TerritorialUnitManager>();
        treeUnits.DataSource = _regionId.HasValue
            ? manager.Controller.GetAllByRegion(_regionId.Value)
            : manager.GetAll("UnitType, UnitName");
        treeUnits.DataBind();
    }

    protected void treeUnits_OnCustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        _regionId = GetValue<Guid?>(ddlUnits);
        BindTree();
    }

    protected string GetItemHTML(eUnitType pType, Guid id, string text)
    {
        switch (pType)
        {
            case eUnitType.Locality:
                return string.Format("<a href='#' onclick=\"itemSelection('{0}')\">{1}</a>", id, text);
            default:
                return text;
        }
    }

    public string CancelScript
    {
        set
        {
            btnCancel.ClientSideEvents.Click = jsFunctionOverlay(value);
        }
    }

    public string OKScript { set; private get; }
}