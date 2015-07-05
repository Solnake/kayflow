using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Controller;
using Kayflow.Manager;
using Kayflow.Model;
using Kayflow.Properties;

namespace Kayflow
{
    public partial class BaseEditForm : Form
    {
        protected static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Guid DocID { get; set; }
        public EventHandler SaveComplited;
        public ModelBaseSinglePK<Guid> Model { get; private set; }
        public ICurrentInfo CurrentInfo { get; set; }

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected virtual void BaseEditForm_Load(object sender, EventArgs e)
        {
            LoadData();
            AttachEventHandlers();
            Update_Actions(this, EventArgs.Empty);
            validationProvider.Validate();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ModelBaseSinglePK<Guid> model;
            try
            {
                model = DoSave();
            }
            catch(CustomException exception)
            {
                Log.Warn(exception.Message, exception);
                MessageBox.Show(exception.Message,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message, exception);
                MessageBox.Show(Resources.saveError,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            if (model != null)
            {
                DocID = model.ID;
                Model = model;
            }
            if (SaveComplited != null)
                SaveComplited(this, EventArgs.Empty);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected virtual BaseModel DoSave()
        {
            return null;
        }

        protected virtual void LoadData()
        {

        }

        protected virtual void AttachEventHandlers()
        {
            
        }

        protected void Update_Actions(object sender, EventArgs e)
        {
            btnSave.Enabled = IsAllowSave();
        }

        protected virtual bool IsAllowSave()
        {
            return true;
        }

        #region -= GetValue =-
        protected T GetValueEx<T>(TextEdit pEdit)
        {
            var utype = Nullable.GetUnderlyingType(typeof(T));
            var etype = (utype ?? typeof(T)).BaseType != typeof(Enum) ? null : Enum.GetUnderlyingType(utype ?? typeof(T));
            if (etype != null)
                return (T)Enum.ToObject(utype ?? typeof(T), pEdit.EditValue);
            return (T)Convert.ChangeType(pEdit.EditValue, utype ?? typeof(T));
        }

        protected T GetValue<T>(TextEdit pEdit)
        {
            return typeof(T) == typeof(string) ? GetValueEx<T>(pEdit) : GetValue(pEdit, Activator.CreateInstance<T>());
        }

        protected T GetValue<T>(TextEdit pEdit, T defaultValue)
        {
            return pEdit.EditValue == null ? defaultValue : GetValueEx<T>(pEdit);
        } 
        #endregion

        protected class ListEditItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
        }

        protected List<ListEditItem> GetListEditItemCollection<T>()
        where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Method 'GetListEditItemCollection<T>' used for enums only!");
            var utype = Enum.GetUnderlyingType(typeof(T));
            return (from Enum value in Enum.GetValues(typeof (T))
                    select new ListEditItem
                        {
                            Text = value.GetNameEx(),
                            Value = Convert.ChangeType(value, utype)
                        }).ToList();
        }

        protected virtual void BaseEditForm_Shown(object sender, EventArgs e)
        {

        }

        protected TM CreateManager<TM>()
            where TM : IManagerDataSource, IOfficeData, new()
        {
            var manager = Factory.Manager<TM>();
            manager.OfficeID = CurrentInfo.OfficeID;
            manager.EmployeeID = CurrentInfo.EmployeeID;
            return manager;
        }
    }
}
