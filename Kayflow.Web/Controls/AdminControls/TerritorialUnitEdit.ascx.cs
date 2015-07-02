using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_TerritorialUnitEdit : BaseEditControl<TerritorialUnitManager, TerritorialUnitController, TerritorialUnit>
{
    private eUnitType? unitType
    {
        get { return Storage["unitType"] != null ? (eUnitType?) Storage["unitType"] : null; }
        set { Storage["unitType"] = value; }
    }

    private eUnitType? parentUnitType
    {
        get { return Storage["parentUnitType"] != null ? (eUnitType?)Storage["parentUnitType"] : null; }
        set { Storage["parentUnitType"] = value; }
    }

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

    protected override void DoInitialize_2_LoadDataInitControls()
    {
        base.DoInitialize_2_LoadDataInitControls();
        InitComboEnum<eUnitType>(ddlUnitType, e0Type.PlsSelect);
    }

    protected override void InitControlsByModelData(TerritorialUnit model)
    {
        if (model.ParentUnitType.HasValue)
        {
            InitComboEnum(ddlParentUnitType, e0Type.DontNeed, GetEnumList<eUnitType>().FindAll(
                u => (int)u >= (int)model.UnitType));
            BindParentUnit(model.ParentUnitType);
        }

        base.InitControlsByModelData(model);
        if (!model.IsNew)
        {
            unitType = model.UnitType;
            parentUnitType = model.ParentUnitType;
        }
    }

    protected override void LoadModelDataFromControls(TerritorialUnit model)
    {
        if (model.IsNew)
        {
            model.OfficeID = CurrentOffice.OfficeID;
        }

        model.ParentID = GetValue<Guid?>(ddlParentUnit);
        model.UnitName = GetValue<string>(txtUnitName);
        model.UnitType = GetValue<eUnitType>(ddlUnitType);
    }

    protected void ddlParentUnitType_OnCallback(object sender, CallbackEventArgsBase e)
    {
        unitType = GetValue<eUnitType?>(ddlUnitType);
        parentUnitType = null;
        InitComboEnum(ddlParentUnitType, e0Type.DontNeed, GetEnumList<eUnitType>().FindAll(
            u => (int) u >= (unitType.HasValue ? (int) unitType.Value : 0)));
    }

    protected void ddlParentUnit_OnCallback(object sender, CallbackEventArgsBase e)
    {
        parentUnitType = GetValue<eUnitType?>(ddlParentUnitType);
        BindParentUnit(parentUnitType);
    }

    private void BindParentUnit(eUnitType? parentUnit)
    {
        if (parentUnit.HasValue)
        {
            InitCombo(ddlParentUnit,
                CreateManager<TerritorialUnitManager>().GetByType(parentUnit.Value), e0Type.DontNeed);
        }
        else
        {
            ddlParentUnit.DataSource = null;
        }
    }

    protected void ddlParentUnitType_Init(object sender, EventArgs e)
    {
        if (unitType.HasValue)
            InitComboEnum(ddlParentUnitType, e0Type.DontNeed, GetEnumList<eUnitType>().FindAll(
                u => (int) u >= (int) unitType.Value));
    }

    protected void ddlParentUnit_OnInit(object sender, EventArgs e)
    {
        BindParentUnit(parentUnitType);
    }
}