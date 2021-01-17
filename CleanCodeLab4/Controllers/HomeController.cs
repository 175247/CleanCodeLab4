using CleanCodeLab4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using Lab4Models;
using System.Text.Json;
using System.Text;

namespace CleanCodeLab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;

        private Dictionary<string, string> OperatorTable { get; set; } = new Dictionary<string, string>
        {
            {"addition", "addition" },
            {"division", "division" },
            {"multiplication", "multiplication" },
        };

        private Dictionary<string, string> OperatorSymbolTable { get; set; } = new Dictionary<string, string>
        {
            {"addition", "+" },
            {"division", "/" },
            {"multiplication", "*" },
        };

        public HomeController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _client = _httpClient.CreateClient();
        }

        public async Task<IActionResult> Calculate(string meansOfCalculation, int firstNumber, int secondNumber)
        {
            if (!OperatorTable.ContainsKey(meansOfCalculation)) 
            {
                return BadRequest();
            }

            var targetEndpoint = OperatorTable[meansOfCalculation];
            var request = CreateHttpRequest(HttpMethod.Get, targetEndpoint, firstNumber, secondNumber);
            var responseContent = await SendRequestAndReadResponse(request);
            var result = HandleResponse(meansOfCalculation, firstNumber, secondNumber, responseContent);

            var saveRequest = SendResultToDatabase(new Calculation
            {
                NumberOne = firstNumber,
                NumberTwo = secondNumber,
                Result = result,
                TypeOfCalculation = ChangeStringValue(meansOfCalculation)
            });

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var json = await (await _client.SendAsync(saveRequest)).Content.ReadAsStringAsync();
            var entity = JsonSerializer.Deserialize<Calculation>(json, jsonOptions);

            var id = entity.CalculationId;

            TempData["result"] = result;
            TempData["entityId"] = id.ToString();

            return View("Index");
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod httpMethod, string targetEndpoint, decimal firstNumber, decimal secondNumber)
        {
            var baseUri = $"http://{targetEndpoint}/api/Calculations";
            var query = string.Format("?firstNumber={0}&secondNumber={1}", firstNumber, secondNumber);
            var requestUri = baseUri + query;
            var request = new HttpRequestMessage(httpMethod, requestUri);

            return request;
        }

        private HttpRequestMessage SendResultToDatabase (Calculation calculation)
        {
            var baseUri = "http://mysql/api/Calculations";
            var request = new HttpRequestMessage(HttpMethod.Post, baseUri);
            
            request.Content = new StringContent(JsonSerializer.Serialize(calculation), Encoding.UTF8, "application/json");
            
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
            var usedOperator = ChangeStringValue(meansOfCalculation);
            var result = string.Format("{0} {1} {2} = {3}", firstNumber, usedOperator, secondNumber, responseContent);

            return result;
        }

        private string ChangeStringValue(string meansOfCalculation) =>
            !OperatorSymbolTable.ContainsKey(meansOfCalculation) 
                ? "Invalid input"
                : OperatorSymbolTable[meansOfCalculation];

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