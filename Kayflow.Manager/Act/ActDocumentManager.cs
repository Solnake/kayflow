using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Manager;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class ActDocumentManager : KayflowManager<ActDocumentController, ActDocument>
    {
        public List<ActDocument> GetForAct(Guid pActID)
        {
            Filter.AddCondition("ActID", eOperationType.Equal, pActID);
            return GetAll();
        }

        public List<ActDocument> GetForActAll(Guid pActID, Guid pOfficeID)
        {
            var list = GetForAct(pActID);
            var documents = Factory.Manager<DocumentManager>().GetByOffice(pOfficeID);
            foreach (var document in documents.Where(d => list.All(l => l.DocumentID != d.ID)))
            {
                list.Add(new ActDocument
                    {
                        ActID = pActID,
                        DocumentID = document.ID,
                        DocumentName = document.DocumentName,
                        DocumentOrdNum = document.OrdNum,
                        GroupName = document.GroupName,
                        GroupOrdNum = document.GroupOrdNum,
                        DocumentGroupID = document.DocumentGroupID,
                        ValueSetID = document.ValueSetID,
                        DocColor = null,
                        ShowComments = document.ShowComments
                    });
            }
            return list.OrderBy(l => l.GroupOrdNum).ThenBy(l => l.DocumentOrdNum).ToList();
        }
    }
}