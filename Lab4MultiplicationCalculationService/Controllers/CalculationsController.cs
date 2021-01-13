using Microsoft.AspNetCore.Mvc;

namespace Lab4MultiplicationCalculationService.Controllers
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
