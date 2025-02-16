using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface ICoffeeMixDetailService
    {
        Task<IEnumerable<CoffeeMixDetailDto>> GetAllCoffeeMixDetailsAsync();
        Task<CoffeeMixDetailDto> GetCoffeeMixDetailByIdAsync(int id);
        Task<CoffeeMixDetailDto> CreateCoffeeMixDetailAsync(CoffeeMixDetailDto coffeeMixDetailDto);
        Task<bool> UpdateCoffeeMixDetailAsync(CoffeeMixDetailDto coffeeMixDetailDto);
        Task<bool> DeleteCoffeeMixDetailAsync(int id);
        Task<PagedResult<CoffeeMixDetailDto>> GetPagedCoffeeMixDetailsAsync(PageRequest pageRequest);
    }

}
