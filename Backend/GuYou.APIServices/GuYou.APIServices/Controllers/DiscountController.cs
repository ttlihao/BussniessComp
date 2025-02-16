using GuYou.Repositories.DTOs;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.APIServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<DiscountDto>>> GetPagedDiscounts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var discounts = await _discountService.GetPagedDiscountsAsync(pageRequest);
                return Ok(discounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountDto>> GetDiscountById(int id)
        {
            try
            {
                var discount = await _discountService.GetDiscountByIdAsync(id);
                return Ok(discount);
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
        public async Task<ActionResult<DiscountDto>> CreateDiscount([FromBody] DiscountDto newDiscount)
        {
            try
            {
                var createdDiscount = await _discountService.CreateDiscountAsync(newDiscount);
                return CreatedAtAction(nameof(GetDiscountById), new { id = createdDiscount.DiscountId }, createdDiscount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDto updatedDiscount)
        {
            try
            {
                await _discountService.UpdateDiscountAsync(updatedDiscount);
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
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            try
            {
                await _discountService.DeleteDiscountAsync(id);
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
