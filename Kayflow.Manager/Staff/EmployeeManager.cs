using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class EmployeeManager : KayflowManager<EmployeeController, Employee>
    {
        public override Employee Save()
        {
            Filter.Clear();
            Filter.AddCondition("Login", eOperationType.Equal, Model.Login);
            Filter.AddCondition("EmployeeID", eOperationType.NotEqual, Model.ID);
            if (GetAll().Any())
                throw new CustomException("Користувач із логіном {0} вже існує", Model.Login);
            return base.Save();
        }

        public Employee SaveWithOffices(IEnumerable<EmployeeOffices> officeses)
        {
            return TransactionOverlay(delegate
            {
                Save();
                var manager = CreateManager<EmployeeOfficesManager>();
                manager.Controller.DeleteByEmployeeID(Model.ID);
                foreach (var office in officeses)
                {
                    office.EmployeeID = Model.ID;
                    manager.Model = office;
                    manager.Save();
                }
                return Model;
            });
        }

        public override List<Employee> GetByOffice(Guid pOfficeID)
        {
            return Controller.GetAllByOffice(pOfficeID);
        }

        public Employee CheckLogin(string pLogin, string pPassword, Guid pOfficeID)
        {
            Filter.AddCondition("Login", eOperationType.Equal, pLogin);
            Filter.AddCondition("Password", eOperationType.Equal, pPassword);
            if (pOfficeID != Guid.Empty)
                Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll().FirstOrDefault();
        }

        public void DeleteAllInOffice(Guid pOfficeID)
        {
            foreach (var employee in GetByOffice(pOfficeID))
            {
                try
                {
                    Delete(employee.ID);
                }
                catch
                {

                }
            }
        }
    }
}