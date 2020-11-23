using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic
{
    public class EmployeeMaxSalaryVisitor : IVisitor
    {
        int maxSalary = 0;
        private List<PersonComponent> employees = new List<PersonComponent>();
        public List<PersonComponent> Employees
        {
            get
            {
                var maxSalaryEmployees = employees.Where(x => x.Salary == maxSalary).ToList();
                return maxSalaryEmployees;
            }
            set { }
        }
        public void VisitEmployee(EmployeeModel employee)
        {
            if (employee.Salary >= maxSalary)
            {
                maxSalary = employee.Salary;
                employees.Add(employee);
            }
            foreach (PersonComponent emp in employee.Subordinates)
            {
                emp.Accept(this);
            }
        }
        public void VisitWorker(WorkerModel worker)
        {
            if (worker.Salary >= maxSalary)
            {
                maxSalary = worker.Salary;
                employees.Add(worker);
            }
        }

    }
}
