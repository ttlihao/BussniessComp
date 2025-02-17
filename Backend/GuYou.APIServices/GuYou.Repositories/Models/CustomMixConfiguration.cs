using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class CustomMixConfiguration
    {
        public List<MixComponent> Components { get; set; }
        public double WeightInKilograms { get; set; }
    }

    public class MixComponent
    {
        public int CoffeeBeanId { get; set; }
        public string CoffeeBeanName { get; set; }
        public int Percentage { get; set; }
    }

}
