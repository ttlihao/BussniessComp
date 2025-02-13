using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.Models
{
    public class ReviewLike
    {
        public int ReviewLikeId { get; set; }
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
    }

}
