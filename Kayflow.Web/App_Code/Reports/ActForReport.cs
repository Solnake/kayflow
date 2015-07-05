using Kayflow.Model;

namespace Kayflow.Reports
{
    public class ActForReport: Act
    {
        public StepCollection Steps { get; private set; }
        public DocumentCollection Documents { get; private set; }
        public ActForReport()
        {
            Steps = new StepCollection();
            Documents = new DocumentCollection();
        }
    }
}
