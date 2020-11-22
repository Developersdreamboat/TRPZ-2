using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IVisitor
    {
        public void VisitEmployee(EmployeeModel employee);
        public void VisitWorker(WorkerModel worker);
        public List<PersonComponent> Employees { get; set; }
    }
}
