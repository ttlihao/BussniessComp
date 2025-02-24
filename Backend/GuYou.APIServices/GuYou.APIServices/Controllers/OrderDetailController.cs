using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.APIServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<OrderDetailDto>>> GetPagedOrderDetails([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var orderDetails = await _orderDetailService.GetPagedOrderDetailsAsync(pageRequest);
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
                return Ok(orderDetail);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderDetailDto>> CreateOrderDetail([FromBody] OrderDetailDto newOrderDetail)
        {
            try
            {
                var createdOrderDetail = await _orderDetailService.CreateOrderDetailAsync(newOrderDetail);
                return CreatedAtAction(nameof(GetOrderDetailById), new { id = createdOrderDetail.OrderDetailId }, createdOrderDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail([FromBody] OrderDetailDto updatedOrderDetail)
        {
            try
            {
                await _orderDetailService.UpdateOrderDetailAsync(updatedOrderDetail);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            try
            {
                await _orderDetailService.DeleteOrderDetailAsync(id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
