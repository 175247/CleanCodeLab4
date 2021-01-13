using Lab4Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
