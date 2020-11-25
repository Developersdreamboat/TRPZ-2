using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Exceptions.BuilderExceptions;
using Moq;
using BusinessLogic;


namespace Unit_testing
{
    [TestClass]
    public class VisitorTest
    {
        [TestMethod]
        public void DoesReturnRightElement_Position() 
        {
            //Arrange
            var employee = new EmployeeModel() { Position = "testposition"};
            var employee1 = new EmployeeModel() { Position ="pos"};
            var visitor = new Mock<PositionVisitor>("testposition");
            var expectedposition = employee;
            //Act
            visitor.Object.VisitEmployee(employee);
            visitor.Object.VisitEmployee(employee1);
            //Assert
            var actualposition = visitor.Object.Employees.Find(x=>x.Position=="testposition");
            Assert.AreEqual(expectedposition, actualposition);
        }
        [TestMethod]
        public void DoesReturnRightElements_MoreThanValueSalary()
        {
            //Arrange
            var employee = new EmployeeModel() { Salary = 500 };
            var employee1 = new EmployeeModel() { Salary = 100 };
            var employee2 = new EmployeeModel() { Salary =  400 };
            var visitor = new Mock<EmployeeMoreThanValueSalaryVisitor>(200);
            var expectedsalary = new List<PersonComponent>() {employee,employee2 };
            //Act
            visitor.Object.VisitEmployee(employee);
            visitor.Object.VisitEmployee(employee1);
            visitor.Object.VisitEmployee(employee2);
            //Assert
            var actualsalary = visitor.Object.Employees;
            CollectionAssert.AreEqual(expectedsalary, actualsalary);
        }
        [TestMethod]
        public void DoesReturnRightElements_MaxSalary()
        {
            //Arrange
            var employee = new EmployeeModel() { Salary = 500 };
            var employee1 = new EmployeeModel() { Salary = 100 };
            var employee2 = new EmployeeModel() { Salary = 400 };
            var visitor = new Mock<EmployeeMaxSalaryVisitor>();
            var expectedsalary = new List<PersonComponent>() { employee };
            //Act
            visitor.Object.VisitEmployee(employee);
            visitor.Object.VisitEmployee(employee1);
            visitor.Object.VisitEmployee(employee2);
            //Assert
            var actualsalary = visitor.Object.Employees;
            CollectionAssert.AreEqual(expectedsalary, actualsalary);
        }
    }
}
