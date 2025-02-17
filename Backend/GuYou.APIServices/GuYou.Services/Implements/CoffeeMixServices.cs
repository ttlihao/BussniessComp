using AutoMapper;
using GuYou.Repositories.DTOs;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class CoffeeMixServices : ICoffeeMixService
    {
        private readonly CoffeeMixRepository _coffeeMixRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public CoffeeMixServices(CoffeeMixRepository coffeeMixRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _coffeeMixRepository = coffeeMixRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<CoffeeMixDto>> GetAllCoffeeMixesAsync()
        {
            var coffeeMixes = await _coffeeMixRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CoffeeMixDto>>(coffeeMixes);
        }

        public async Task<CoffeeMixDto> GetCoffeeMixByIdAsync(int id)
        {
            var coffeeMixEntity = await _coffeeMixRepository.GetByIdAsync(id);
            return _mapper.Map<CoffeeMixDto>(coffeeMixEntity);
        }

        public async Task<CoffeeMixDto> CreateCoffeeMixAsync(CoffeeMixDto newCoffeeMixDto)
        {
            try
            {
                var newCoffeeMix = _mapper.Map<CoffeeMix>(newCoffeeMixDto);
                newCoffeeMix.CreatedBy = _userContextService.GetCurrentUserId();
                newCoffeeMix.LastUpdatedBy = newCoffeeMix.CreatedBy;
                newCoffeeMix.CreatedTime = _timeService.SystemTimeNow;
                newCoffeeMix.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdCoffeeMix = await _coffeeMixRepository.CreateAsync(newCoffeeMix);
                return _mapper.Map<CoffeeMixDto>(createdCoffeeMix);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the coffee mix", ex);
            }
        }

        public async Task<bool> UpdateCoffeeMixAsync(CoffeeMixDto updatedCoffeeMixDto)
        {
            try
            {
                var existingCoffeeMix = await _coffeeMixRepository.GetByIdAsync(updatedCoffeeMixDto.CoffeeMixId);
                if (existingCoffeeMix == null)
                {
                    throw new Exception("Coffee mix not found");
                }
                _mapper.Map(updatedCoffeeMixDto, existingCoffeeMix); // Map updated fields to existing entity
                existingCoffeeMix.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingCoffeeMix.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _coffeeMixRepository.UpdateAsync(existingCoffeeMix);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the coffee mix", ex);
            }
        }

        public async Task<bool> DeleteCoffeeMixAsync(int id)
        {
            try
            {
                var entity = await _coffeeMixRepository.GetByIdAsync(id);
                return await _coffeeMixRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the coffee mix", ex);
            }
        }

        public async Task<PagedResult<CoffeeMixDto>> GetPagedCoffeeMixesAsync(PageRequest pageRequest)
        {
            var pagedCoffeeMixes = await _coffeeMixRepository.GetPagedCoffeeMixesAsync(pageRequest);
            return new PagedResult<CoffeeMixDto>
            {
                Items = _mapper.Map<List<CoffeeMixDto>>(pagedCoffeeMixes.Items),
                TotalCount = pagedCoffeeMixes.TotalCount,
                PageSize = pagedCoffeeMixes.PageSize,
                PageNumber = pagedCoffeeMixes.PageNumber
            };
        }
    }
}
