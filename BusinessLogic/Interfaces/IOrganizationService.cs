using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
   public interface IOrganizationService
    {
        public EmployeeModel Root { get; set; }
        public EmployeeModel CurrentEmployee { get; set; }
        public void AddRoot(EmployeeModel root);
        public void AddEmployee(EmployeeModel employee);
        public void AddWorker(WorkerModel worker);
        public EmployeeModel SetCurrentEmployee(string surname, string name);
        public List<PersonComponent> MoreThanValueSalaryEmployees(int salary);
        public List<PersonComponent> MaxSalaryEmployees();
        public List<PersonComponent> EmployeeSubordinates(string surname, string name);
        public List<PersonComponent> PositionEmployees(string position); 
        public List<PersonComponent> ShowStructure(StrategyOption option);
    }
}
