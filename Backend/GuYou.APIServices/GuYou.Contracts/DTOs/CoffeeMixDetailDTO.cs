using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.DTOs
{
    public class CoffeeMixDetailDto
    {
        public int CoffeeMixDetailId { get; set; }
        public int CoffeeMixId { get; set; }
        public int CoffeeBeanId { get; set; }
        public int Percentage { get; set; }
    }

}
