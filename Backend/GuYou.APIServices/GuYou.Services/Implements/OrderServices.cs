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
    public class OrderServices : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public OrderServices(OrderRepository orderRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var orderEntity = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(orderEntity);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto newOrderDto)
        {
            try
            {
                var newOrder = _mapper.Map<Order>(newOrderDto);
                newOrder.CreatedBy = _userContextService.GetCurrentUserId();
                newOrder.UserId = newOrder.CreatedBy; 
                newOrder.LastUpdatedBy = newOrder.CreatedBy;
                newOrder.CreatedTime = _timeService.SystemTimeNow;
                newOrder.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdOrder = await _orderRepository.CreateAsync(newOrder);
                return _mapper.Map<OrderDto>(createdOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the order", ex);
            }
        }

        public async Task<bool> UpdateOrderAsync(OrderDto updatedOrderDto)
        {
            try
            {
                var existingOrder = await _orderRepository.GetByIdAsync(updatedOrderDto.OrderId);
                if (existingOrder == null)
                {
                    throw new Exception("Order not found");
                }
                _mapper.Map(updatedOrderDto, existingOrder); // Map updated fields to existing entity
                existingOrder.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingOrder.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _orderRepository.UpdateAsync(existingOrder);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the order", ex);
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var entity = await _orderRepository.GetByIdAsync(id);
                return await _orderRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the order", ex);
            }
        }

        public async Task<PagedResult<OrderDto>> GetPagedOrdersAsync(PageRequest pageRequest)
        {
            var pagedOrders = await _orderRepository.GetPagedOrdersAsync(pageRequest);
            return new PagedResult<OrderDto>
            {
                Items = _mapper.Map<List<OrderDto>>(pagedOrders.Items),
                TotalCount = pagedOrders.TotalCount,
                PageSize = pagedOrders.PageSize,
                PageNumber = pagedOrders.PageNumber
            };
        }
    }
}
