using Microsoft.AspNetCore.Mvc;

namespace Lab4AdditionCalculationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : Controller
    {
        [HttpGet]
        public decimal Multiply([FromQuery] decimal firstNumber, [FromQuery] decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
