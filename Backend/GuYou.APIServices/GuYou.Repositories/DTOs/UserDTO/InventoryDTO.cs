using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Repositories.DTOs.UserDTO
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }
        public int CoffeeBeanId { get; set; }
        public int PackagingId { get; set; }
        public double QuantityInKilograms { get; set; }
    }

}
