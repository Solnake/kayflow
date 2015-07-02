using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class DocumentValueController: KayflowController<DocumentValue>
    {
        #region -= Constructors =-

        public DocumentValueController() : this(null, null, false) { }
        public DocumentValueController(DocumentValue model) : this(model, null, false) { }
        public DocumentValueController(DocumentValue model, DALCBase parent) : this(model, parent, true) { }
        public DocumentValueController(DocumentValue model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}