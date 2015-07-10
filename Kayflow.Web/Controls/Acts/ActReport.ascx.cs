using System.Collections.Generic;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Reports;

public partial class Controls_Acts_ActReport : BaseControl
{
    protected override void DoInitialize_1_BeforeLoadData()
    {
        base.DoInitialize_1_BeforeLoadData();
        var collection = new ActCollection();
        List<Act> list = CreateManager<ActManager>().Controller.GetByOfficeEx(CurrentOffice.ID);
        collection.BindWithDocuments(list);
        var report = new ActMainReport
        {
            DataSource = collection,
            OfficeID = CurrentOffice.ID
        };
        dvReport.Report = report;
        dvReport.DataBind();
    }
}