using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Unit_testing
{
    [TestClass]
    public class VisitorTest
    {
        private EmployeeModel _employee;
        private EmployeeModel _employee1;
        private EmployeeModel _employee2;

        [TestInitialize]
        public void TestInitialize()
        {
            _employee = new EmployeeModel() { Position = "testposition", Salary = 500 };
            _employee1 = new EmployeeModel() { Position = "pos", Salary = 100 };
            _employee2 = new EmployeeModel() { Position = "testposition", Salary = 500 };
        }

        [TestMethod]
        public void DoesReturnRightElement_Position()
        {
            //Arrange
            var visitor = new Mock<PositionVisitor>("testposition");
            var expectedPosition = _employee;
            //Act
            visitor.Object.VisitEmployee(_employee);
            visitor.Object.VisitEmployee(_employee1);
            //Assert
            var actualPosition = visitor.Object.Employees.Find(x => x.Position == "testposition");
            Assert.AreEqual(expectedPosition, actualPosition);
        }

        [TestMethod]
        public void DoesReturnRightElements_MoreThanValueSalary()
        {
            //Arrange
            var visitor = new Mock<EmployeeMoreThanValueSalaryVisitor>(200);
            var expectedSalary = new List<PersonComponent>() { _employee, _employee2 };
            //Act
            visitor.Object.VisitEmployee(_employee);
            visitor.Object.VisitEmployee(_employee1);
            visitor.Object.VisitEmployee(_employee2);
            //Assert
            var actualSalary = visitor.Object.Employees;
            CollectionAssert.AreEqual(expectedSalary, actualSalary);
        }

        [TestMethod]
        public void DoesReturnRightElements_MaxSalary()
        {
            //Arrange
            var visitor = new Mock<EmployeeMaxSalaryVisitor>();
            var expectedSalary = new List<PersonComponent>() { _employee, _employee2 };
            //Act
            visitor.Object.VisitEmployee(_employee);
            visitor.Object.VisitEmployee(_employee1);
            visitor.Object.VisitEmployee(_employee2);
            //Assert
            var actualSalary = visitor.Object.Employees;
            CollectionAssert.AreEqual(expectedSalary, actualSalary);
        }
    }
}