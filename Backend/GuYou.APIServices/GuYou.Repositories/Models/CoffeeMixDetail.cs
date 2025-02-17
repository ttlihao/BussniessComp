using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class CoffeeMixDetail
    {
        public int CoffeeMixDetailId { get; set; }
        public int CoffeeMixId { get; set; }
        public int CoffeeBeanId { get; set; }
        public int Percentage { get; set; }
        public virtual CoffeeMix CoffeeMix { get; set; }
        public virtual CoffeeBean CoffeeBean { get; set; }
    }   
}
    