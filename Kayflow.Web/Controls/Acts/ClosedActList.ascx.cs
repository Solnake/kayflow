using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Manager;
using Kayflow.Model;

public partial class Controls_Acts_ClosedActList : BaseControl
{
    protected List<Act> ActList_OnGetDataSource(object sender, EventArgs e)
    {
        var manager = CreateManager<ActManager>();
        return manager.Controller.GetByStatusForEmployeeEx(CurrentOffice.ID, true);
    }
}