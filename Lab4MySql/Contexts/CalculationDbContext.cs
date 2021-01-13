using Lab4Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4MySql
{
    public class CalculationDbContext : DbContext
    {
        public DbSet<Calculation> Calculations { get; set; }
        public CalculationDbContext(DbContextOptions<CalculationDbContext> options) : base(options)
        {

        }
    }
}
