using CleanCodeLab4.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace CleanCodeLab4Tests
{
    [TestClass]
    public class CleanCodeLab4Tests
    {
        private readonly HomeController _homeController = new HomeController();
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;
        public CleanCodeLab4Tests()
        {

        }

        [TestMethod]
        public void handling_response_content_should_return_formatted_result_when_sent_data()
        {
            // Arrange
            string meansOfCalculation = "addition";
            decimal firstNumber = 40m;
            decimal secondNumber = 30m;
            string responseContent = (firstNumber + secondNumber).ToString();
            string expected = $"{40} + {30} = {70}";

            // Act
            var actual = _homeController.HandleResponse(meansOfCalculation, firstNumber, secondNumber, responseContent);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
