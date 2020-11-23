using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class HierarchyVisitor : IVisitor
    {
        public List<PersonComponent> Employees { get; set; } = new List<PersonComponent>();
        public void VisitEmployee(EmployeeModel employee)
        {
            Employees.Add(employee);
            foreach (PersonComponent emp in employee.Subordinates)
            {
                emp.Accept(this);
            }
        }
        public void VisitWorker(WorkerModel worker)
        {
            Employees.Add(worker);
        }
    }
}
