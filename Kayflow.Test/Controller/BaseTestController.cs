using System;
using System.Configuration;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;

namespace Kayflow.Test.Controller
{
    public class BaseTestController
    {
        protected Guid CurrentEmployeeID { get; set; }

        protected Guid CurrentOfficeID { get; set; }

        static BaseTestController()
        {
            Factory.AddConnection("Kayflow", ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        }

        #region -= Factory =-
        public T CreateController<T>()
            where T : Framework.SqlDataAccess.Controller.DALCBase
        {
            return CreateController<T>(null, null);
        }

        public T CreateController<T>(AbstractModel model)
            where T : Framework.SqlDataAccess.Controller.DALCBase
        {
            return CreateController<T>(model, null);
        }

        public virtual T CreateController<T>(AbstractModel model, Framework.SqlDataAccess.Controller.DALCBase parent)
            where T : Framework.SqlDataAccess.Controller.DALCBase
        {
            var result = Factory.Controller<T>(parent);
            if (result is Framework.SqlDataAccess.Controller.ICompany)
            {
                (result as Framework.SqlDataAccess.Controller.ICompany).UpdateDate = DateTime.Now;
            }
            return result;
        }

        public M CreateManager<M>()
            where M : IManager
        {
            var result = Factory.Manager<M>();
            if (result.DALCInfo is Framework.SqlDataAccess.Controller.ICompany)
            {
                (result.DALCInfo as Framework.SqlDataAccess.Controller.ICompany).UpdateDate = DateTime.Now;
            }
            var visitor = result as IOfficeData;
            if (visitor != null && CurrentEmployeeID != Guid.Empty)
            {
                visitor.EmployeeID = CurrentEmployeeID;
                if (CurrentOfficeID != Guid.Empty)
                    visitor.OfficeID = CurrentOfficeID;
            }
            return result;
        }

        #endregion
        
    }
}
