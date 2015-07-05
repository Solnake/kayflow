using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Framework.SqlDataAccess.Manager;
using Kayflow.Manager;
using Kayflow.Model;

namespace Kayflow.Reports
{
    public class ActCollection: ArrayList, ITypedList
    {
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Acts";
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors!= null && listAccessors.Length>0)
            {
                var listAccessor = listAccessors[listAccessors.Length - 1];
                if (listAccessor.PropertyType == typeof(StepCollection))
                    return TypeDescriptor.GetProperties(typeof (StepForReport));
                if (listAccessor.PropertyType == typeof(DocumentCollection))
                    return TypeDescriptor.GetProperties(typeof (ActDocument));
            }
            return TypeDescriptor.GetProperties(typeof (ActForReport));
        }

        public void BindWithSteps(List<Act> pActs)
        {
            BindFromList(pActs, true, false);
        }

        public void BindWithDocuments(List<Act> pActs)
        {
            BindFromList(pActs, false, true);
        }

        private void BindFromList(IEnumerable<Act> pActs, bool pBindSteps, bool pBindDocuments)
        {
            foreach (var item in pActs)
            {
                var act = new ActForReport();
                act.CopyFrom(item);
                if (pBindSteps)
                    act.Steps.BindFromList(Factory.Manager<StepManager>().GetForAct(item.ActID));
                if (pBindDocuments)
                    act.Documents.AddRange(
                        Factory.Manager<ActDocumentManager>().GetForActAll(item.ActID, act.OfficeID));
                Add(act);
            }
        }
    }
}
