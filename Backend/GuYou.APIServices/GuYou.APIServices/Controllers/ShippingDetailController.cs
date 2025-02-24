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
    public class ShippingDetailController : ControllerBase
    {
        private readonly IShippingDetailService _shippingDetailService;

        public ShippingDetailController(IShippingDetailService shippingDetailService)
        {
            _shippingDetailService = shippingDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ShippingDetailDto>>> GetPagedShippingDetails([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var shippingDetails = await _shippingDetailService.GetPagedShippingDetailsAsync(pageRequest);
                return Ok(shippingDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingDetailDto>> GetShippingDetailById(int id)
        {
            try
            {
                var shippingDetail = await _shippingDetailService.GetShippingDetailByIdAsync(id);
                return Ok(shippingDetail);
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
        public async Task<ActionResult<ShippingDetailDto>> CreateShippingDetail([FromBody] ShippingDetailDto newShippingDetail)
        {
            try
            {
                var createdShippingDetail = await _shippingDetailService.CreateShippingDetailAsync(newShippingDetail);
                return CreatedAtAction(nameof(GetShippingDetailById), new { id = createdShippingDetail.ShippingDetailId }, createdShippingDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShippingDetail([FromBody] ShippingDetailDto updatedShippingDetail)
        {
            try
            {
                await _shippingDetailService.UpdateShippingDetailAsync(updatedShippingDetail);
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
        public async Task<IActionResult> DeleteShippingDetail(int id)
        {
            try
            {
                await _shippingDetailService.DeleteShippingDetailAsync(id);
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
