using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<PagedResult<CategoryDto>> GetPagedCategoriesAsync(PageRequest pageRequest);
    }

}
