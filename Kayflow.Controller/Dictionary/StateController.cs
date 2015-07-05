using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class StateController: KayflowController<State>
    {
        #region -= Constructors =-

        public StateController() : this(null, null, false) { }
        public StateController(State model) : this(model, null, false) { }
        public StateController(State model, DALCBase parent) : this(model, parent, true) { }
        public StateController(State model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}