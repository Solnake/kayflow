using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ValueSetController : KayflowController<ValueSet>
    {
        #region constructors

        public ValueSetController() : this(null, null, false) { }
        public ValueSetController(ValueSet model) : this(model, null, false) { }
        public ValueSetController(ValueSet model, DALCBase parent) : this(model, parent, true) { }
        public ValueSetController(ValueSet model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region SQL
        
        #endregion
        
    }
}