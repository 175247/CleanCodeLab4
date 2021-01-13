using Lab4DivisionCalculationService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdditionCalculationTests
{
    [TestClass]
    public class DivisionCalculationTests
    {
        private readonly CalculationsController _calculator;

        public DivisionCalculationTests()
        {
            _calculator = new CalculationsController();
        }

        [TestMethod]
        public void dividing_two_numbers_should_return_correct_amount_when_called()
        {
            // Arrange
            int firstNumber = 12;
            int secondNumber = 4;
            var expected = 3;

            // Act
            var actual = _calculator.Divide(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
