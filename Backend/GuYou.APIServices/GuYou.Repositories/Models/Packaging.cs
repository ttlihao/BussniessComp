using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class Packaging
    {
        public int PackagingId { get; set; }
        public string Shape { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Sticker { get; set; }
        public string Pattern { get; set; }
        public string TextMessage { get; set; }
        public virtual Category Category { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
