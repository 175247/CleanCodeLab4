using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Database.Models
{
    public class CalculationDbContext : DbContext
    {
        public DbSet<CalculationResult> CalculationResults { get; set; }

        public CalculationDbContext(DbContextOptions<CalculationDbContext> options)
            : base(options)
        {

        }
    }
}
