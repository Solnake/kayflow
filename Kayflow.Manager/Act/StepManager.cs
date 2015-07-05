using System;
using System.Collections.Generic;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class StepManager : KayflowManager<StepController, Step>
    {
        public List<Step> GetForAct(Guid pActID)
        {
            Filter.AddCondition("ActID", eOperationType.Equal, pActID);
            return GetAll("OrdNum");
        }

        public override Step Save()
        {
            return TransactionOverlay<Step>(SaveHandler);
        }

        private Step SaveHandler()
        {
            base.Save();
            var manager = Factory.Manager<ActHistoryManager>();
            manager.AssignTransaction(this);
            manager.Model = new ActHistory
                {
                    OnDate = DateTime.Now,
                    EmployeeID = EmployeeID,
                    ActID = Model.ActID
                };
            var model = Model.DBReceivedData as Step;
            if (model==null)
            {
                manager.Model.Description = "Встановив дату '" + Model.ActionName + "' ";
                if (Model.Delivered.HasValue)
                    manager.Model.Description = string.Format("видачі {0} ", Model.Delivered.Value.ToShortDateString());
                if (Model.Received.HasValue)
                {
                    string add = Model.Delivered.HasValue
                              ? "та отримання {0}"
                              : "отримання {0}";
                    manager.Model.Description += string.Format(add, Model.Received.Value.ToShortDateString());
                }
            }
            else
            {
                string description = string.Empty;
                if (Model.Delivered != model.Delivered)
                {
                    description = string.Format(" видачі (із {0} на {1})",
                                                model.Delivered.HasValue
                                                    ? model.Delivered.Value.ToShortDateString()
                                                    : "'-//-'",
                                                Model.Delivered.HasValue
                                                    ? Model.Delivered.Value.ToShortDateString()
                                                    : "'-//-'");
                }
                if (Model.Received != model.Received)
                {
                    if (!string.IsNullOrEmpty(description))
                        description += " та";
                    description += string.Format(" отримання (із {0} на {1})",
                                                 model.Received.HasValue
                                                     ? model.Received.Value.ToShortDateString()
                                                     : "'-//-'",
                                                 Model.Received.HasValue
                                                     ? Model.Received.Value.ToShortDateString()
                                                     : "'-//-'");
                }
                if (!string.IsNullOrEmpty(description))
                    manager.Model.Description = string.Format("Змінив етап '{0}' - дату {1}", model.ActionName,
                                                              description);
            }
            if (!string.IsNullOrEmpty(manager.Model.Description))
                manager.Save();
            return Model;
        }

        public void SaveAll(List<Step> pSteps)
        {
            TransactionOverlay(delegate
                {
                    foreach (var step in pSteps)
                    {
                        Model = step;
                        Save();
                    }
                });
            
        }

        public void SaveAll(List<Step> pSteps, StateHistory pHistory, Note pNote)
        {
            TransactionOverlay(delegate
                                   {
                                       SaveAll(pSteps);
                                       var historyManager = CreateManager<StateHistoryManager>();
                                       historyManager.AssignTransaction(this);
                                       historyManager.Model = pHistory;
                                       historyManager.Save();
                                       var noteManager = CreateManager<NoteManager>();
                                       noteManager.AssignTransaction(this);
                                       noteManager.Model = pNote;
                                       noteManager.Save();
                                   });

        }
    }
}