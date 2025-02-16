using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDto>> GetAllDiscountsAsync();
        Task<DiscountDto> GetDiscountByIdAsync(int id);
        Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto);
        Task<bool> UpdateDiscountAsync(DiscountDto discountDto);
        Task<bool> DeleteDiscountAsync(int id);
        Task<PagedResult<DiscountDto>> GetPagedDiscountsAsync(PageRequest pageRequest);
    }

}
