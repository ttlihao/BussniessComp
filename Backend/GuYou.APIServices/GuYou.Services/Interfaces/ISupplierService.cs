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
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
        Task<SupplierDto> GetSupplierByIdAsync(int id);
        Task<SupplierDto> CreateSupplierAsync(SupplierDto supplierDto);
        Task<bool> UpdateSupplierAsync(SupplierDto supplierDto);
        Task<bool> DeleteSupplierAsync(int id);
        Task<PagedResult<SupplierDto>> GetPagedSuppliersAsync(PageRequest pageRequest);
    }

}
