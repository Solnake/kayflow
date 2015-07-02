using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class LayoutController: KayflowController<Layout>
    {
        #region -= Constructors =-

        public LayoutController() : this(null, null, false) { }
        public LayoutController(Layout model) : this(model, null, false) { }
        public LayoutController(Layout model, DALCBase parent) : this(model, parent, true) { }
        public LayoutController(Layout model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        

        #endregion
        
    }
}