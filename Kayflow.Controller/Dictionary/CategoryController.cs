using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class CategoryController: KayflowController<Category>
    {
        #region -= Constructors =-

        public CategoryController() : this(null, null, false) { }
        public CategoryController(Category model) : this(model, null, false) { }
        public CategoryController(Category model, DALCBase parent) : this(model, parent, true) { }
        public CategoryController(Category model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}