using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exceptions.BuilderExceptions;
using Moq;
using BusinessLogic;

namespace Unit_testing
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void Is_DoAlgorithm_Method_Being_Invoked()
        {
            // arrange
            var testperson = new EmployeeModel();
            var strategytest = new Mock<IStrategy>();
            // act
            strategytest.Object.DoAlgorithm(testperson);
            strategytest.Object.DoAlgorithm(testperson);
            // assert
            strategytest.Verify(x => x.DoAlgorithm(testperson), Times.Exactly(2));
        }
    }
}
