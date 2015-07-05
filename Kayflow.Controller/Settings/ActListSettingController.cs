using Framework.SqlDataAccess.Controller;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public class ActListSettingController: KayflowController<ActListSetting>
    {
        #region -= Constructors =-

        public ActListSettingController() : this(null, null, false) { }
        public ActListSettingController(ActListSetting model) : this(model, null, false) { }
        public ActListSettingController(ActListSetting model, DALCBase parent) : this(model, parent, true) { }
        public ActListSettingController(ActListSetting model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        #endregion

        #region -= SQL =-
        
        #endregion
        
    }
}