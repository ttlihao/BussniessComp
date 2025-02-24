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
    public class PackagingServices : IPackagingService
    {
        private readonly PackagingRepository _packagingRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public PackagingServices(PackagingRepository packagingRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _packagingRepository = packagingRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<PackagingDto>> GetAllPackagingsAsync()
        {
            var packagings = await _packagingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PackagingDto>>(packagings);
        }

        public async Task<PackagingDto> GetPackagingByIdAsync(int id)
        {
            var packagingEntity = await _packagingRepository.GetByIdAsync(id);
            return _mapper.Map<PackagingDto>(packagingEntity);
        }

        public async Task<PackagingDto> CreatePackagingAsync(PackagingDto newPackagingDto)
        {
            try
            {
                var newPackaging = _mapper.Map<Packaging>(newPackagingDto);
                var createdPackaging = await _packagingRepository.CreateAsync(newPackaging);
                return _mapper.Map<PackagingDto>(createdPackaging);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the packaging", ex);
            }
        }

        public async Task<bool> UpdatePackagingAsync(PackagingDto updatedPackagingDto)
        {
            try
            {
                var existingPackaging = await _packagingRepository.GetByIdAsync(updatedPackagingDto.PackagingId);
                if (existingPackaging == null)
                {
                    throw new Exception("Packaging not found");
                }
                _mapper.Map(updatedPackagingDto, existingPackaging); // Map updated fields to existing entity
                return await _packagingRepository.UpdateAsync(existingPackaging);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the packaging", ex);
            }
        }

        public async Task<bool> DeletePackagingAsync(int id)
        {
            try
            {
                var entity = await _packagingRepository.GetByIdAsync(id);
                return await _packagingRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the packaging", ex);
            }
        }

        public async Task<PagedResult<PackagingDto>> GetPagedPackagingsAsync(PageRequest pageRequest)
        {
            var pagedPackagings = await _packagingRepository.GetPagedPackagingsAsync(pageRequest);
            return new PagedResult<PackagingDto>
            {
                Items = _mapper.Map<List<PackagingDto>>(pagedPackagings.Items),
                TotalCount = pagedPackagings.TotalCount,
                PageSize = pagedPackagings.PageSize,
                PageNumber = pagedPackagings.PageNumber
            };
        }
    }
}
