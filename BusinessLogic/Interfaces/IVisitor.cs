using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IVisitor
    {
        void VisitEmployee(EmployeeModel employee);

        void VisitWorker(WorkerModel worker);

        List<PersonComponent> Employees { get; set; }
    }
}