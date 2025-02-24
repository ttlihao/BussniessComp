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
    public class CoffeeMixDetailController : ControllerBase
    {
        private readonly ICoffeeMixDetailService _coffeeMixDetailService;

        public CoffeeMixDetailController(ICoffeeMixDetailService coffeeMixDetailService)
        {
            _coffeeMixDetailService = coffeeMixDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CoffeeMixDetailDto>>> GetPagedCoffeeMixDetails([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var coffeeMixDetails = await _coffeeMixDetailService.GetPagedCoffeeMixDetailsAsync(pageRequest);
                return Ok(coffeeMixDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeMixDetailDto>> GetCoffeeMixDetailById(int id)
        {
            try
            {
                var coffeeMixDetail = await _coffeeMixDetailService.GetCoffeeMixDetailByIdAsync(id);
                return Ok(coffeeMixDetail);
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
        public async Task<ActionResult<CoffeeMixDetailDto>> CreateCoffeeMixDetail([FromBody] CoffeeMixDetailDto newCoffeeMixDetail)
        {
            try
            {
                var createdCoffeeMixDetail = await _coffeeMixDetailService.CreateCoffeeMixDetailAsync(newCoffeeMixDetail);
                return CreatedAtAction(nameof(GetCoffeeMixDetailById), new { id = createdCoffeeMixDetail.CoffeeMixDetailId }, createdCoffeeMixDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoffeeMixDetail([FromBody] CoffeeMixDetailDto updatedCoffeeMixDetail)
        {
            try
            {
                await _coffeeMixDetailService.UpdateCoffeeMixDetailAsync(updatedCoffeeMixDetail);
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
        public async Task<IActionResult> DeleteCoffeeMixDetail(int id)
        {
            try
            {
                await _coffeeMixDetailService.DeleteCoffeeMixDetailAsync(id);
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
