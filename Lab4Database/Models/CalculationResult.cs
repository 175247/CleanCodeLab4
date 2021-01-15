using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Database.Models
{
    public class CalculationResult
    {
        public int Id { get; set; }
        public string MeansOfCalculation { get; set; }
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public decimal Result { get; set; }
    }
}
