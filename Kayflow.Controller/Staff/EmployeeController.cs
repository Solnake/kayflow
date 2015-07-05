using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class EmployeeController: KayflowController<Employee>
    {
        #region -= Constructors =-

        public EmployeeController() : this(null, null, false) { }
        public EmployeeController(Employee model) : this(model, null, false) { }
        public EmployeeController(Employee model, DALCBase parent) : this(model, parent, true) { }
        public EmployeeController(Employee model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT * FROM vEmployee ";
            }
        }        

        protected override string m_GetQueryTemplate
        {
            get
            {
                return m_GetAllQueryTemplate + "where {1} = @{1}";
            }
        }

        private const string q_SelectByOffice = @"select e.*
                            from vEmployee e
                            join EmployeeOffices o on o.EmployeeID=e.EmployeeID
                            where
	                            o.OfficeID = @OfficeID
                            order by Permission, LastName, FirstName, MiddleName";

        #endregion

        public List<Employee> GetAllByOffice(Guid officeId)
        {
            StProcedure.Query = q_SelectByOffice;
            StProcedure["@OfficeID"].Value = officeId;
            return StProcedure.ExecuteListAttr<Employee>();
        }

    }
}