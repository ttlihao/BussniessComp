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
    public class CoffeeMixDetailServices : ICoffeeMixDetailService
    {
        private readonly CoffeeMixDetailRepository _coffeeMixDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public CoffeeMixDetailServices(CoffeeMixDetailRepository coffeeMixDetailRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _coffeeMixDetailRepository = coffeeMixDetailRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<CoffeeMixDetailDto>> GetAllCoffeeMixDetailsAsync()
        {
            var coffeeMixDetails = await _coffeeMixDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CoffeeMixDetailDto>>(coffeeMixDetails);
        }

        public async Task<CoffeeMixDetailDto> GetCoffeeMixDetailByIdAsync(int id)
        {
            var coffeeMixDetailEntity = await _coffeeMixDetailRepository.GetByIdAsync(id);
            return _mapper.Map<CoffeeMixDetailDto>(coffeeMixDetailEntity);
        }

        public async Task<CoffeeMixDetailDto> CreateCoffeeMixDetailAsync(CoffeeMixDetailDto newCoffeeMixDetailDto)
        {
            try
            {
                var newCoffeeMixDetail = _mapper.Map<CoffeeMixDetail>(newCoffeeMixDetailDto);
                var createdCoffeeMixDetail = await _coffeeMixDetailRepository.CreateAsync(newCoffeeMixDetail);
                return _mapper.Map<CoffeeMixDetailDto>(createdCoffeeMixDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the coffee mix detail", ex);
            }
        }

        public async Task<bool> UpdateCoffeeMixDetailAsync(CoffeeMixDetailDto updatedCoffeeMixDetailDto)
        {
            try
            {
                var existingCoffeeMixDetail = await _coffeeMixDetailRepository.GetByIdAsync(updatedCoffeeMixDetailDto.CoffeeMixDetailId);
                if (existingCoffeeMixDetail == null)
                {
                    throw new Exception("Coffee mix detail not found");
                }
                _mapper.Map(updatedCoffeeMixDetailDto, existingCoffeeMixDetail); // Map updated fields to existing entity
                return await _coffeeMixDetailRepository.UpdateAsync(existingCoffeeMixDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the coffee mix detail", ex);
            }
        }

        public async Task<bool> DeleteCoffeeMixDetailAsync(int id)
        {
            try
            {
                var entity = await _coffeeMixDetailRepository.GetByIdAsync(id);
                return await _coffeeMixDetailRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the coffee mix detail", ex);
            }
        }

        public async Task<PagedResult<CoffeeMixDetailDto>> GetPagedCoffeeMixDetailsAsync(PageRequest pageRequest)
        {
            var pagedCoffeeMixDetails = await _coffeeMixDetailRepository.GetPagedCoffeeMixDetailsAsync(pageRequest);
            return new PagedResult<CoffeeMixDetailDto>
            {
                Items = _mapper.Map<List<CoffeeMixDetailDto>>(pagedCoffeeMixDetails.Items),
                TotalCount = pagedCoffeeMixDetails.TotalCount,
                PageSize = pagedCoffeeMixDetails.PageSize,
                PageNumber = pagedCoffeeMixDetails.PageNumber
            };
        }
    }
}
