using System;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class StepController: KayflowController<Step>
    {
        #region -= Constructors =-

        public StepController() : this(null, null, false) { }
        public StepController(Step model) : this(model, null, false) { }
        public StepController(Step model, DALCBase parent) : this(model, parent, true) { }
        public StepController(Step model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                            select s.*
	                            , aa.ActionName, aa.AlertColor, aa.OrdNum
                                , case
    	                            when isnull(a.AlertDays, 0) > 0 then a.AlertDays
                                    else isnull(a.RelativeAlertDays, 0)
                                    end AlertDays
								, em.OfficeID
                            from Step s
							join Act aaa on aaa.ActID=s.ActID
							join Employee em on em.EmployeeID=aaa.EmployeeID
                            join ActAction aa on aa.ActActionID=s.ActActionID
                            left join 
                        	    (
                            	    select s.StepID
                                	    , case
                                          when isnull(aa.AlertDays, 0) != 0 then DATEDIFF(dd, a.MeteringDate, getdate()) - aa.AlertDays
                                          else null
                                          end AlertDays
                                        , case
                                          when isnull(aa.RelativeAlertDays, 0) != 0 then
                                      	    case 
                                            when (select top 1 st.Received
                                                              from Step st
                                                              join ActAction aat on aat.ActActionID=st.ActActionID
                                                              where
                                                                ActID = s.ActID
                                                                and aat.OrdNum<aa.OrdNum
                                                              order by
                                                                aat.OrdNum desc) is null then null
                                            else DATEDIFF(dd, (select top 1 st.Received
                                                              from Step st
                                                              join ActAction aat on aat.ActActionID=st.ActActionID
                                                              where
                                                                ActID = s.ActID
                                                                and aat.OrdNum<aa.OrdNum
                                                              order by
                                                                aat.OrdNum desc), getdate()) - aa.RelativeAlertDays
	                                         end  
                                          else null
                                          end RelativeAlertDays
                                    from Step s
                                    join ActAction aa on aa.ActActionID=s.ActActionID 
                            	    join Act a on a.ActID=s.ActID
                                    where
                                	    s.Received is null
                                        and (isnull(aa.AlertDays, 0) != 0 or isnull(aa.RelativeAlertDays, 0) != 0)
                                        and aa.AlertColor is not null
                                 ) a on a.StepID=s.StepID     
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

        public void CopyFromActions(Guid pActID, Guid pEmployeeID, Guid pOfficeID)
        {
            StProcedure.ProcedureName = "Step_CopyFromActions";
            StProcedure["@ActID"].Value = pActID;
            StProcedure["@EmployeeID"].Value = pEmployeeID;
            StProcedure["@OfficeID"].Value = pOfficeID;
            StProcedure.ExecuteNonQuery();
        }

    }
}