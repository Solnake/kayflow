using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class NoteController: KayflowController<Note>
    {
        #region -= Constructors =-

        public NoteController() : this(null, null, false) { }
        public NoteController(Note model) : this(model, null, false) { }
        public NoteController(Note model, DALCBase parent) : this(model, parent, true) { }
        public NoteController(Note model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select n.*, e.DisplayName EmployeeName, em.OfficeID
                        from Note n
						join Act a on a.ActID=n.ActID
						join Employee em on em.EmployeeID=a.EmployeeID
						join vEmployee e on e.EmployeeID=n.EmployeeID
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