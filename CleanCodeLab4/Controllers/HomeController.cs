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
using Newtonsoft.Json;

namespace CleanCodeLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;
        private readonly CalculationDbContext _context;

        public HomeController(IHttpClientFactory httpClient, CalculationDbContext context)
        {
            _httpClient = httpClient;
            _client = _httpClient.CreateClient();
            _context = context;
        }

        public async Task<IActionResult> Calculate(string meansOfCalculation, decimal firstNumber, decimal secondNumber)
        {
            var request = CreateHttpRequest(HttpMethod.Get, meansOfCalculation, firstNumber, secondNumber);
            var responseContent = await SendRequestAndReadResponse(request);
            var calculationsResult = new CalculationResult { MeansOfCalculation = meansOfCalculation, FirstNumber = firstNumber, SecondNumber = secondNumber };
            await StoreCalculationInDatabase(calculationsResult);
            var resultMessage = FormatResultMessage(meansOfCalculation, firstNumber, secondNumber, responseContent);

            TempData["result"] = resultMessage;
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

        private string FormatResultMessage(string meansOfCalculation, decimal firstNumber, decimal secondNumber, string responseContent)
        {
            meansOfCalculation = ChangeStringValue(meansOfCalculation);
            var result = string.Format("{0} {1} {2} = {3}", firstNumber, meansOfCalculation, secondNumber, responseContent);
            return result;
        }


        private string ChangeStringValue(string meansOfCalculation)
        {
            switch (meansOfCalculation)
            {
                case "addition":
                    return "+"; 
                case "division":
                    return "/";
                case "multiplication":
                    return "*";
                default:
                    return "invalid input";
            }
        }

        [HttpPut]
        private async Task<IActionResult> StoreCalculationInDatabase(CalculationResult calculationsResult)
        {
            _context.Add(calculationsResult);
            await _context.SaveChangesAsync();
            return Created("storageUri", calculationsResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calculations = await _context.CalculationResults.ToListAsync();
            if (calculations.Count == 0)
            {
                return NoContent();
            }

            return Ok(calculations);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCalculations([FromQuery] int numberOfTestsRun)
        {
            var calculations = await _context.CalculationResults.ToListAsync();
            if (numberOfTestsRun <= 0
                || numberOfTestsRun > calculations.Count)
            {
                return BadRequest();
            }
            else if (calculations.Count == 0)
            {
                return NotFound();
            }
            else
            {
                var calculationsToRemove = calculations.TakeLast(numberOfTestsRun);
                _context.RemoveRange(calculationsToRemove);
                await _context.SaveChangesAsync();

                return Ok();
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
