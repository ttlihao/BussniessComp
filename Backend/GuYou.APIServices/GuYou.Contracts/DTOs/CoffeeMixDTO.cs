using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.DTOs
{
    public class CoffeeMixDto
    {
        public int CoffeeMixId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double WeightInKilograms { get; set; }
    }

}
