using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IOrganizationService
    {
        EmployeeModel Root { get; set; }
        EmployeeModel CurrentEmployee { get; set; }

        void AddRoot(EmployeeModel root);

        void AddEmployee(EmployeeModel employee);

        void AddWorker(WorkerModel worker);

        EmployeeModel SetCurrentEmployee(string surname, string name);

        List<PersonComponent> MoreThanValueSalaryEmployees(int salary);

        List<PersonComponent> MaxSalaryEmployees();

        List<PersonComponent> EmployeeSubordinates(string surname, string name);

        List<PersonComponent> PositionEmployees(string position);

        List<PersonComponent> ShowStructure(StrategyOption option);
    }
}