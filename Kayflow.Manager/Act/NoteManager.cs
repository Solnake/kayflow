using System;
using System.Collections.Generic;
using System.Linq;
using Framework.SqlDataAccess.Controller;
using Kayflow.Controller;
using Kayflow.Model;

namespace Kayflow.Manager
{
    public class NoteManager : KayflowManager<NoteController, Note>
    {
        public List<Note> GetForAct(Guid pActID)
        {
            Filter.AddCondition("ActID", eOperationType.Equal, pActID);
            return GetAll("OnDate desc");
        }

        public override Note Save()
        {
            if (!string.IsNullOrEmpty(Model.Description))
            {
                base.Save();
            }
            return Model;
        }

        public Note GetLast(Guid pAcitID)
        {
            return GetForAct(pAcitID).FirstOrDefault();
        }
    }
}