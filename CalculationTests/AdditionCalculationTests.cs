using Lab4AdditionCalculationService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdditionCalculationTests
{
    [TestClass]
    public class AdditionCalculationTests
    {
        private readonly CalculationsController _calculator;

        public AdditionCalculationTests()
        {
            _calculator = new CalculationsController();
        }

        [TestMethod]
        public void adding_two_numbers_together_should_return_correct_amount_when_called()
        {
            // Arrange
            int firstNumber = 3;
            int secondNumber = 4;
            var expected = 7;

            // Act
            var actual = _calculator.Add(firstNumber, secondNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
