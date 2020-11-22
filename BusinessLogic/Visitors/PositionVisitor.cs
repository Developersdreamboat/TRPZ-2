using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PositionVisitor : IVisitor
    {
        private string Position { get; set; }
        public PositionVisitor(string position)
        {
            Position = position;
        }
        public List<PersonComponent> Employees { get; set; } = new List<PersonComponent>();
        public void VisitEmployee(EmployeeModel employee)
        {
            if (employee.Position == Position)
            {
                Employees.Add(employee);
            }
        }
        public void VisitWorker(WorkerModel worker)
        {
            if (worker.Position == Position)
            {
                Employees.Add(worker);
            }
        }
    }
}
