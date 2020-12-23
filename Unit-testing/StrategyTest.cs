using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unit_testing
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void Is_DisplayEmployees_Method_Being_Invoked()
        {
            // arrange
            var testperson = new EmployeeModel();
            var strategytest = new Mock<IStrategy>();
            // act
            strategytest.Object.DisplayEmployees(testperson);
            strategytest.Object.DisplayEmployees(testperson);
            // assert
            strategytest.Verify(x => x.DisplayEmployees(testperson), Times.Exactly(2));
        }
    }
}