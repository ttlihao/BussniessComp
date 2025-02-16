using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IShippingDetailService
    {
        Task<IEnumerable<ShippingDetailDto>> GetAllShippingDetailsAsync();
        Task<ShippingDetailDto> GetShippingDetailByIdAsync(int id);
        Task<ShippingDetailDto> CreateShippingDetailAsync(ShippingDetailDto shippingDetailDto);
        Task<bool> UpdateShippingDetailAsync(ShippingDetailDto shippingDetailDto);
        Task<bool> DeleteShippingDetailAsync(int id);
        Task<PagedResult<ShippingDetailDto>> GetPagedShippingDetailsAsync(PageRequest pageRequest);
    }

}
