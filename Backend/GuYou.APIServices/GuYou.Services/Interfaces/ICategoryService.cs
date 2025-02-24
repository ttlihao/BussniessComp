
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.Request;

namespace GuYou.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequest request);
        Task<bool> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<PagedResult<CategoryDto>> GetPagedCategoriesAsync(PageRequest pageRequest);
    }

}
