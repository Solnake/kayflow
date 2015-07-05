using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Framework.SqlDataAccess.Manager;
using log4net.Config;

namespace Kayflow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Factory.AddConnection("Kayflow", ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            Factory.AddConnection("LongTime", ConfigurationManager.ConnectionStrings["LongTimeConnectionString"].ToString());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            XmlConfigurator.Configure();
            Application.ThreadException += ApplicationOnThreadException;
            Application.Run(new LoginContext());
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
