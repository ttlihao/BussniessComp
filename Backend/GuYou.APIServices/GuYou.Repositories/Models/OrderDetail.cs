using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int? CoffeeMixId { get; set; }

        [NotMapped]
        public CustomMixConfiguration CustomMixConfiguration { get; set; } // Custom mix configuration object

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual CoffeeMix CoffeeMix { get; set; }
    }


}
