using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class DocumentGroupController: KayflowController<DocumentGroup>
    {
        #region -= Constructors =-

        public DocumentGroupController() : this(null, null, false) { }
        public DocumentGroupController(DocumentGroup model) : this(model, null, false) { }
        public DocumentGroupController(DocumentGroup model, DALCBase parent) : this(model, parent, true) { }
        public DocumentGroupController(DocumentGroup model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}