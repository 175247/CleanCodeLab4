using CleanCodeLab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab4AdditionCalculationService.Controllers;
using System.Net.Http;

namespace CleanCodeLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public HomeController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Calculate(string meansOfCalculation, decimal firstNumber, decimal secondNumber)
        {
            var client = _httpClient.CreateClient();
            var request = CreateHttpRequest(HttpMethod.Get, firstNumber, secondNumber);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            meansOfCalculation = ChangeStringValue(meansOfCalculation);
            var result = string.Format("{0} {1} {2} = {3}", firstNumber, meansOfCalculation, secondNumber, content);
            TempData["result"] = result;
            return View("Index");
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, decimal firstNumber, decimal secondNumber)
        {
            var baseUri = "https://localhost:49159/api/additioncalculations"; // Edit this to target the alias/host-name for the service in docker-compose.
            var query = string.Format("?firstNumber={0}&secondNumber={1}", firstNumber, secondNumber);
            var requestUri = baseUri + query;
            var request = new HttpRequestMessage(httpMethod, requestUri);
            return request;
        }

        private string ChangeStringValue(string meansOfCalculation)
        {
            if (meansOfCalculation == "addition")
            {
                return meansOfCalculation = "+";
            }
            else if (meansOfCalculation == "divison")
            {
                return meansOfCalculation = "/";
            }
            else
            {
                return meansOfCalculation = "*";
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
