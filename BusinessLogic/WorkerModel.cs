namespace BusinessLogic
{
    public class WorkerModel : PersonComponent
    {
        public WorkerModel()
        {
        }

        public WorkerModel(string surname, string name, int salary, string position) : base(surname, name, salary, position)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitWorker(this);
        }
    }
}