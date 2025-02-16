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
    public class CoffeeBeanController : ControllerBase
    {
        private readonly ICoffeeBeanService _coffeeBeanService;

        public CoffeeBeanController(ICoffeeBeanService coffeeBeanService)
        {
            _coffeeBeanService = coffeeBeanService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CoffeeBeanDto>>> GetPagedCoffeeBeans([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var coffeeBeans = await _coffeeBeanService.GetPagedCoffeeBeansAsync(pageRequest);
                return Ok(coffeeBeans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeBeanDto>> GetCoffeeBeanById(int id)
        {
            try
            {
                var coffeeBean = await _coffeeBeanService.GetCoffeeBeanByIdAsync(id);
                return Ok(coffeeBean);
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
        public async Task<ActionResult<CoffeeBeanDto>> CreateCoffeeBean([FromBody] CoffeeBeanDto newCoffeeBean)
        {
            try
            {
                var createdCoffeeBean = await _coffeeBeanService.CreateCoffeeBeanAsync(newCoffeeBean);
                return CreatedAtAction(nameof(GetCoffeeBeanById), new { id = createdCoffeeBean.CoffeeBeanId }, createdCoffeeBean);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoffeeBean([FromBody] CoffeeBeanDto updatedCoffeeBean)
        {
            try
            {
                await _coffeeBeanService.UpdateCoffeeBeanAsync(updatedCoffeeBean);
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
        public async Task<IActionResult> DeleteCoffeeBean(int id)
        {
            try
            {
                await _coffeeBeanService.DeleteCoffeeBeanAsync(id);
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
