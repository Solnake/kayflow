using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActActionController: KayflowController<ActAction>
    {
        #region -= Constructors =-

        public ActActionController() : this(null, null, false) { }
        public ActActionController(ActAction model) : this(model, null, false) { }
        public ActActionController(ActAction model, DALCBase parent) : this(model, parent, true) { }
        public ActActionController(ActAction model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select a.*, o.OfficeName
                        from ActAction a
                        join Office o on o.OfficeID=a.OfficeID
                    ) x
                ";
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