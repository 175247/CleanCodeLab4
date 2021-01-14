using CleanCodeLab4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using CleanCodeLab4.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;
        private readonly CalculationDbContext _context;

        //public HomeController()
        //{

        //}

        public HomeController(IHttpClientFactory httpClient, CalculationDbContext context)
        {
            _httpClient = httpClient;
            _client = _httpClient.CreateClient();
            _context = context;
        }

        public async Task<IActionResult> Calculate(string meansOfCalculation, decimal firstNumber, decimal secondNumber)
        {
            var targetEndpoint = meansOfCalculation;
            var request = CreateHttpRequest(HttpMethod.Get, targetEndpoint, firstNumber, secondNumber);
            var responseContent = await SendRequestAndReadResponse(request);
            var result = HandleResponse(meansOfCalculation, firstNumber, secondNumber, responseContent);

            var calculationsResult = new CalculationResult { MeansOfCalculation = meansOfCalculation, FirstNumber = firstNumber, SecondNumber = secondNumber };
            _context.Add(calculationsResult);
            await _context.SaveChangesAsync();

            TempData["result"] = result;
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var calculations = await _context.CalculationResults.ToListAsync();
            var result = calculations.FirstOrDefault();
            TempData["result"] = result.MeansOfCalculation;
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
