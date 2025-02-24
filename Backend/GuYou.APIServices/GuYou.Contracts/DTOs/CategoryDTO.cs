using GuYou.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.DTOs
{
    public class CategoryDto : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }

}
