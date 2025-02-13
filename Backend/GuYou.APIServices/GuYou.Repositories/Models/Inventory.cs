using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class Inventory : BaseEntity           
    {
        public int InventoryId { get; set; }
        public int CoffeeBeanId { get; set; }
        public int PackagingId { get; set; }
        public double QuantityInKilograms { get; set; } // Quantity left in kilograms
        public virtual CoffeeBean CoffeeBean { get; set; }
        public virtual Packaging Packaging { get; set; }
    }

}
