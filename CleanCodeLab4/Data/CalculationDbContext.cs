using CleanCodeLab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeLab4.Data
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
