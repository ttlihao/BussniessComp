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
    public class PaymentServices : IPaymentService
    {
        private readonly PaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public PaymentServices(PaymentRepository paymentRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var paymentEntity = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDto>(paymentEntity);
        }

        public async Task<PaymentDto> CreatePaymentAsync(PaymentDto newPaymentDto)
        {
            try
            {
                var newPayment = _mapper.Map<Payment>(newPaymentDto);
                newPayment.CreatedBy = _userContextService.GetCurrentUserId();
                newPayment.LastUpdatedBy = newPayment.CreatedBy;
                newPayment.CreatedTime = _timeService.SystemTimeNow;
                newPayment.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdPayment = await _paymentRepository.CreateAsync(newPayment);
                return _mapper.Map<PaymentDto>(createdPayment);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the payment", ex);
            }
        }

        public async Task<bool> UpdatePaymentAsync(PaymentDto updatedPaymentDto)
        {
            try
            {
                var existingPayment = await _paymentRepository.GetByIdAsync(updatedPaymentDto.PaymentId);
                if (existingPayment == null)
                {
                    throw new Exception("Payment not found");
                }
                _mapper.Map(updatedPaymentDto, existingPayment); // Map updated fields to existing entity
                existingPayment.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingPayment.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _paymentRepository.UpdateAsync(existingPayment);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the payment", ex);
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            try
            {
                var entity = await _paymentRepository.GetByIdAsync(id);
                return await _paymentRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the payment", ex);
            }
        }

        public async Task<PagedResult<PaymentDto>> GetPagedPaymentsAsync(PageRequest pageRequest)
        {
            var pagedPayments = await _paymentRepository.GetPagedPaymentsAsync(pageRequest);
            return new PagedResult<PaymentDto>
            {
                Items = _mapper.Map<List<PaymentDto>>(pagedPayments.Items),
                TotalCount = pagedPayments.TotalCount,
                PageSize = pagedPayments.PageSize,
                PageNumber = pagedPayments.PageNumber
            };
        }
    }
}
