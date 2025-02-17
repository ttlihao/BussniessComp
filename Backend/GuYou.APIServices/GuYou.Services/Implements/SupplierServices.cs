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
    public class SupplierServices : ISupplierService
    {
        private readonly SupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public SupplierServices(SupplierRepository supplierRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(int id)
        {
            var supplierEntity = await _supplierRepository.GetByIdAsync(id);
            return _mapper.Map<SupplierDto>(supplierEntity);
        }

        public async Task<SupplierDto> CreateSupplierAsync(SupplierDto newSupplierDto)
        {
            try
            {
                var newSupplier = _mapper.Map<Supplier>(newSupplierDto);
                newSupplier.CreatedBy = _userContextService.GetCurrentUserId();
                newSupplier.LastUpdatedBy = newSupplier.CreatedBy;
                newSupplier.CreatedTime = _timeService.SystemTimeNow;
                newSupplier.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdSupplier = await _supplierRepository.CreateAsync(newSupplier);
                return _mapper.Map<SupplierDto>(createdSupplier);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the supplier", ex);
            }
        }

        public async Task<bool> UpdateSupplierAsync(SupplierDto updatedSupplierDto)
        {
            try
            {
                var existingSupplier = await _supplierRepository.GetByIdAsync(updatedSupplierDto.SupplierId);
                if (existingSupplier == null)
                {
                    throw new Exception("Supplier not found");
                }
                _mapper.Map(updatedSupplierDto, existingSupplier); // Map updated fields to existing entity
                existingSupplier.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingSupplier.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _supplierRepository.UpdateAsync(existingSupplier);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the supplier", ex);
            }
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            try
            {
                var entity = await _supplierRepository.GetByIdAsync(id);
                return await _supplierRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the supplier", ex);
            }
        }

        public async Task<PagedResult<SupplierDto>> GetPagedSuppliersAsync(PageRequest pageRequest)
        {
            var pagedSuppliers = await _supplierRepository.GetPagedSuppliersAsync(pageRequest);
            return new PagedResult<SupplierDto>
            {
                Items = _mapper.Map<List<SupplierDto>>(pagedSuppliers.Items),
                TotalCount = pagedSuppliers.TotalCount,
                PageSize = pagedSuppliers.PageSize,
                PageNumber = pagedSuppliers.PageNumber
            };
        }
    }
}
