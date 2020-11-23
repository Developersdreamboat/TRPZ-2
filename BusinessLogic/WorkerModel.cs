using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class WorkerModel : PersonComponent
    {
        public WorkerModel() { }
        public WorkerModel(string surname, string name, int salary, string position) : base(surname, name, salary, position)
        {
        }
        public override void Add(PersonComponent subordinate)
        {
        }
        public override void Remove(PersonComponent subordinate)
        {
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitWorker(this);
        }
    }
}
