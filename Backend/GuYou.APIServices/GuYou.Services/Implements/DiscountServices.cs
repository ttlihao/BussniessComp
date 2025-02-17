using AutoMapper;
using GuYou.Repositories.DTOs;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class DiscountServices : IDiscountService
    {
        private readonly DiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public DiscountServices(DiscountRepository discountRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<DiscountDto>> GetAllDiscountsAsync()
        {
            var discounts = await _discountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiscountDto>>(discounts);
        }

        public async Task<DiscountDto> GetDiscountByIdAsync(int id)
        {
            var discountEntity = await _discountRepository.GetByIdAsync(id);
            return _mapper.Map<DiscountDto>(discountEntity);
        }

        public async Task<DiscountDto> CreateDiscountAsync(DiscountDto newDiscountDto)
        {
            try
            {
                var newDiscount = _mapper.Map<Discount>(newDiscountDto);
                newDiscount.CreatedBy = _userContextService.GetCurrentUserId();
                newDiscount.LastUpdatedBy = newDiscount.CreatedBy;
                newDiscount.CreatedTime = _timeService.SystemTimeNow;
                newDiscount.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdDiscount = await _discountRepository.CreateAsync(newDiscount);
                return _mapper.Map<DiscountDto>(createdDiscount);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the discount", ex);
            }
        }

        public async Task<bool> UpdateDiscountAsync(DiscountDto updatedDiscountDto)
        {
            try
            {
                var existingDiscount = await _discountRepository.GetByIdAsync(updatedDiscountDto.DiscountId);
                if (existingDiscount == null)
                {
                    throw new Exception("Discount not found");
                }
                _mapper.Map(updatedDiscountDto, existingDiscount); // Map updated fields to existing entity
                existingDiscount.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingDiscount.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _discountRepository.UpdateAsync(existingDiscount);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the discount", ex);
            }
        }

        public async Task<bool> DeleteDiscountAsync(int id)
        {
            try
            {
                var entity = await _discountRepository.GetByIdAsync(id);
                return await _discountRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the discount", ex);
            }
        }

        public async Task<PagedResult<DiscountDto>> GetPagedDiscountsAsync(PageRequest pageRequest)
        {
            var pagedDiscounts = await _discountRepository.GetPagedDiscountsAsync(pageRequest);
            return new PagedResult<DiscountDto>
            {
                Items = _mapper.Map<List<DiscountDto>>(pagedDiscounts.Items),
                TotalCount = pagedDiscounts.TotalCount,
                PageSize = pagedDiscounts.PageSize,
                PageNumber = pagedDiscounts.PageNumber
            };
        }
    }
}
