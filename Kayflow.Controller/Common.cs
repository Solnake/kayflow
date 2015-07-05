using System;
using System.Collections.Generic;
using System.Text;
using Framework.SqlDataAccess.Controller;
using Framework.SqlDataAccess.Model;
using Kayflow.Model;

namespace Kayflow.Controller
{
    public abstract class KayflowController<TM> : ReadWriteControllerSinglePK<TM, Guid>
        where TM : BaseModel, new()
    {
        public KayflowController() : this(null, null, false) { }
        public KayflowController(TM model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        public override string FactoryKey { get { return "Kayflow"; } }
        protected override bool UseDinamicSaveQuery { get { return true; } }
    }

    public abstract class KayflowLinkController<TM> : ReadWriteControllerMultiPK<TM, Guid, Guid>
        where TM : ModelBaseMultiPK, new()
    {
        public KayflowLinkController() : this(null, null, false) { }
        public KayflowLinkController(TM model, DALCBase parent, bool useTransaction) : base(model, parent, useTransaction) { }

        public override string FactoryKey { get { return "Kayflow"; } }
        protected override bool UseDinamicSaveQuery { get { return true; } }
    }

    public class KayflowException : Exception
    {
        public KayflowException() : this(null, null) { }
        public KayflowException(string message) : this(message, null) { }
        public KayflowException(string message, Exception innerException) : base(message, innerException) 
        {
            IsLogable = false;
            IsProcessed = false;
        }
        public bool IsLogable { get; set; }
        public bool IsProcessed { get; set; }
    }

    public static class Extensions
    {
        public static string ToCommaSeparatedString(this List<object> list)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (object id in list)
                sb.Append(id).Append(",");

            return sb.ToString().TrimEnd(',');
        }
        public static string ToCommaSeparatedString(this List<int> list)
        {
            if (list == null || list.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (object id in list)
                sb.Append(id).Append(",");

            return sb.ToString().TrimEnd(',');
        }
    }
}
