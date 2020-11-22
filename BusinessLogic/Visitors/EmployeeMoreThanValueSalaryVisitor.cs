using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class EmployeeMoreThanValueSalaryVisitor : IVisitor
    {
        private int Value { get; set; }
        public EmployeeMoreThanValueSalaryVisitor(int value)
        {
            Value = value;
        }
        public List<PersonComponent> Employees { get; set; } = new List<PersonComponent>();
        public void VisitEmployee(EmployeeModel employee)
        {
            if (employee.Salary > Value)
            {
                Employees.Add(employee);
            }
        }
        public void VisitWorker(WorkerModel worker)
        {
            if (worker.Salary > Value)
            {
                Employees.Add(worker);
            }
        }
    }
}
