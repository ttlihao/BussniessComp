using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Contracts.Request
{
    public class CreateCategoryRequest
    {
        public required string Name { get; set; }
    }
}
