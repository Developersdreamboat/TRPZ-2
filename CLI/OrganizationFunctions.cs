using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;

namespace CLI
{
    public class OrganizationFunctions
    {
        private IOrganizationService organizationService;
        public OrganizationFunctions(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }
        public void CreateHierarchy(string surname, string name, int salary, string position)
        {
            organizationService.AddRoot(surname,name,salary,position);
        }
        public void AddEmployeeToHierarchy(string surname, string name, int salary, string position)
        {
            organizationService.AddEmployee(surname,name,salary,position);
        }
        public void AddWorkerToHierarchy(string surname, string name, int salary, string position)
        {
            organizationService.AddWorker(surname, name, salary,position);
        }
        public void SetCurrentEmployee(string surname, string name)
        {
            organizationService.SetCurrentEmployee(surname, name);
        }
        public void MoreThanSalaryEmployees(int salary)
        {
            var show = organizationService.MoreThanValueSalaryEmployees(salary);
            foreach (var e in show)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void MaxSalaryEmployees()
        {
            var show = organizationService.MaxSalaryEmployees();
            foreach (var e in show)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void EmployeeSubordinates(string surname, string name)
        {
            var show = organizationService.EmployeeSubordinates(surname,name);
            foreach (var e in show)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void PositionEmployees(string position)
        {

            var show = organizationService.PositionEmployees(position);
            foreach (var e in show)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
