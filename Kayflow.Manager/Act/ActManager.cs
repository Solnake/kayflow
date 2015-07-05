using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ActManager : KayflowManager<ActController, Act>
    {
        public Act Save(List<ActDocument> pList)
        {
            return TransactionOverlay(delegate
                {
                    Save();
                    var manager = Factory.Manager<ActDocumentManager>();
                    manager.AssignTransaction(this);
                    var oldList = manager.GetForAct(Model.ID);
                    foreach (var item in pList)
                    {
                        manager.Model = oldList.Find(o => o.DocumentID == item.DocumentID) ?? item;
                        manager.Model.ActID = Model.ID;
                        manager.Model.DocumentValueID = item.DocumentValueID;
                        manager.Save();
                    }
                    foreach (var document in oldList.FindAll(o=>pList.All(l=>l.DocumentID!=o.DocumentID)))
                    {
                        manager.Delete(document.ID);
                    }
                    if (Model.IsNew)
                    {
                        var stepManager = Factory.Manager<StepManager>();
                        stepManager.AssignTransaction(this);
                        stepManager.Controller.CopyFromActions(Model.ID, EmployeeID, OfficeID);
                        var historyManager = CreateManager<ActHistoryManager>();
                        historyManager.AssignTransaction(this);
                        historyManager.Model = new ActHistory
                        {
                            ActID = Model.ID,
                            EmployeeID = EmployeeID,
                            OnDate = DateTime.Now,
                            Description = string.Format("Створив акт із датою виїзду '{0}'", Model.MeteringDate.ToShortDateString())
                        };
                        historyManager.Save();
                    }
                    return Model;
                });
        }
    }
}