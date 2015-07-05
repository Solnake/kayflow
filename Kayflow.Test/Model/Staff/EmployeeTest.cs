using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kayflow.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kayflow.Test.Model.Staff
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Test_IsAdmin()
        {
            var employee = getEmployeeWithPermissions(ePermissions.Employee);
            Assert.IsFalse(employee.IsAdmin);
            employee = getEmployeeWithPermissions(ePermissions.Admin);
            Assert.IsTrue(employee.IsAdmin);
            employee.IsAdmin = true;
            Assert.IsTrue(employee.IsAdmin);
            employee.SuperAdmin = true;
            Assert.IsTrue(employee.IsAdmin);
            employee.IsBlocked = true;
            Assert.IsTrue(employee.IsAdmin);
            employee.IsAdmin = false;
            Assert.IsFalse(employee.IsAdmin);
        }

        private Employee getEmployeeWithPermissions(ePermissions permissions)
        {
            var employee = new Employee
            {
                Permission = permissions
            };
            return employee;
        }
    }
}
