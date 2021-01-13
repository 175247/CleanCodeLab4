using Lab4MultiplicationCalculationService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdditionCalculationTests
{
    [TestClass]
    public class MultiplicationCalculationTests
    {
        private readonly CalculationsController _calculator;

        public MultiplicationCalculationTests()
        {
            _calculator = new CalculationsController();
        }

        [TestMethod]
        public void multiplying_two_numbers_should_return_correct_amount_when_called()
        {
            // Arrange
            int firstNumber = 5;
            int secondNumber = 6;
            var expected = 30;

            // Act
            var actual = _calculator.Multiply(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
