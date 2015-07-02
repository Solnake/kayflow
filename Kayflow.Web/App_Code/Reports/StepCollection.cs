using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Kayflow.Model;

namespace Kayflow.Reports
{
    public class StepCollection : ArrayList, ITypedList 
    {
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Steps";
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof (StepForReport));
        }

        public void BindFromList(List<Step> pSteps)
        {
            foreach (var item in pSteps)
            {
                var step = new StepForReport();
                step.CopyFrom(item);
                Add(step);
            }
        }
    }
}
