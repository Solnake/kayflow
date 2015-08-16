using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActDocumentController: KayflowController<ActDocument>
    {
        #region -= Constructors =-

        public ActDocumentController() : this(null, null, false) { }
        public ActDocumentController(ActDocument model) : this(model, null, false) { }
        public ActDocumentController(ActDocument model, DALCBase parent) : this(model, parent, true) { }
        public ActDocumentController(ActDocument model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select a.*, d.DocumentName, d.OrdNum DocumentOrdNum, d.ValueSetID, d.ShowComments
	                        , g.GroupName, g.OrdNum GroupOrdNum, g.DocumentGroupID
                            , v.DocValue, v.DocColor
							, em.OfficeID
                        from ActDocument a
                        join Document d on d.DocumentID=a.DocumentID
                        join DocumentGroup g on g.DocumentGroupID=d.DocumentGroupID
                        join DocumentValue v on v.DocumentValueID=a.DocumentValueID
						join Act aa on aa.ActID=a.ActID
						join Employee em on em.EmployeeID=aa.EmployeeID
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