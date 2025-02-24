using AutoMapper;
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.Models;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class CoffeeBeanServices : ICoffeeBeanService
    {
        private readonly CoffeeBeanRepository _coffeeBeanRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public CoffeeBeanServices(CoffeeBeanRepository coffeeBeanRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _coffeeBeanRepository = coffeeBeanRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<CoffeeBeanDto>> GetAllCoffeeBeansAsync()
        {
            var coffeeBeans = await _coffeeBeanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CoffeeBeanDto>>(coffeeBeans);
        }

        public async Task<CoffeeBeanDto> GetCoffeeBeanByIdAsync(int id)
        {
            var coffeeBeanEntity = await _coffeeBeanRepository.GetByIdAsync(id);
            return _mapper.Map<CoffeeBeanDto>(coffeeBeanEntity);
        }

        public async Task<CoffeeBeanDto> CreateCoffeeBeanAsync(CoffeeBeanDto newCoffeeBeanDto)
        {
            try
            {
                var newCoffeeBean = _mapper.Map<CoffeeBean>(newCoffeeBeanDto);
                newCoffeeBean.CreatedBy = _userContextService.GetCurrentUserId();
                newCoffeeBean.LastUpdatedBy = newCoffeeBean.CreatedBy;
                newCoffeeBean.CreatedTime = _timeService.SystemTimeNow;
                newCoffeeBean.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdCoffeeBean = await _coffeeBeanRepository.CreateAsync(newCoffeeBean);
                return _mapper.Map<CoffeeBeanDto>(createdCoffeeBean);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the coffee bean", ex);
            }
        }

        public async Task<bool> UpdateCoffeeBeanAsync(CoffeeBeanDto updatedCoffeeBeanDto)
        {
            try
            {
                var existingCoffeeBean = await _coffeeBeanRepository.GetByIdAsync(updatedCoffeeBeanDto.CoffeeBeanId);
                if (existingCoffeeBean == null)
                {
                    throw new Exception("Coffee bean not found");
                }
                _mapper.Map(updatedCoffeeBeanDto, existingCoffeeBean); // Map updated fields to existing entity
                existingCoffeeBean.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingCoffeeBean.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _coffeeBeanRepository.UpdateAsync(existingCoffeeBean);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the coffee bean", ex);
            }
        }

        public async Task<bool> DeleteCoffeeBeanAsync(int id)
        {
            try
            {
                var entity = await _coffeeBeanRepository.GetByIdAsync(id);
                return await _coffeeBeanRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the coffee bean", ex);
            }
        }

        public async Task<PagedResult<CoffeeBeanDto>> GetPagedCoffeeBeansAsync(PageRequest pageRequest)
        {
            var pagedCoffeeBeans = await _coffeeBeanRepository.GetPagedCoffeeBeansAsync(pageRequest);
            return new PagedResult<CoffeeBeanDto>
            {
                Items = _mapper.Map<List<CoffeeBeanDto>>(pagedCoffeeBeans.Items),
                TotalCount = pagedCoffeeBeans.TotalCount,
                PageSize = pagedCoffeeBeans.PageSize,
                PageNumber = pagedCoffeeBeans.PageNumber
            };
        }
    }
}
