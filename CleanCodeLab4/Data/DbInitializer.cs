using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanCodeLab4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanCodeLab4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CalculationDbContext>());
            }
        }

        public static void SeedData(CalculationDbContext context)
        {
            Console.WriteLine("Applying migrations...");
            context.Database.Migrate();

            if (!context.CalculationResults.Any())
            {
                Console.WriteLine("Seeding data");
                context.CalculationResults.AddRange(
                    new CalculationResult { MeansOfCalculation = "addition", FirstNumber = 1m, SecondNumber = 2m },
                    new CalculationResult { MeansOfCalculation = "division", FirstNumber = 2m, SecondNumber = 2m },
                    new CalculationResult { MeansOfCalculation = "multiplication", FirstNumber = 2m, SecondNumber = 2m }
                    );
            }
            else
            {
                Console.WriteLine("Database already contains data. Will not seed.");
            }
        }
    }
}
