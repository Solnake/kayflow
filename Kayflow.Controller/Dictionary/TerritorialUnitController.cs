using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class TerritorialUnitController: KayflowController<TerritorialUnit>
    {
        #region -= Constructors =-

        public TerritorialUnitController() : this(null, null, false) { }
        public TerritorialUnitController(TerritorialUnit model) : this(model, null, false) { }
        public TerritorialUnitController(TerritorialUnit model, DALCBase parent) : this(model, parent, true) { }
        public TerritorialUnitController(TerritorialUnit model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-

        protected override string m_GetAllQueryTemplate
        {
            get
            {
                return @"
                    SELECT *
                    FROM (
                        select u.*
	                        , p.UnitType ParentUnitType, p.UnitName ParentUnitName
                        from TerritorialUnit u
                        left join TerritorialUnit p on p.TerritorialUnitID=u.ParentID
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

        private const string q_GetAllByOfficeQuery = @"SELECT *
                    FROM (
                        select u.*
	                        , p.UnitType ParentUnitType, p.UnitName ParentUnitName
                        from TerritorialUnit u
                        left join TerritorialUnit p on p.TerritorialUnitID=u.ParentID
                        join OfficeTerritorialUnit o on o.TerritorialUnitID=u.TerritorialUnitID
                        where
                        	o.OfficeID = @OfficeID
                    ) x
                    WHERE 1=1 ";

        private const string q_GetAllByRegion = @"
                        with UnitList as 
                                (

                                select u.TerritorialUnitID, u.ParentID, u.UnitName, u.UnitType, u.OfficeID, 1 Level
                                from TerritorialUnit u
                                where
	                                u.ParentID is null
                                    and u.TerritorialUnitID = @TerritorialUnitID
    
                                union all
                                select u.TerritorialUnitID, u.ParentID, u.UnitName, u.UnitType, u.OfficeID, p.Level + 1
                                from TerritorialUnit u   
                                join UnitList p on u.ParentID=p.TerritorialUnitID
                                where
	                                u.ParentID is not null
                                )   
                                select TerritorialUnitID, ParentID, UnitName, UnitType, OfficeID
                                from UnitList";

        #endregion

        public List<TerritorialUnit> GetAllByOffice(Guid officeId)
        {
            StProcedure.Query = q_GetAllByOfficeQuery + Filter;
            StProcedure["@OfficeID"].Value = officeId;
            Filter.UpdateParams();
            return StProcedure.ExecuteListAttr<TerritorialUnit>();
        }

        public List<TerritorialUnit> GetAllByRegion(Guid regionId)
        {
            StProcedure.Query = q_GetAllByRegion;
            StProcedure["@TerritorialUnitID"].Value = regionId;
            return StProcedure.ExecuteListAttr<TerritorialUnit>();
        }
        
    }
}