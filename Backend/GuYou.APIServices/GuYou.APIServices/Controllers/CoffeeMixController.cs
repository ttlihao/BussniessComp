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
    public class CoffeeMixController : ControllerBase
    {
        private readonly ICoffeeMixService _coffeeMixService;

        public CoffeeMixController(ICoffeeMixService coffeeMixService)
        {
            _coffeeMixService = coffeeMixService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CoffeeMixDto>>> GetPagedCoffeeMixes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var coffeeMixes = await _coffeeMixService.GetPagedCoffeeMixesAsync(pageRequest);
                return Ok(coffeeMixes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeMixDto>> GetCoffeeMixById(int id)
        {
            try
            {
                var coffeeMix = await _coffeeMixService.GetCoffeeMixByIdAsync(id);
                return Ok(coffeeMix);
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
        public async Task<ActionResult<CoffeeMixDto>> CreateCoffeeMix([FromBody] CoffeeMixDto newCoffeeMix)
        {
            try
            {
                var createdCoffeeMix = await _coffeeMixService.CreateCoffeeMixAsync(newCoffeeMix);
                return CreatedAtAction(nameof(GetCoffeeMixById), new { id = createdCoffeeMix.CoffeeMixId }, createdCoffeeMix);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoffeeMix([FromBody] CoffeeMixDto updatedCoffeeMix)
        {
            try
            {
                await _coffeeMixService.UpdateCoffeeMixAsync(updatedCoffeeMix);
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
        public async Task<IActionResult> DeleteCoffeeMix(int id)
        {
            try
            {
                await _coffeeMixService.DeleteCoffeeMixAsync(id);
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
