using Lab4Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4MySql
{
    [ApiController, Route("api/[controller]")]
    public class CalculationsController : ControllerBase
    {
        private readonly CalculationDbContext _calculationDbContext;

        public CalculationsController(CalculationDbContext calculationDbContext)
        {
            _calculationDbContext = calculationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculation>>> GetAllItemsFromDb()
        {
            return Ok(await _calculationDbContext.Calculations.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Calculation>>> GetItemFromDb(int id)
        {
            var calculation = await _calculationDbContext.Calculations.FindAsync(id);

            if(calculation == null)
            {
                return NotFound();
            }

            return Ok(calculation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculation([FromQuery] int id, [FromBody] Calculation calculation)
        {
            if(id != calculation.CalculationId)
            {
                return BadRequest();
            }

            _calculationDbContext.Entry(calculation).State = EntityState.Modified;

            try
            {
                await _calculationDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!IsOrderExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Calculation>> PostCalculation([FromBody] Calculation calculation)
        {
            var entity = _calculationDbContext.Calculations.Add(calculation).Entity;
            await _calculationDbContext.SaveChangesAsync();

            return new OkObjectResult(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Calculation>> DeleteCalculation(int id)
        {
            var calculation = await _calculationDbContext.Calculations.FindAsync(id);

            if(calculation == null)
            {
                return NotFound();
            }

            _calculationDbContext.Calculations.Remove(calculation);

            await _calculationDbContext.SaveChangesAsync();

            return Ok(calculation);
        }

        private bool IsOrderExists(int id)
        {
            return _calculationDbContext.Calculations.Any(e => e.CalculationId == id);
        }
    }
}
