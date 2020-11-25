using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exceptions.BuilderExceptions;
using Moq;
using BusinessLogic;

namespace Unit_testing
{
    [TestClass]

    public class ServiceTest
    {
        
        [TestMethod]
        public void IsAddingNeededElement_ToRoot()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel expected = new EmployeeModel("testsurname", "testname", 1000, "testposition");
            // Act
            testService.AddRoot(new EmployeeModel("testsurname", "testname", 1000, "testposition"));

            // Assert
            EmployeeModel actual = testService.Root;
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void IsAddingNeededElement_ToCurrentEmployee()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            testService.AddRoot(new EmployeeModel("root", "root", 1, "root"));
            EmployeeModel expected = new EmployeeModel("testsurname", "testname", 1000, "testposition");
            // Act
            testService.AddEmployee(new EmployeeModel("testsurname", "testname", 1000, "testposition"));

            // Assert
            EmployeeModel actual = testService.CurrentEmployee;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsAddingNeededElement_IsWorkerAdded()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            testService.AddRoot(new EmployeeModel("root", "root", 1, "root"));
            WorkerModel expected = new WorkerModel("testsurname", "testname", 1000, "testposition");
            // Act
            testService.AddWorker(new WorkerModel("testsurname", "testname", 1000, "testposition"));

            // Assert
            WorkerModel actual = (WorkerModel)testService.CurrentEmployee.Subordinates.Find(x=>x.Surname=="testsurname" && x.Name=="testname" && x.Salary==1000 && x.Position=="testposition");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsHierarchySetNeededElement()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            testService.AddRoot(new EmployeeModel("root", "root", 1, "root"));
            testService.AddEmployee(new EmployeeModel("employee","employee",1,"employee"));
            EmployeeModel expected = new EmployeeModel("root", "root", 1, "root");
            // Act
            testService.SetCurrentEmployee("root","root");

            // Assert
            EmployeeModel actual = testService.CurrentEmployee;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_MoreThanValueSalaryEmployees()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(root);
            expected.Add(employee1);
            // Act
            testService.AddRoot(new EmployeeModel("root", "root", 100000, "root"));
            testService.AddEmployee(new EmployeeModel("employee1", "employee1", 90000, "employee1"));
            testService.AddWorker(new WorkerModel("worker1", "worker1", 20000, "worker1"));
            
            // Assert
            List<PersonComponent> actual = testService.MoreThanValueSalaryEmployees(50000);
            CollectionAssert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void Are_Properties_Assigned() 
        {
            // Arrange
            var mock = new Mock<EmployeeModel>();
            mock.Object.Surname = "expected";
            IOrganizationService testService = new OrganizationService();
            // Act
            testService.AddRoot(mock.Object);
            // Assert
            var actual = testService.Root.Surname;
            Assert.AreEqual("expected", actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_MaxSalaryEmployees()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(root);
            // Act
            testService.AddRoot(new EmployeeModel("root", "root", 100000, "root"));
            testService.AddEmployee(new EmployeeModel("employee1", "employee1", 90000, "employee1"));
            testService.AddWorker(new WorkerModel("worker1", "worker1", 20000, "worker1"));

            // Assert
            List<PersonComponent> actual = testService.MaxSalaryEmployees();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_EmployeeSubordinates()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            testService.AddRoot(root);
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(employee1);
            // Act
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.EmployeeSubordinates("root","root");
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_PositionEmployees()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(employee1);
            // Act
            testService.AddRoot(root);
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.PositionEmployees("employee1");
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_ShowStructure_Height()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            WorkerModel worker = new WorkerModel("worker","worker",10000,"worker");
            List<PersonComponent> expected = new List<PersonComponent>() {};
            expected.Add(root);
            expected.Add(worker);
            expected.Add(employee1);
            expected.Add(worker1);
            // Act
            testService.AddRoot(root);
            testService.AddWorker(worker);
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.ShowStructure(StrategyOption.Height);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsReturnExpectedList_ShowStructure_Directsubordination()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel root = new EmployeeModel("root", "root", 100000, "root");
            EmployeeModel employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            WorkerModel worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            WorkerModel worker = new WorkerModel("worker", "worker", 10000, "worker");
            List<PersonComponent> expected = new List<PersonComponent>() { };
            expected.Add(root);
            expected.Add(employee1);
            expected.Add(worker1);
            expected.Add(worker);
            // Act
            testService.AddRoot(root);
            testService.AddWorker(worker);
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.ShowStructure(StrategyOption.Directsubordination);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
