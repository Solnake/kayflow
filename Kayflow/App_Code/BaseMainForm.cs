using System;
using DevExpress.XtraBars.Ribbon;
using Kayflow.Model;

namespace Kayflow
{
    public class BaseMainForm : RibbonForm, ICurrentInfo
    {
        public Guid OfficeID { get; set; }
        public Guid EmployeeID { get; set; }
        public ePermissions Permission { get; set; }
        public Employee CurrentEmployee { get; set; }

        public virtual void RefreshOffice()
        {

        }
    }
}
