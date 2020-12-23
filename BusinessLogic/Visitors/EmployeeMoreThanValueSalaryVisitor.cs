using System.Collections.Generic;

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
            foreach (PersonComponent emp in employee.Subordinates)
            {
                emp.Accept(this);
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