using System;
using System.Collections.Generic;
using System.Configuration;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Manager;

namespace Kayflow.Test.Controller
{
    public class BaseTestController
    {
        static BaseTestController()
        {
            Factory.AddConnection("Kayflow", ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
            InitConfig();
        }

        protected static Dictionary<int, TestConfig> OfficeConfig { get; set; }

        private static void InitConfig()
        {
            OfficeConfig = new Dictionary<int, TestConfig>
            {
                {
                    0,
                    new TestConfig(Guid.Parse("{228415EC-AAA5-46CA-953B-766E8B9D4256}"),
                        Guid.Parse("{59FC2527-606D-4EC4-8F34-1BEC74DC856E}"))
                }
            };
        }

        #region -= Factory =-

        public T CreateController<T>()
            where T : DALCBase
        {
            return CreateController<T>(null, null);
        }

        public T CreateController<T>(AbstractModel model)
            where T : DALCBase
        {
            return CreateController<T>(model, null);
        }

        public virtual T CreateController<T>(AbstractModel model, DALCBase parent)
            where T : DALCBase
        {
            var result = Factory.Controller<T>(parent);
            if (result is ICompany)
            {
                (result as ICompany).UpdateDate = DateTime.Now;
            }

            return result;
        }

        public M CreateManager<M>(int configIndex = 0)
            where M : IManager
        {
            if (!OfficeConfig.ContainsKey(configIndex))
                throw new NullReferenceException("Config with defined index doesn't exist.");

            var result = Factory.Manager<M>();
            var info = result.DALCInfo as ICompany;
            if (info != null)
            {
                info.UpdateDate = DateTime.Now;
            }

            var visitor = result as IOfficeData;
            if (visitor != null)
            {
                var config = OfficeConfig[configIndex];
                visitor.EmployeeID = config.EmployeeID;
                visitor.OfficeID = config.OfficeID;
            }

            return result;
        }

        #endregion
    }
}