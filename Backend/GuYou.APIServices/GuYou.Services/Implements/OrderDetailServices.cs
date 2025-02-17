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
    public class OrderDetailServices : IOrderDetailService
    {
        private readonly OrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public OrderDetailServices(OrderDetailRepository orderDetailRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetails);
        }

        public async Task<OrderDetailDto> GetOrderDetailByIdAsync(int id)
        {
            var orderDetailEntity = await _orderDetailRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDetailDto>(orderDetailEntity);
        }

        public async Task<OrderDetailDto> CreateOrderDetailAsync(OrderDetailDto newOrderDetailDto)
        {
            try
            {
                var newOrderDetail = _mapper.Map<OrderDetail>(newOrderDetailDto);
                var createdOrderDetail = await _orderDetailRepository.CreateAsync(newOrderDetail);
                return _mapper.Map<OrderDetailDto>(createdOrderDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the order detail", ex);
            }
        }

        public async Task<bool> UpdateOrderDetailAsync(OrderDetailDto updatedOrderDetailDto)
        {
            try
            {
                var existingOrderDetail = await _orderDetailRepository.GetByIdAsync(updatedOrderDetailDto.OrderDetailId);
                if (existingOrderDetail == null)
                {
                    throw new Exception("Order detail not found");
                }
                _mapper.Map(updatedOrderDetailDto, existingOrderDetail); // Map updated fields to existing entity
                return await _orderDetailRepository.UpdateAsync(existingOrderDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the order detail", ex);
            }
        }

        public async Task<bool> DeleteOrderDetailAsync(int id)
        {
            try
            {
                var entity = await _orderDetailRepository.GetByIdAsync(id);
                return await _orderDetailRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the order detail", ex);
            }
        }

        public async Task<PagedResult<OrderDetailDto>> GetPagedOrderDetailsAsync(PageRequest pageRequest)
        {
            var pagedOrderDetails = await _orderDetailRepository.GetPagedOrderDetailsAsync(pageRequest);
            return new PagedResult<OrderDetailDto>
            {
                Items = _mapper.Map<List<OrderDetailDto>>(pagedOrderDetails.Items),
                TotalCount = pagedOrderDetails.TotalCount,
                PageSize = pagedOrderDetails.PageSize,
                PageNumber = pagedOrderDetails.PageNumber
            };
        }
    }
}
