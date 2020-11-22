using System;
using System.Collections.Generic;
using System.Text;
using Exceptions.BuilderExceptions;
using Exceptions.ConsoleExceptions;
using Exceptions.LeafExceptions;

namespace CLI
{
    public class ConsoleFunctions
    {
        OrganizationFunctions organizationFunctions;
        public ConsoleFunctions(OrganizationFunctions organizationFunctions)
        {
            this.organizationFunctions = organizationFunctions;
        }
        public void Initialize()
        {
            while (true)
            {
                Console.WriteLine("Choose an option. Type 'help' to show a list of commands");
                string command = Console.ReadLine();
                if (command == "exit") { Environment.Exit(0); }
                try
                {
                    switch (command)
                    {
                        case "createHierarchy":
                            Console.WriteLine("Please, type a surname of main employee");
                            string rootSurname = Console.ReadLine();
                            Console.WriteLine("Please, type a name of main employee");
                            string rootName = Console.ReadLine();
                            Console.WriteLine("Please, type a salary of main employee");
                            int rootSalary = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please, type a position of main employee");
                            string rootPosition = Console.ReadLine();
                            organizationFunctions.CreateHierarchy(rootSurname,rootName,rootSalary,rootPosition);
                            break;
                        case "addEmployeeWithSubordinates":
                            Console.WriteLine("Please, type a surname of employee with subordinates");
                            string employeeSurname = Console.ReadLine();
                            Console.WriteLine("Please, type a name of employee with subordinates");
                            string employeeName = Console.ReadLine();
                            Console.WriteLine("Please, type a salary of employee with subordinates");
                            int employeeSalary  = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please, type a position of employee with subordinates");
                            string employeePosition = Console.ReadLine();
                            organizationFunctions.AddEmployeeToHierarchy(employeeSurname,employeeName, employeeSalary, employeePosition);
                            break;
                        case "addEmployeeWithoutSubordinates":
                            Console.WriteLine("Please, type a surname of employee with subordinates");
                            string workerSurname = Console.ReadLine();
                            Console.WriteLine("Please, type a name of employee with subordinates");
                            string workerName = Console.ReadLine();
                            Console.WriteLine("Please, type a salary of employee with subordinates");
                            int workerSalary = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please, type a position of employee with subordinates");
                            string workerPosition = Console.ReadLine();
                            organizationFunctions.AddWorkerToHierarchy(workerSurname,workerName,workerSalary,workerPosition);
                            break;
                        case "chooseCurrentEmployee":
                            Console.WriteLine("Write surname of employee to make an action");
                            string currentNodeSurname = Console.ReadLine();
                            Console.WriteLine("Write name of employee to make an action");
                            string currentNodeName = Console.ReadLine();
                            organizationFunctions.SetCurrentEmployee(currentNodeSurname,currentNodeName);
                            break;
                        case "checkSubordinates":
                            Console.WriteLine("Write surname of employee to check subordinates");
                            string subSurname = Console.ReadLine();
                            Console.WriteLine("Write name of employee to check subordinates");
                            string subName = Console.ReadLine();
                            organizationFunctions.EmployeeSubordinates(subSurname,subName);
                            break;
                        case "checkMaxSalary":
                            organizationFunctions.MaxSalaryEmployees();
                            break;
                        case "checkWithSalary":
                            Console.WriteLine("Please, type a salary");
                            int hierarchyMoreThanSalary = Convert.ToInt32(Console.ReadLine());
                            organizationFunctions.MoreThanSalaryEmployees(hierarchyMoreThanSalary);
                            break;
                        ////case "showByDirectSubordination":
                        ////    functional.ShowByDirectSubordination();
                        ////    break;
                        ////case "showByHeightPosition":
                        ////    functional.ShowByHeightPosition();
                        ////    break;
                        case "help":
                            ShowCommands();
                            break;
                        default:
                            throw new CommandDoesNotExist();
                    }
                }
                catch (LeafAddingException e) // unnecessary exception, because builder prevents operations with employees without subordinates, but who knows
                {
                    Console.WriteLine("You can`t add subordinates to this employee");
                }
                catch (LeafRemovingException e)
                {
                    Console.WriteLine("You can`t remove subordinates of this employee");
                }
                catch (ElementDoesNotExistException e)
                {
                    Console.WriteLine("Hierarchy doesn`t have employee with this id");
                }
                catch (BuilderDoesNotExistException e)
                {
                    Console.WriteLine("Hierarchy isn`t created yet");
                }
                catch (CommandDoesNotExist e)
                {
                    Console.WriteLine("This command doesn`t exist");
                }
            }
        }
        private void ShowCommands()
        {
            Console.WriteLine("showAllEmployees, addToBase, createHierarchy, " +
                "addEmployeeWithSubordinates, " + "addEmployeeWithoutSubordinates, \n" +
                " chooseCurrentEmployee," +
                "checkSubordinates, checkMaxSalary, checkWithSalary, " +
                "showByDirectSubordination,\n showByHeightPosition");
        }
    }
}

