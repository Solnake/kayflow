using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class DocumentController: KayflowController<Document>
    {
        #region -= Constructors =-

        public DocumentController() : this(null, null, false) { }
        public DocumentController(Document model) : this(model, null, false) { }
        public DocumentController(Document model, DALCBase parent) : this(model, parent, true) { }
        public DocumentController(Document model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select d.*, v.SetName, g.GroupName, g.OfficeID, g.OrdNum GroupOrdNum
                        from Document d
                        join ValueSet v on v.ValueSetID=d.ValueSetID
                        join DocumentGroup g on g.DocumentGroupID=d.DocumentGroupID
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