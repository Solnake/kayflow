﻿using System;
using DevExpress.Web;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_AdminControls_OfficeList : BaseListControl<OfficeManager, OfficeController, Office>
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
        return "офіс";
    }

    protected override void gvItems_BeforePerformDataSelect(object sender, EventArgs e)
    {
        gridList.DataSource = CreateManager<OfficeManager>().GetAll();
    }
}