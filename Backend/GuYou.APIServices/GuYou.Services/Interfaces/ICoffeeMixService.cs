using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface ICoffeeMixService
    {
        Task<IEnumerable<CoffeeMixDto>> GetAllCoffeeMixesAsync();
        Task<CoffeeMixDto> GetCoffeeMixByIdAsync(int id);
        Task<CoffeeMixDto> CreateCoffeeMixAsync(CoffeeMixDto coffeeMixDto);
        Task<bool> UpdateCoffeeMixAsync(CoffeeMixDto coffeeMixDto);
        Task<bool> DeleteCoffeeMixAsync(int id);
        Task<PagedResult<CoffeeMixDto>> GetPagedCoffeeMixesAsync(PageRequest pageRequest);
    }

}
