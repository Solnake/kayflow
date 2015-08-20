using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kayflow.Test
{
    public class TestConfig
    {
        public Guid EmployeeID { get; set; }

        public Guid OfficeID { get; set; }

        public TestConfig(Guid EmployeeId, Guid OfficeId)
        {
            EmployeeID = EmployeeId;
            OfficeID = OfficeId;
        }
    }
}
