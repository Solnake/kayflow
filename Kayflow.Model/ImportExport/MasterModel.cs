using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kayflow.Model
{
    [Serializable]
    public class MasterModel
    {
        public Office TargetOffice { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Category> Categories { get; set; }
        public List<Cost> Costs { get; set; }
        public List<State> States { get; set; }
        public List<TerritorialUnit> TerritorialUnits { get; set; }
        public List<ActAction> ActActions { get; set; }
        public List<DocumentGroup> DocumentGroups { get; set; }
        public List<Layout> Layouts { get; set; }
        public List<PaymentDataSettings> PaymentSettings { get; set; }
        public List<Act> Acts { get; set; } 

        public MasterModel()
        {
            
        }
    }
}
