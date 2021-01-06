using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeLab4.Controllers;
using System.Net.Http;

namespace CleanCodeLab4Tests
{
    [TestClass]
    public class CleanCodeLab4Tests
    {
        private readonly HomeController _homeController = new HomeController();

        public CleanCodeLab4Tests()
        {

        }

        [TestMethod]
        public void calling_to_create_http_request_should_return_type_of_http_request_message_when_called()
        {
            // Arrange
            decimal firstNumber = 3m;
            decimal secondNumber = 4m;
            var expected = typeof(HttpRequestMessage);

            // Act

            var actual = _homeController.CreateHttpRequest(HttpMethod.Get, firstNumber, secondNumber);
            
            // Assert
            Assert.AreEqual(expected, actual.GetType());
        }

        [TestMethod]
        public void sending_means_of_calculations_should_change_the_value_of_the_string_to_its_mathematical_operator()
        {
            // Arrange
            string meansOfCalculation = "addition";
            var expected = "+";

            // Act
            var actual = _homeController.ChangeStringValue(meansOfCalculation);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
