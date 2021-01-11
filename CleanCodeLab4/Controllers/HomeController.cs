using CleanCodeLab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CleanCodeLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;

        //public HomeController()
        //{

        //}

        public HomeController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _client = _httpClient.CreateClient();
        }

        public async Task<IActionResult> Calculate(string meansOfCalculation, decimal firstNumber, decimal secondNumber)
        {
            var targetEndpoint = meansOfCalculation;
            var request = CreateHttpRequest(HttpMethod.Get, targetEndpoint, firstNumber, secondNumber);
            var responseContent = await SendRequestAndReadResponse(request);
            var result = HandleResponse(meansOfCalculation, firstNumber, secondNumber, responseContent);
            TempData["result"] = result;
            return View("Index");
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, string targetEndpoint, decimal firstNumber, decimal secondNumber)
        {
            var baseUri = $"http://{targetEndpoint}/api/calculations";
            var query = string.Format("?firstNumber={0}&secondNumber={1}", firstNumber, secondNumber);
            var requestUri = baseUri + query;
            var request = new HttpRequestMessage(httpMethod, requestUri);
            return request;
        }

        private async Task<string> SendRequestAndReadResponse(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private string HandleResponse(string meansOfCalculation, decimal firstNumber, decimal secondNumber, string responseContent)
        {
            meansOfCalculation = ChangeStringValue(meansOfCalculation);
            var result = string.Format("{0} {1} {2} = {3}", firstNumber, meansOfCalculation, secondNumber, responseContent);
            return result;
        }


        private string ChangeStringValue(string meansOfCalculation)
        {
            if (meansOfCalculation == "addition")
            {
                return meansOfCalculation = "+";
            }
            
            if (meansOfCalculation == "division")
            {
                return meansOfCalculation = "/";
            }

            if (meansOfCalculation == "multiplication")
            {
                return meansOfCalculation = "*";
            }

            else
            {
                return "invalid input";
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
