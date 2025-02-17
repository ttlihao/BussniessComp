using GuYou.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.DTOs
{
    public class ReviewDto : BaseEntity
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public int? CoffeeMixId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
    }

}
