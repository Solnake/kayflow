using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class StateHistoryManager : KayflowManager<StateHistoryController, StateHistory>
    {
        public List<StateHistory> GetForAct(Guid pActID)
        {
            Filter.AddCondition("ActID", eOperationType.Equal, pActID);
            return GetAll("OnDate desc");
        }

        public override StateHistory Save()
        {
            return TransactionOverlay<StateHistory>(SaveHandler);
        }

        public StateHistory GetCurrent(Guid pActID)
        {
            return GetForAct(pActID).FirstOrDefault();
        }

        private StateHistory SaveHandler()
        {
            var current = GetCurrent(Model.ActID);
            if (current == null || current.StateID != Model.StateID
                || !string.IsNullOrEmpty(Model.Description))
            {
                base.Save();
                var manager = CreateManager<ActHistoryManager>();
                manager.AssignTransaction(this);
                if (current == null || current.StateID != Model.StateID)
                {
                    manager.Model = new ActHistory
                                        {
                                            OnDate = DateTime.Now,
                                            EmployeeID = EmployeeID,
                                            ActID = Model.ActID,
                                            Description = string.IsNullOrEmpty(Model.Description)
                                                              ? string.Format("Встановив статус: '{0}'",
                                                                              Model.StateName)
                                                              : string.Format("Встановив статус: '{0}' та стан справи: '{1}'",
                                                                              Model.StateName,
                                                                              Model.Description)
                                        };
                    manager.Save();
                }
            }
            return Model;
        }
    }
}