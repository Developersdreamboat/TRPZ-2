using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Unit_testing
{
    [TestClass]
    public class ServiceTest
    {
        private IOrganizationService testService;
        private EmployeeModel employee1;
        private EmployeeModel root;
        private WorkerModel worker1;
        private WorkerModel worker2;
        private WorkerModel worker;

        [TestInitialize]
        public void TestInitialize()
        {
            root = new EmployeeModel("root", "root", 100000, "root");
            employee1 = new EmployeeModel("employee1", "employee1", 90000, "employee1");
            worker1 = new WorkerModel("worker1", "worker1", 20000, "worker1");
            worker2 = new WorkerModel("worker2", "worker", 10000, "worker2");
            worker = new WorkerModel("worker", "worker", 10000, "worker");
            testService = new OrganizationService();
            testService.Root = root;
            testService.CurrentEmployee = employee1;
            testService.AddWorker(worker1);
            testService.AddWorker(worker2);
        }

        [TestMethod]
        public void IsAddingNeededElement_ToRoot()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            EmployeeModel expected = employee1;
            // Act
            testService.AddRoot(employee1);

            // Assert
            EmployeeModel actual = testService.Root;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAddingNeededElement_ToCurrentEmployee()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            testService.AddRoot(root);
            EmployeeModel expected = employee1;
            // Act
            testService.AddEmployee(employee1);

            // Assert
            EmployeeModel actual = testService.CurrentEmployee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAddingNeededElement_IsWorkerAdded()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            testService.AddRoot(root);
            WorkerModel expected = worker1;
            // Act
            testService.AddWorker(worker1);

            // Assert
            WorkerModel actual = (WorkerModel)testService.CurrentEmployee.Subordinates.Find(x => x.Surname == "worker1" && x.Name == "worker1" && x.Salary == 20000 && x.Position == "worker1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsHierarchySetNeededElement()
        {
            // Arrange
            EmployeeModel expected = root;
            // Act
            testService.SetCurrentEmployee("root", "root");

            // Assert
            EmployeeModel actual = testService.CurrentEmployee;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsReturnExpectedList_MoreThanValueSalaryEmployees()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(root);
            expected.Add(employee1);
            // Act
            testService.AddRoot(root);
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.MoreThanValueSalaryEmployees(50000);
            CollectionAssert.AreEqual(expected, actual);
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
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(root);
            // Act
            testService.AddRoot(root);
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.MaxSalaryEmployees();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsReturnExpectedList_EmployeeSubordinates()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();

            testService.AddRoot(root);
            List<PersonComponent> expected = new List<PersonComponent>();
            expected.Add(employee1);
            // Act
            testService.AddEmployee(employee1);
            testService.AddWorker(worker1);

            // Assert
            List<PersonComponent> actual = testService.EmployeeSubordinates("root", "root");
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsReturnExpectedList_PositionEmployees()
        {
            // Arrange
            IOrganizationService testService = new OrganizationService();
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
            WorkerModel worker = new WorkerModel("worker", "worker", 10000, "worker");
            List<PersonComponent> expected = new List<PersonComponent>() { };
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