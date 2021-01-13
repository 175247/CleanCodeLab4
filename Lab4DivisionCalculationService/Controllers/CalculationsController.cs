using Microsoft.AspNetCore.Mvc;

namespace Lab4DivisionCalculationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : Controller
    {
        [HttpGet]
        public decimal Divide([FromQuery] decimal firstNumber, [FromQuery] decimal secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
