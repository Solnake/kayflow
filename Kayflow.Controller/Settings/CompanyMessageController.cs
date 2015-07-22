using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class CompanyMessageController: KayflowController<CompanyMessage>
    {
        #region -= Constructors =-

        public CompanyMessageController() : this(null, null, false) { }
        public CompanyMessageController(CompanyMessage model) : this(model, null, false) { }
        public CompanyMessageController(CompanyMessage model, DALCBase parent) : this(model, parent, true) { }
        public CompanyMessageController(CompanyMessage model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select c.*, o.OfficeName
                        from CompanyMessage c
                        join Office o on o.OfficeID=c.OfficeID
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