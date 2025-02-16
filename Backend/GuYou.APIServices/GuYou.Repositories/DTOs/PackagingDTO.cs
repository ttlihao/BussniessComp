using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.DTOs
{
    public class PackagingDto
    {
        public int PackagingId { get; set; }
        public string Shape { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Sticker { get; set; }
        public string Pattern { get; set; }
        public string TextMessage { get; set; }
    }

}
