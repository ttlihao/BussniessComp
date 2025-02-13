using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; } // Total discount amount applied to the order
        public int? DiscountId { get; set; } // Reference to the applied discount
        public int? PackagingId { get; set; } // Reference to the selected packaging
        public virtual User User { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual Packaging Packaging { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }
    }

}
