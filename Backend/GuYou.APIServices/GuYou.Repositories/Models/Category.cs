using GuYou.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CoffeeBean> CoffeeBeans { get; set; }
        public virtual ICollection<Packaging> Packagings { get; set; }
    }
}
