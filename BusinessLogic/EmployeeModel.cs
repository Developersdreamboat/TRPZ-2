namespace BusinessLogic
{
    public partial class EmployeeModel : PersonComponent
    {
        public EmployeeModel()
        {
        }

        public EmployeeModel(string surname, string name, int salary, string position) : base(surname, name, salary, position)
        {
        }

        public void Add(PersonComponent subordinate)
        {
            Subordinates.Add(subordinate);
        }

        public void Remove(PersonComponent subordinate)
        {
            Subordinates.Remove(subordinate);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitEmployee(this);
        }
    }
}