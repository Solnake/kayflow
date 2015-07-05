using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_ActListSettingList : BaseControl
{
    private List<ActListSettingItem> _settings;

    protected override void DoInitialize_3_LoadDataMain()
    {
        base.DoInitialize_3_LoadDataMain();
        gridList.DataBind();
        foreach (var item in _settings.FindAll(s=>s.Show))
        {
            gridList.Selection.SelectRowByKey(item.FieldName);
        }
    }

    protected void gridList_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        var list = CreateManager<ActListSettingManager>().GetByOffice(CurrentOffice.ID);
        _settings = list != null ? list.DisplayFields : new ActListSetting().DisplayFields;
        gridList.DataSource = _settings;
    }

    protected void gridList_OnCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var manager = CreateManager<ActListSettingManager>();
        var model = manager.GetByOffice(CurrentOffice.ID) ?? new ActListSetting {OfficeID = CurrentOffice.ID};
        model.DisplayFields = gridList.GetSelectedFieldValues("FieldName").Select(
            f => new ActListSettingItem
            {
                FieldName = f.ToString(),
                Show = true
            }).ToList();
        manager.Model = model;
        if (string.IsNullOrEmpty(model.Fields) && !model.IsNew)
            manager.Delete(model.ID);
        else
            manager.Save();
    }
}