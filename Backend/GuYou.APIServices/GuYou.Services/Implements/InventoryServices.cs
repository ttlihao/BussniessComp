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
    public class InventoryServices : IInventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public InventoryServices(InventoryRepository inventoryRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<InventoryDto>> GetAllInventoriesAsync()
        {
            var inventories = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryDto>>(inventories);
        }

        public async Task<InventoryDto> GetInventoryByIdAsync(int id)
        {
            var inventoryEntity = await _inventoryRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryDto>(inventoryEntity);
        }

        public async Task<InventoryDto> CreateInventoryAsync(InventoryDto newInventoryDto)
        {
            try
            {
                var newInventory = _mapper.Map<Inventory>(newInventoryDto);
                newInventory.CreatedBy = _userContextService.GetCurrentUserId();
                newInventory.LastUpdatedBy = newInventory.CreatedBy;
                newInventory.CreatedTime = _timeService.SystemTimeNow;
                newInventory.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdInventory = await _inventoryRepository.CreateAsync(newInventory);
                return _mapper.Map<InventoryDto>(createdInventory);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the inventory", ex);
            }
        }

        public async Task<bool> UpdateInventoryAsync(InventoryDto updatedInventoryDto)
        {
            try
            {
                var existingInventory = await _inventoryRepository.GetByIdAsync(updatedInventoryDto.InventoryId);
                if (existingInventory == null)
                {
                    throw new Exception("Inventory not found");
                }
                _mapper.Map(updatedInventoryDto, existingInventory); // Map updated fields to existing entity
                existingInventory.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingInventory.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _inventoryRepository.UpdateAsync(existingInventory);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the inventory", ex);
            }
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            try
            {
                var entity = await _inventoryRepository.GetByIdAsync(id);
                return await _inventoryRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the inventory", ex);
            }
        }

        public async Task<PagedResult<InventoryDto>> GetPagedInventoriesAsync(PageRequest pageRequest)
        {
            var pagedInventories = await _inventoryRepository.GetPagedInventoriesAsync(pageRequest);
            return new PagedResult<InventoryDto>
            {
                Items = _mapper.Map<List<InventoryDto>>(pagedInventories.Items),
                TotalCount = pagedInventories.TotalCount,
                PageSize = pagedInventories.PageSize,
                PageNumber = pagedInventories.PageNumber
            };
        }
    }
}
