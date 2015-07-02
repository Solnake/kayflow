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
        manager.Filter.AddCondition("IsClosed", eOperationType.Equal, true);
        return manager.GetByOffice(CurrentOffice.ID);
    }
}