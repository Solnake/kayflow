using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Framework.SqlDataAccess.Model;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public interface IManagerDataSource : IManager
    {
        object Retrieve();
    }

    public interface IOfficeData : IManager
    {
        Guid OfficeID { get; set; }
        Guid EmployeeID { get; set; }
    }

    public delegate void ExceptionCheckDelegate();

    public abstract class KayflowManager<TC, TM> : ManagerBase<TC, TM>, IManagerDataSource, IOfficeData
        where TC : ReadWriteControllerSinglePK<TM, Guid>, new()
        where TM : BaseModel, new()
    {
        public CustomFilter Filter { get { return Controller.Filter; } }

        public virtual TM InitializeModel(Guid id)
        {
            TM model = Model ?? Controller.Get(id) ?? new TM();
            if (Model == null)
                Model = model;
            return model;
        }

        public TM Fill(TM pModel)
        {
            var model = Model ?? new TM();
            if (pModel!=null)
            {
                var members = from x in typeof(TM).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly)
                              select new
                              {
                                  mi = x,
                                  map = (DBMaping)Attribute.GetCustomAttribute(x, typeof(DBMaping))
                              };
                foreach (var member in members.Where(x => x.map != null))
                {
                    var propertyInfo = member.mi as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(model, propertyInfo.GetValue(pModel, null), null);
                    }
                    else
                    {
                        var fieldInfo = member.mi as FieldInfo;
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(model, fieldInfo.GetValue(pModel));
                        }
                    }
                }
            }
            Model = model;
            return model;
        }

        public virtual TM Save()
        {
            Validate();
            return Controller.Save();
        }

        public virtual void Delete()
        {
            Controller.Delete();
        }
        public virtual void Delete(Guid id)
        {
            Controller.Delete(id);
        }

        public List<TM> GetAll()
        {
            return GetAll(null, true);
        }
        public List<TM> GetAll(string orderFieldName)
        {
            return GetAll(orderFieldName, true);
        }
        public virtual List<TM> GetAll(string orderFieldName, bool hideDeleted)
        {
            return Controller.GetAll(orderFieldName, hideDeleted);
        }

        public virtual List<TM> GetByOffice(Guid pOfficeID)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return GetAll(Controller.NameFieldName);
        }

        public virtual List<TM> GetForDictionary(Guid pOfficeID)
        {
            Filter.AddCondition("OfficeID", eOperationType.Equal, pOfficeID);
            return Controller.GetAll(Controller.NameFieldName);
        }

        public T TransactionOverlay<T>(TransactionOverlayDeleagate<T> executingMethod)
        {
            return Controller.TransactionOverlay(executingMethod);
        }
        public void TransactionOverlay(TransactionOverlayDeleagate executingMethod)
        {
            Controller.TransactionOverlay(executingMethod);
        }

        #region IManagerDataSource Members

        public object Retrieve()
        {
            return GetByOffice(OfficeID);
        }

        #endregion

        #region Implementation of IVisitor

        public Guid OfficeID { get; set; }
        public Guid EmployeeID { get; set; }

        #endregion

        protected M CreateManager<M>()
            where M : IManagerDataSource, IOfficeData, new()
        {
            var manager = Factory.Manager<M>();
            manager.OfficeID = OfficeID;
            manager.EmployeeID = EmployeeID;
            manager.DALCInfo.Transaction = DALCInfo.Transaction;
            return manager;
        }
    }

    public abstract class KayflowMultiManager<TC, TM> : ManagerBase<TC, TM>, IManagerDataSource, IOfficeData
        where TC : ReadWriteControllerMultiPK<TM, Guid, Guid>, new()
        where TM : ModelBaseMultiPK, new()
    {
        public CustomFilter Filter { get { return Controller.Filter; } }

        public virtual TM InitializeModel(Guid id1, Guid id2)
        {
            TM model = Model ?? Controller.Get(id1, id2) ?? new TM();
            if (Model == null)
                Model = model;
            return model;
        }

        public TM Fill(TM pModel)
        {
            var model = Model ?? new TM();
            if (pModel != null)
            {
                var members = from x in typeof(TM).GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly)
                              select new
                              {
                                  mi = x,
                                  map = (DBMaping)Attribute.GetCustomAttribute(x, typeof(DBMaping))
                              };
                foreach (var member in members.Where(x => x.map != null))
                {
                    var propertyInfo = member.mi as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(model, propertyInfo.GetValue(pModel, null), null);
                    }
                    else
                    {
                        var fieldInfo = member.mi as FieldInfo;
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(model, fieldInfo.GetValue(pModel));
                        }
                    }
                }
            }
            Model = model;
            return model;
        }

        public virtual TM Save()
        {
            Validate();
            return Controller.Save();
        }

        public virtual void Delete()
        {
            Controller.Delete();
        }
        public virtual void Delete(Guid id1, Guid id2)
        {
            Controller.Delete(id1, id2);
        }

        public List<TM> GetAll()
        {
            return GetAll(null, true);
        }
        public List<TM> GetAll(string orderFieldName)
        {
            return GetAll(orderFieldName, true);
        }
        public virtual List<TM> GetAll(string orderFieldName, bool hideDeleted)
        {
            return Controller.GetAll(orderFieldName, hideDeleted);
        }

        public object Retrieve()
        {
            throw new NotImplementedException();
        }

        public Guid OfficeID { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
