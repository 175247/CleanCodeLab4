using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanCodeLab4.Data;
using CleanCodeLab4.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCodeLab4.Controllers
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

        // Testerna skall återställa databasen till tidigare stadium.
        [HttpDelete]
        public async Task<IActionResult> DeleteCalculations(int numberOfTestsRun)
        {
            var calculations = await _context.CalculationResults.ToListAsync();
            calculations.RemoveRange(calculations.Count - numberOfTestsRun, numberOfTestsRun);
            // Update Db
            _context.RemoveRange(calculations);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
