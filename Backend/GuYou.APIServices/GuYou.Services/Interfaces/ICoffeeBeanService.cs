﻿using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface ICoffeeBeanService
    {
        Task<IEnumerable<CoffeeBeanDto>> GetAllCoffeeBeansAsync();
        Task<CoffeeBeanDto> GetCoffeeBeanByIdAsync(int id);
        Task<CoffeeBeanDto> CreateCoffeeBeanAsync(CoffeeBeanDto coffeeBeanDto);
        Task<bool> UpdateCoffeeBeanAsync(CoffeeBeanDto coffeeBeanDto);
        Task<bool> DeleteCoffeeBeanAsync(int id);
        Task<PagedResult<CoffeeBeanDto>> GetPagedCoffeeBeansAsync(PageRequest pageRequest);
    }

}
