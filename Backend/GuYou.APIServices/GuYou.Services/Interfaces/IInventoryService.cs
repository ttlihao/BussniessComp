using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetAllInventoriesAsync();
        Task<InventoryDto> GetInventoryByIdAsync(int id);
        Task<InventoryDto> CreateInventoryAsync(InventoryDto inventoryDto);
        Task<bool> UpdateInventoryAsync(InventoryDto inventoryDto);
        Task<bool> DeleteInventoryAsync(int id);
        Task<PagedResult<InventoryDto>> GetPagedInventoriesAsync(PageRequest pageRequest);
    }

}
