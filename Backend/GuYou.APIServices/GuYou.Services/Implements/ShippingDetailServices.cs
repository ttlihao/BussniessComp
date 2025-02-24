using AutoMapper;
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using GuYou.Repositories.Models;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class ShippingDetailServices : IShippingDetailService
    {
        private readonly ShippingDetailRepository _shippingDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public ShippingDetailServices(ShippingDetailRepository shippingDetailRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _shippingDetailRepository = shippingDetailRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<ShippingDetailDto>> GetAllShippingDetailsAsync()
        {
            var shippingDetails = await _shippingDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShippingDetailDto>>(shippingDetails);
        }

        public async Task<ShippingDetailDto> GetShippingDetailByIdAsync(int id)
        {
            var shippingDetailEntity = await _shippingDetailRepository.GetByIdAsync(id);
            return _mapper.Map<ShippingDetailDto>(shippingDetailEntity);
        }

        public async Task<ShippingDetailDto> CreateShippingDetailAsync(ShippingDetailDto newShippingDetailDto)
        {
            try
            {
                var newShippingDetail = _mapper.Map<ShippingDetail>(newShippingDetailDto);
                newShippingDetail.CreatedBy = _userContextService.GetCurrentUserId();
                newShippingDetail.LastUpdatedBy = newShippingDetail.CreatedBy;
                newShippingDetail.CreatedTime = _timeService.SystemTimeNow;
                newShippingDetail.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdShippingDetail = await _shippingDetailRepository.CreateAsync(newShippingDetail);
                return _mapper.Map<ShippingDetailDto>(createdShippingDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the shipping detail", ex);
            }
        }

        public async Task<bool> UpdateShippingDetailAsync(ShippingDetailDto updatedShippingDetailDto)
        {
            try
            {
                var existingShippingDetail = await _shippingDetailRepository.GetByIdAsync(updatedShippingDetailDto.ShippingDetailId);
                if (existingShippingDetail == null)
                {
                    throw new Exception("Shipping detail not found");
                }
                _mapper.Map(updatedShippingDetailDto, existingShippingDetail); // Map updated fields to existing entity
                existingShippingDetail.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingShippingDetail.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _shippingDetailRepository.UpdateAsync(existingShippingDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the shipping detail", ex);
            }
        }

        public async Task<bool> DeleteShippingDetailAsync(int id)
        {
            try
            {
                var entity = await _shippingDetailRepository.GetByIdAsync(id);
                return await _shippingDetailRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the shipping detail", ex);
            }
        }

        public async Task<PagedResult<ShippingDetailDto>> GetPagedShippingDetailsAsync(PageRequest pageRequest)
        {
            var pagedShippingDetails = await _shippingDetailRepository.GetPagedShippingDetailsAsync(pageRequest);
            return new PagedResult<ShippingDetailDto>
            {
                Items = _mapper.Map<List<ShippingDetailDto>>(pagedShippingDetails.Items),
                TotalCount = pagedShippingDetails.TotalCount,
                PageSize = pagedShippingDetails.PageSize,
                PageNumber = pagedShippingDetails.PageNumber
            };
        }
    }
}
