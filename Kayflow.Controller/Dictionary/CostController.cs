using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class CostController: KayflowController<Cost>
    {
        #region -= Constructors =-

        public CostController() : this(null, null, false) { }
        public CostController(Cost model) : this(model, null, false) { }
        public CostController(Cost model, DALCBase parent) : this(model, parent, true) { }
        public CostController(Cost model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}