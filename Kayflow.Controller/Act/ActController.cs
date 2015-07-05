using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActController: KayflowController<Act>
    {
        #region -= Constructors =-

        public ActController() : this(null, null, false) { }
        public ActController(Act model) : this(model, null, false) { }
        public ActController(Act model, DALCBase parent) : this(model, parent, true) { }
        public ActController(Act model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"select * from f_acts() ";
            }
        }        

        protected override string m_GetQueryTemplate
        {
            get
            {
                return m_GetAllQueryTemplate + "where {1} = @{1}";
            }
        }
        
        #endregion
        
    }
}