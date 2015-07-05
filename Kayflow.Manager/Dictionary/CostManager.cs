using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class CostManager : KayflowManager<CostController, Cost>
    {
        public override List<Cost> GetAll(string orderFieldName, bool hideDeleted)
        {
            Filter.AddCondition("Hidden", eOperationType.Equal, false);
            return base.GetAll(orderFieldName, hideDeleted);
        }
    }
}