using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class CoffeeBean : BaseEntity
    {
        public int CoffeeBeanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CoffeeMixDetail> CoffeeMixDetails { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }

}
