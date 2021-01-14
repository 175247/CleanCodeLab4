using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        private readonly CalculationDbContext _context;

        public DatabaseController(CalculationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCalculations()
        {
            var calculations = await _context.CalculationResults.ToListAsync();
            return Ok(calculations);
        }

        [HttpPut]
        public async Task<IActionResult> StoreCalculation(CalculationResult calculationResult)
        {
            _context.Add(calculationResult);
            await _context.SaveChangesAsync();
            return Created("storage", calculationResult);
        }
    }
}
