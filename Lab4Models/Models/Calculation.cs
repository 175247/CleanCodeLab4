using System.ComponentModel.DataAnnotations;

namespace Lab4Models
{
    public class Calculation
    {
        [Key]
        public int CalculationId { get; set; }
        public string TypeOfCalculation { get; set; }
        public decimal NumberOne { get; set; }
        public decimal NumberTwo { get; set; }
        public string Result { get; set; }
    }
}
