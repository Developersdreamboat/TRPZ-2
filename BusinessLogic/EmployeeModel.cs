using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public partial class EmployeeModel : PersonComponent
    {
        public EmployeeModel() { }
        public EmployeeModel(string surname, string name, int salary, Position position) : base(surname, name, salary, position)
        {
        }
        public List<PersonComponent> Subordinates { get; set; } = new List<PersonComponent>();
        public override void Add(PersonComponent subordinate)
        {
            Subordinates.Add(subordinate);
        }
        public override void Remove(PersonComponent subordinate)
        {
            Subordinates.Remove(subordinate);
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitEmployee(this);
        }
    }
}
