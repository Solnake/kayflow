using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_ActListSettingEdit : BaseEditControl<ActListSettingManager, ActListSettingController, ActListSetting>
{
    private List<ActListSettingItem> _settings;

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

    protected override object DoSave(object data)
    {
        object result = null;
        ExceptionCheck(delegate
        {
            var manager = CreateManager<ActListSettingManager>();
            var model = manager.GetByEmployee(CurrentOffice.ID, CurrentEmployee.ID) ??
                        new ActListSetting {OfficeID = CurrentOffice.ID, EmployeeID = CurrentEmployee.ID};
            LoadModelDataFromControls(model);
            manager.Model = model;
            if (string.IsNullOrEmpty(model.Fields))
                manager.Delete(model.ID);
            else
                manager.Save();
            result = manager.Model;
        });
        return result;
    }

    protected override void InitControlsByModelData(ActListSetting model)
    {
        base.InitControlsByModelData(model);
        gridList.DataBind();
        foreach (var item in _settings.FindAll(s => s.Show))
        {
            gridList.Selection.SelectRowByKey(item.FieldName);
        }
    }

    protected override void LoadModelDataFromControls(ActListSetting model)
    {
        model.DisplayFields = gridList.GetSelectedFieldValues("FieldName").Select(
            f => new ActListSettingItem
            {
                FieldName = f.ToString(),
                Show = true
            }).ToList();
    }

    protected void gridList_OnBeforePerformDataSelect(object sender, EventArgs e)
    {
        var list = CreateManager<ActListSettingManager>().GetByEmployee(CurrentOffice.ID, CurrentEmployee.ID);
        _settings = list != null ? list.DisplayFields : new ActListSetting().DisplayFields;
        gridList.DataSource = _settings;
    }
}