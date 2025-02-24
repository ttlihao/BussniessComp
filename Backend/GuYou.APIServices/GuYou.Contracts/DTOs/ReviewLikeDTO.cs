using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.DTOs
{
    public class ReviewLikeDto
    {
        public int ReviewLikeId { get; set; }
        public int ReviewId { get; set; }
        public string UserId { get; set; }
    }
}
