using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;
using System.Linq;

namespace Kayflow.Reports
{
    public partial class ActMainReport : XtraReport
    {
        public Guid OfficeID { get; set; }

        public ActMainReport()
        {
            InitializeComponent();
        }

        private void ActMainReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                tblActs.SuspendLayout();
                tblActSummary.SuspendLayout();
                tblActHeader.SuspendLayout();
                tblActHeader1.SuspendLayout();
                foreach (var item in Factory.Manager<PaymentDataSettingsManager>().GetByOffice(OfficeID))
                {
                    if (item.Show)
                        continue;
                    var column = tblActs.Rows[0].Cells.Cast<XRTableCell>().ToList().Find(
                        c => c.Tag.ToString() == item.PaymentFieldID.ToString());
                    if (column != null)
                        tblActs.DeleteColumn(column);
                    column = tblActSummary.Rows[0].Cells.Cast<XRTableCell>().ToList().Find(
                        c => c.Tag.ToString() == item.PaymentFieldID.ToString());
                    if (column != null)
                        tblActSummary.DeleteColumn(column);
                    column = tblActHeader.Rows[0].Cells.Cast<XRTableCell>().ToList().Find(
                        c => c.Tag.ToString() == item.PaymentFieldID.ToString());
                    if (column != null)
                        tblActHeader.DeleteColumn(column);
                    column = tblActHeader1.Rows[0].Cells.Cast<XRTableCell>().ToList().Find(
                        c => c.Tag.ToString() == item.PaymentFieldID.ToString());
                    if (column != null)
                        tblActHeader1.DeleteColumn(column);
                }
            }
            finally
            {
                tblActs.PerformLayout();
                tblActSummary.PerformLayout();
                tblActHeader.PerformLayout();
                tblActHeader1.PerformLayout();
            }
            foreach (XRTableCell cell in tblActHeader1.Rows[0].Cells)
            {
                cell.Text = (tblActHeader1.Rows[0].Cells.IndexOf(cell) + 1).ToString();
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var color = GetCurrentColumnValue<int?>("AlertColor");
            tblActs.BackColor = color.HasValue ? Color.FromArgb(color.Value) : Color.Transparent;
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var color = DetailReport.GetCurrentColumnValue<int?>("DocColor");
            tblDocument.BackColor = color.HasValue ? Color.FromArgb(color.Value) : Color.Transparent;
        }
    }
}
