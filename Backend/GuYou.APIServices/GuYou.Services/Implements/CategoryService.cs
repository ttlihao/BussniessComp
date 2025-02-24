using AutoMapper;
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.Request;
using GuYou.Repositories.Models;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public CategoryService(CategoryRepository categoryRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequest newCategoryDto)
        {
            try
            {
                var newCategory = _mapper.Map<Category>(newCategoryDto);
                newCategory.CreatedBy = _userContextService.GetCurrentUserId();
                newCategory.LastUpdatedBy = newCategory.CreatedBy;
                newCategory.CreatedTime = _timeService.SystemTimeNow;
                newCategory.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdCategory = await _categoryRepository.CreateAsync(newCategory);
                return _mapper.Map<CategoryDto>(createdCategory);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category", ex);
            }
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto updatedCategoryDto)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(updatedCategoryDto.CategoryId);
                if (existingCategory == null)
                {
                    throw new Exception("Category not found");
                }
                _mapper.Map(updatedCategoryDto, existingCategory); // Map updated fields to existing entity
                existingCategory.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingCategory.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _categoryRepository.UpdateAsync(existingCategory);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the category", ex);
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var entity = await _categoryRepository.GetByIdAsync(id);
                return await _categoryRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the category", ex);
            }
        }

        public async Task<PagedResult<CategoryDto>> GetPagedCategoriesAsync(PageRequest pageRequest)
        {
            var pagedCategories = await _categoryRepository.GetPagedCategorysAsync(pageRequest);
            return new PagedResult<CategoryDto>
            {
                Items = _mapper.Map<List<CategoryDto>>(pagedCategories.Items),
                TotalCount = pagedCategories.TotalCount,
                PageSize = pagedCategories.PageSize,
                PageNumber = pagedCategories.PageNumber
            };
        }
    }
}
