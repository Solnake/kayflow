using System;
using Kayflow.Model;

namespace Kayflow
{
    public interface ICurrentInfo
    {
        Guid OfficeID { get; set; }
        Guid EmployeeID { get; set; }
        ePermissions Permission { get; set; }
        void RefreshOffice();
    }
}
