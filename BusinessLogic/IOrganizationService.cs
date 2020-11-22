using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
   public interface IOrganizationService
    {
        public EmployeeModel Root { get; set; }
        public EmployeeModel CurrentEmployee { get; set; }
        public void AddRoot(string surname, string name, int salary, string position);
        public PersonComponent AddEmployee(string surname, string name, int salary, string position);
        public PersonComponent AddWorker(string surname, string name, int salary, string position);
        public EmployeeModel SetCurrentEmployee(string surname, string name);
        public List<PersonComponent> MoreThanValueSalaryEmployees(int salary);
        public List<PersonComponent> MaxSalaryEmployees();
        public List<PersonComponent> EmployeeSubordinates(string surname, string name);
        public List<PersonComponent> PositionEmployees(string position);
    }
}
