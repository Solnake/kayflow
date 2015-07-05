using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Kayflow.Reports
{
    public partial class StepReport : XtraReport
    {
        public StepReport()
        {
            InitializeComponent();
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (fDataBrowser.HasLastPosition)
                e.Cancel = true;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var color = GetCurrentColumnValue<int?>("AlertColor");
            tblActs.BackColor = color.HasValue ? Color.FromArgb(color.Value) : Color.Transparent;
        }

        private void detailSteps_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var color = DetailReport.GetCurrentColumnValue<int?>("AlertColor");
            var days = DetailReport.GetCurrentColumnValue<int?>("AlertDays");
            tblSteps.BackColor = color.HasValue && days.HasValue && days.Value > 0
                                     ? Color.FromArgb(color.Value)
                                     : Color.Transparent;
        }

    }
}
