using GuYou.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class Discount : BaseEntity
    {
        public int DiscountId { get; set; }
        public string Code { get; set; } // Code for users to input and use the discount
        public decimal DiscountAmount { get; set; } // Fixed amount discount
        public decimal DiscountPercentage { get; set; } // Percentage discount
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}
