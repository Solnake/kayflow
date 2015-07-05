using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow
{
    public class LoginContext : ApplicationContext
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginContext()
        {
            var employees = new List<Employee>();
            var errorDB = false;
            try
            {
                employees = Factory.Manager<EmployeeManager>().GetAll();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                errorDB = true;
                MessageBox.Show(Resources.errorDBConnection,
                                   Application.ProductName,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }

            if (employees.Any())
            {
                var frm = new frmLogin();
                frm.SaveComplited += SaveComplited;
                frm.Closed += FrmOnClosed;
                frm.ShowDialog();
            }
            else
            {
                var frmMain = new frmMainForm {ErrorDB = errorDB};
                MainForm = frmMain;
                frmMain.Show();
            }
        }

        private void FrmOnClosed(object sender, EventArgs eventArgs)
        {
            if (sender is frmLogin)
            {
                if ((sender as frmLogin).DialogResult != DialogResult.OK)
                    Application.Exit();
            }
        }

        private void SaveComplited(object sender, EventArgs eventArgs)
        {
            var dialog = sender as BaseEditForm;
            if (dialog != null && dialog.Model is Employee)
            {
                var frmMain = new frmMainForm
                    {
                        EmployeeID = dialog.DocID, 
                        Permission = (dialog.Model as Employee).Permission,
                        CurrentEmployee = dialog.Model as Employee
                    };
                MainForm = frmMain;
                frmMain.Show();
            }
        }
    }
}
