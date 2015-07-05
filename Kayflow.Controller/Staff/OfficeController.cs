using System;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class OfficeController: KayflowController<Office>
    {
        #region -= Constructors =-

        public OfficeController() : this(null, null, false) { }
        public OfficeController(Office model) : this(model, null, false) { }
        public OfficeController(Office model, DALCBase parent) : this(model, parent, true) { }
        public OfficeController(Office model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion

    }
}