using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ProgressEventArgs: EventArgs
    {
        public int Progress { get; set; }
    }
    public class ImportExportManager
    {
        public event EventHandler<ProgressEventArgs> Progress;

        public List<MasterModel> GetExportAllOffice()
        {
            var list = new List<MasterModel>();
            foreach (var office in Factory.Manager<OfficeManager>().GetAll())
            {
                list.Add(GetExportObject(office.ID));
            }
            return list;
        }

        public MasterModel GetExportObject(Guid pOfficeID)
        {
            var master = new MasterModel
                             {
                                 TargetOffice = Factory.Controller<OfficeController>().Get(pOfficeID)
                             };
            if (master.TargetOffice == null)
                throw new NullReferenceException("Офіс для експорта не обрано");
            DoProgress(5);
            master.Employees = Factory.Manager<EmployeeManager>().GetByOffice(pOfficeID);
            DoProgress(10);
            master.Categories = Factory.Manager<CategoryManager>().GetByOffice(pOfficeID);
            DoProgress(15);
            master.Costs = Factory.Manager<CostManager>().GetForDictionary(pOfficeID);
            DoProgress(20);
            master.States = Factory.Manager<StateManager>().GetByOffice(pOfficeID);
            DoProgress(25);
            master.TerritorialUnits = Factory.Manager<TerritorialUnitManager>().GetByOffice(pOfficeID);
            DoProgress(30);
            master.ActActions = Factory.Manager<ActActionManager>().GetByOffice(pOfficeID);
            DoProgress(35);
            master.DocumentGroups = Factory.Manager<DocumentGroupManager>().GetForDictionary(pOfficeID);
            DoProgress(40);
            master.Layouts = Factory.Manager<LayoutManager>().GetAll(pOfficeID);
            DoProgress(45);
            master.PaymentSettings = Factory.Manager<PaymentDataSettingsManager>().GetForDictionary(pOfficeID).FindAll(
                p => !p.IsNew);
            DoProgress(50);
            master.Acts = Factory.Manager<ActManager>().GetByOffice(pOfficeID);
            DoProgress(55);
            ExportDocuments(pOfficeID, master);
            DoProgress(60);
            ExportActs(pOfficeID, master.Acts);
            DoProgress(95);
            ExportExpences(pOfficeID, master.Employees);
            DoProgress(100);
            return master;
        }

        public List<Office> ImportOffice(Stream pXml)
        {
            var list = GetImportObject(pXml);
            if (list == null || !list.Any())
                throw new ArgumentNullException("Помилка файлу імпорта");
            if (list.Any(a=>a.TargetOffice==null))
                throw new ArgumentNullException("Помилка файлу імпорта");
            var result = new List<Office>();
            var mainManager = Factory.Manager<OfficeManager>("LongTime");
            mainManager.TransactionOverlay(delegate
                                           {
                                               DoProgress(10);
                                               foreach (var masterModel in list)
                                               {
                                                   var manager = Factory.Manager<OfficeManager>("LongTime");
                                                   manager.AssignTransaction(mainManager);
                                                   //manager.Controller.DeleteOffice(masterModel.TargetOffice.ID);
                                                   //var employeeManager = Factory.Manager<EmployeeManager>("LongTime");
                                                   //employeeManager.AssignTransaction(manager);
                                                   //employeeManager.DeleteAllInOffice(masterModel.TargetOffice.ID);
                                                   manager.Model = masterModel.TargetOffice;
                                                   //manager.InitializeModel(masterModel.TargetOffice.ID);
                                                   manager.Controller.Save();
                                                   DoProgress(25);
                                                   ImportSimpleObjects(masterModel, manager);
                                                   DoProgress(35);
                                                   ImportEmployees(masterModel.Employees, manager);
                                                   DoProgress(45);
                                                   ImportDocuments(masterModel.DocumentGroups, manager);
                                                   DoProgress(55);
                                                   ImportUnits(masterModel.TerritorialUnits, manager);
                                                   DoProgress(65);
                                                   result.Add(manager.Model);
                                               }
                                               foreach (var masterModel in list)
                                               {
                                                   var manager = Factory.Manager<OfficeManager>();
                                                   manager.AssignTransaction(mainManager);
                                                   ImportActs(masterModel.Acts, manager);    
                                               }
                                               DoProgress(100);
                                           });
            return result;
        }

        #region -= Export =-
        private void ExportDocuments(Guid pOfficeID, MasterModel master)
        {
            var documents = Factory.Manager<DocumentManager>().GetForDictionary(pOfficeID);
            foreach (var item in master.DocumentGroups)
            {
                item.Documents = documents.FindAll(d => d.DocumentGroupID == item.DocumentGroupID);
            }
        }

        private void ExportActs(Guid pOfficeID, IEnumerable<Act> pActs)
        {
            var notes = Factory.Manager<NoteManager>().GetByOffice(pOfficeID);
            var histories = Factory.Manager<ActHistoryManager>().GetByOffice(pOfficeID);
            var documents = Factory.Manager<ActDocumentManager>().GetByOffice(pOfficeID);
            var steps = Factory.Manager<StepManager>().GetByOffice(pOfficeID);
            var states = Factory.Manager<StateHistoryManager>().GetByOffice(pOfficeID);
            foreach (var act in pActs)
            {
                act.Notes = notes.FindAll(n => n.ActID == act.ID);
                act.History = histories.FindAll(h => h.ActID == act.ID);
                act.DocumentList = documents.FindAll(d => d.ActID == act.ID);
                act.StepList = steps.FindAll(s => s.ActID == act.ID);
                act.States = states.FindAll(s => s.ActID == act.ID);
            }
        }

        public void ExportExpences(Guid pOfficeID, IEnumerable<Employee> pEmployees)
        {
            var expences = Factory.Manager<ExpenseManager>().GetByOffice(pOfficeID);
            var costs = Factory.Manager<ExpenseCostManager>().GetByOffice(pOfficeID);
            foreach (var item in pEmployees)
            {
                item.Expenses = expences.FindAll(e => e.EmployeeID == item.ID);
                foreach (var expense in item.Expenses)
                {
                    expense.Costs = costs.FindAll(c => c.ExpenseID == expense.ID);
                }
            }
        }
        #endregion

        #region -= Import =-
        private void ImportSimpleObjects(MasterModel masterModel, IManager manager)
        {
            foreach (var item in masterModel.Categories)
            {
                SaveModel<CategoryManager, CategoryController, Category>(item, manager, false, true);
            }

            DoProgress(27);
            foreach (var item in masterModel.Costs)
            {
                SaveModel<CostManager, CostController, Cost>(item, manager);
            }

            DoProgress(29);
            foreach (var item in masterModel.States)
            {
                SaveModel<StateManager, StateController, State>(item, manager);
            }

            DoProgress(31);
            foreach (var item in masterModel.ActActions)
            {
                SaveModel<ActActionManager, ActActionController, ActAction>(item, manager);
            }

            DoProgress(32);
            foreach (var item in masterModel.Layouts)
            {
                SaveModel<LayoutManager, LayoutController, Layout>(item, manager, false, true);
            }

            DoProgress(33);
            foreach (var item in masterModel.PaymentSettings)
            {
                SaveModel<PaymentDataSettingsManager, PaymentDataSettingsController, PaymentDataSettings>(item, manager);
            }
        }

        private void ImportEmployees(List<Employee> pList, IManager pManager)
        {
            var inc = pList.Any() ? 10.00 / pList.Count() : 10.00;
            var subInc = inc;
            var progressValue = 35;
            foreach (var item in pList)
            {
                progressValue += IncProgress(inc, ref subInc);
                SaveModel<EmployeeManager, EmployeeController, Employee>(item, pManager);
                foreach (var expense in item.Expenses)
                {
                    SaveModel<ExpenseManager, ExpenseController, Expense>(expense, pManager);
                    foreach (var cost in expense.Costs)
                    {
                        var manager = Factory.Manager<ExpenseCostManager>("LongTime");
                        manager.AssignTransaction(pManager);
                        manager.Fill(cost);
                        manager.Save();
                    }
                }

                DoProgress(progressValue);
            }
        }

        private void ImportDocuments(List<DocumentGroup> pList, IManager manager)
        {
            var inc = pList.Any() ? 10.00 / pList.Count() : 10.00;
            var subInc = inc;
            var progressValue = 45;
            foreach (var item in pList)
            {
                progressValue += IncProgress(inc, ref subInc);
                SaveModel<DocumentGroupManager, DocumentGroupController, DocumentGroup>(item, manager);
                foreach (var document in item.Documents)
                {
                    SaveModel<DocumentManager, DocumentController, Document>(document, manager);
                }

                DoProgress(progressValue);
            }
        }

        private void ImportUnits(List<TerritorialUnit> pList, IManager manager)
        {
            var inc = pList.Any() ? 10.00 / pList.Count() : 10.00;
            var subInc = inc;
            var progressValue = 55;
            pList.Sort(CompareUnits);
            foreach (var item in pList)
            {
                progressValue += IncProgress(inc, ref subInc);
                SaveModel<TerritorialUnitManager, TerritorialUnitController, TerritorialUnit>(item, manager);
                DoProgress(progressValue);
            }
        }

        private void ImportActs(List<Act> pList, IManager manager)
        {
            var inc = pList.Any() ? 35.0 / pList.Count() : 35.0;
            var subInc = inc;
            var progressValue = 65;
            foreach (var item in pList)
            {
                progressValue += IncProgress(inc, ref subInc);
                SaveModel<ActManager, ActController, Act>(item, manager);
                foreach (var note in item.Notes)
                {
                    SaveModel<NoteManager, NoteController, Note>(note, manager);
                }

                foreach (var history in item.History)
                {
                    SaveModel<ActHistoryManager, ActHistoryController, ActHistory>(history, manager);
                }

                foreach (var state in item.States)
                {
                    SaveModel<StateHistoryManager, StateHistoryController, StateHistory>(state, manager, true);
                }

                foreach (var step in item.StepList)
                {
                    SaveModel<StepManager, StepController, Step>(step, manager, true);
                }

                foreach (var document in item.DocumentList)
                {
                    SaveModel<ActDocumentManager, ActDocumentController, ActDocument>(document, manager);
                }

                DoProgress(progressValue);
            }
        }

        private int IncProgress(double inc, ref double subInc)
        {
            var result = 0;
            if (Math.Round(subInc, 0) == 0)
                subInc += inc;
            else
            {
                result = (int)Math.Round(subInc, 0);
                subInc = 0;
            }
            return result;
        }

        private int CompareUnits(TerritorialUnit x, TerritorialUnit y)
        {
            if (x.ID == y.ID || (!x.ParentID.HasValue && !y.ParentID.HasValue))
                return 0;
            if (!x.ParentID.HasValue)
                return -1;
            if (x.ID == y.ParentID)
                return -1;
            if (!y.ParentID.HasValue)
                return 1;
            return -1;
        }

        private List<MasterModel> GetImportObject(Stream pXml)
        {
            var settings = new XmlReaderSettings
                               {
                                   IgnoreComments = true,
                                   ConformanceLevel = ConformanceLevel.Auto
                               };
            using (XmlReader reader = XmlReader.Create(pXml, settings))
            {
                var list = new List<MasterModel>();
                var serializer = new XmlSerializer(list.GetType());
                list = serializer.Deserialize(reader) as List<MasterModel>;
                return list;
            }
        }

        private TM SaveModel<M, TC, TM>(TM pModel, IManager pParent, bool pForceControllerSave = false, bool pGetFromDB = false)
            where M : KayflowManager<TC, TM>, new()
            where TC : ReadWriteControllerSinglePK<TM, Guid>, new()
            where TM : BaseModel, new()
        {
            var manager = Factory.Manager<M>("LongTime");
            manager.AssignTransaction(pParent);
            if (pGetFromDB)
                manager.InitializeModel(pModel.ID);
            manager.Fill(pModel);
            return pForceControllerSave ? manager.Controller.Save() : manager.Save();
        } 
        #endregion

        private void DoProgress(int pValue)
        {
            if (Progress != null)
                Progress(this, new ProgressEventArgs { Progress = pValue });
        }

    }
}
