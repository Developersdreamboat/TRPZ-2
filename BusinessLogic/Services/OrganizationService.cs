using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Exceptions.BuilderExceptions;

namespace BusinessLogic
{
    public class OrganizationService : IOrganizationService
    {
        private EmployeeModel root;
        private EmployeeModel currentEmployee;
        public EmployeeModel Root
        {
            set 
            {
                root = value; 
            }
            get
            {
                if (root is null)
                {
                    throw new BuilderDoesNotExistException();
                }
                else
                {
                    return root;
                }
            }
        }
        public EmployeeModel CurrentEmployee
        {
            set
            {
                currentEmployee = value;
            }
            get
            {
                if (currentEmployee is null)
                {
                    throw new BuilderDoesNotExistException();
                }
                else
                {
                    return currentEmployee;
                }
            }
        }
        public IShowStructureService ShowStructureService { get; set; }
        public OrganizationService(IShowStructureService showStructureService) 
        {
            ShowStructureService = showStructureService;
        }
        public void AddRoot(string surname, string name, int salary, string position) 
        {
            Root = new EmployeeModel(surname, name, salary, position);
            CurrentEmployee = Root;
        }
        public PersonComponent AddEmployee(string surname, string name, int salary, string position)
        {
            var employee = new EmployeeModel(surname,name,salary,position);
            CurrentEmployee.Add(employee);
            CurrentEmployee = employee;
            return employee;
        }
        public PersonComponent AddWorker(string surname, string name, int salary, string position)
        {
            var worker = new WorkerModel(surname, name, salary, position);
            CurrentEmployee.Add(worker);
            return worker;
        }
        public EmployeeModel SetCurrentEmployee(string surname, string name)
        {
            var employeeStack = new Stack<EmployeeModel>();
            employeeStack.Push(Root);
            while (employeeStack.Any())
            {
                var currentEmployee = employeeStack.Pop();
                if (surname == currentEmployee.Surname && name == currentEmployee.Name)
                {
                    CurrentEmployee = currentEmployee;
                    return currentEmployee;
                }
                foreach (var employee in currentEmployee.Subordinates.OfType<EmployeeModel>())
                {
                    employeeStack.Push(employee);
                }
            }
            throw new ElementDoesNotExistException();
        }
        public List<PersonComponent> MoreThanValueSalaryEmployees(int salary)
        {
            IVisitor visitor = new EmployeeMoreThanValueSalaryVisitor(salary);
            Root.Accept(visitor);
            var result = visitor.Employees;
            return result;

        }
        public List<PersonComponent> MaxSalaryEmployees()
        {
            IVisitor employeeVisitor = new EmployeeMaxSalaryVisitor();
            Root.Accept(employeeVisitor);
            return employeeVisitor.Employees;
        }
        public List<PersonComponent> EmployeeSubordinates(string surname, string name)
        {
            SetCurrentEmployee(surname,name);
            var result = CurrentEmployee.Subordinates;
            return result;
        }
        public List<PersonComponent> PositionEmployees(string position)
        {
            var visitor = new PositionVisitor(position);
            Root.Accept(visitor);
            var result = visitor.Employees;
            return result;
        }
        public List<PersonComponent> ShowStructure(int option)
        {
            return ShowStructureService.chooseAlgorithm(option,Root);
        }
    }
}
