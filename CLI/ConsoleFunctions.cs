using Exceptions.BuilderExceptions;
using Exceptions.ConsoleExceptions;
using Exceptions.LeafExceptions;
using System;

namespace CLI
{
    public class ConsoleFunctions
    {
        private OrganizationFunctions organizationFunctions;

        public ConsoleFunctions(OrganizationFunctions organizationFunctions)
        {
            this.organizationFunctions = organizationFunctions;
        }

        public void Initialize()
        {
            while (true)
            {
                Console.WriteLine("Choose an option. Type " + CommandNames.Help + " to show a list of commands");
                string command = Console.ReadLine();
                if (command.Equals(CommandNames.Exit))
                {
                    Environment.Exit(0);
                }

                try
                {
                    switch (command)
                    {
                        case CommandNames.CreateHierarchy:
                            CreateHierarchy();
                            break;

                        case CommandNames.AddEmployeeWithSubordinates:
                            AddEmployeeWithSubordinates();
                            break;

                        case CommandNames.AddEmployeeWithoutSubordinates:
                            AddEmployeeWithoutSubordinates();
                            break;

                        case CommandNames.ChooseCurrentEmployee:
                            ChooseCurrentEmployee();
                            break;

                        case CommandNames.CheckSubordinates:
                            CheckSubordinates();
                            break;

                        case CommandNames.CheckPosition:
                            CheckPosition();
                            break;

                        case CommandNames.CheckMaxSalary:
                            CheckMaxSalary();
                            break;

                        case CommandNames.CheckWithSalary:
                            CheckWithSalary();
                            break;

                        case CommandNames.ShowEmployees:
                            ShowEmployees();
                            break;

                        case CommandNames.Help:
                            ShowCommands();
                            break;

                        default:
                            throw new CommandDoesNotExist("This command does not exist");
                    }
                }
                catch (Exception e) when (e is LeafAddingException ||
                                          e is LeafRemovingException ||
                                          e is ElementDoesNotExistException ||
                                          e is BuilderDoesNotExistException ||
                                          e is CommandDoesNotExist)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unsupported exception was thrown. Contact the developer Evgeniy Pavlenko", e.Message);
                }
            }
        }

        private void ShowCommands()
        {
            Console.WriteLine(CommandNames.CreateHierarchy + " " + CommandNames.AddEmployeeWithSubordinates + " " +
                              CommandNames.AddEmployeeWithoutSubordinates + " " + "\n" +
                              CommandNames.ChooseCurrentEmployee + " " +
                              CommandNames.CheckSubordinates + " " + CommandNames.CheckMaxSalary + " " +
                              CommandNames.CheckWithSalary + " " +
                              CommandNames.CheckPosition + "\n" + CommandNames.ShowEmployees);
        }

        private void CreateHierarchy()
        {
            Console.WriteLine("Please, type a surname of main employee");
            string rootSurname = Console.ReadLine();
            Console.WriteLine("Please, type a name of main employee");
            string rootName = Console.ReadLine();
            Console.WriteLine("Please, type a salary of main employee");
            int rootSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, type a position of main employee");
            string rootPosition = Console.ReadLine();
            organizationFunctions.CreateHierarchy(rootSurname, rootName, rootSalary, rootPosition);
        }

        private void AddEmployeeWithSubordinates()
        {
            Console.WriteLine("Please, type a surname of employee with subordinates");
            string employeeSurname = Console.ReadLine();
            Console.WriteLine("Please, type a name of employee with subordinates");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Please, type a salary of employee with subordinates");
            int employeeSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, type a position of employee with subordinates");
            string employeePosition = Console.ReadLine();
            organizationFunctions.AddEmployeeToHierarchy(employeeSurname, employeeName, employeeSalary, employeePosition);
        }

        private void AddEmployeeWithoutSubordinates()
        {
            Console.WriteLine("Please, type a surname of employee without subordinates");
            string workerSurname = Console.ReadLine();
            Console.WriteLine("Please, type a name of employee without subordinates");
            string workerName = Console.ReadLine();
            Console.WriteLine("Please, type a salary of employee without subordinates");
            int workerSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, type a position of employee without subordinates");
            string workerPosition = Console.ReadLine();
            organizationFunctions.AddWorkerToHierarchy(workerSurname, workerName, workerSalary, workerPosition);
        }

        private void ChooseCurrentEmployee()
        {
            Console.WriteLine("Write surname of employee to make an action");
            string currentNodeSurname = Console.ReadLine();
            Console.WriteLine("Write name of employee to make an action");
            string currentNodeName = Console.ReadLine();
            organizationFunctions.SetCurrentEmployee(currentNodeSurname, currentNodeName);
        }

        private void CheckSubordinates()
        {
            Console.WriteLine("Write surname of employee to check subordinates");
            string subSurname = Console.ReadLine();
            Console.WriteLine("Write name of employee to check subordinates");
            string subName = Console.ReadLine();
            organizationFunctions.EmployeeSubordinates(subSurname, subName);
        }

        private void CheckPosition()
        {
            Console.WriteLine("Write position to check");
            string position = Console.ReadLine();
            organizationFunctions.PositionEmployees(position);
        }

        private void CheckMaxSalary()
        {
            organizationFunctions.MaxSalaryEmployees();
        }

        private void CheckWithSalary()
        {
            Console.WriteLine("Please, type a salary");
            int hierarchyMoreThanSalary = Convert.ToInt32(Console.ReadLine());
            organizationFunctions.MoreThanSalaryEmployees(hierarchyMoreThanSalary);
        }

        private void ShowEmployees()
        {
            Console.WriteLine("Choose an option: Height to show by height position, Directsubordination for direct subordination");
            string showOption = Console.ReadLine();
            organizationFunctions.Show(showOption);
        }

        internal static class CommandNames
        {
            public const string Exit = "exit";
            public const string CreateHierarchy = "createHierarchy";
            public const string AddEmployeeWithSubordinates = "addEmployeeWithSubordinates";
            public const string AddEmployeeWithoutSubordinates = "addEmployeeWithoutSubordinates";
            public const string ChooseCurrentEmployee = "chooseCurrentEmployee";
            public const string CheckSubordinates = "checkSubordinates";
            public const string CheckMaxSalary = "CheckMaxSalary";
            public const string CheckWithSalary = "checkWithSalary";
            public const string CheckPosition = "checkPosition";
            public const string ShowEmployees = "showEmployees";
            public const string Help = "help";
        }
    }
}