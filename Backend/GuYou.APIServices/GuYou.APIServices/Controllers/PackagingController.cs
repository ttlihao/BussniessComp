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
    public class PackagingController : ControllerBase
    {
        private readonly IPackagingService _packagingService;

        public PackagingController(IPackagingService packagingService)
        {
            _packagingService = packagingService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PackagingDto>>> GetPagedPackagings([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var pageRequest = new PageRequest { PageNumber = pageNumber, PageSize = pageSize };
                var packagings = await _packagingService.GetPagedPackagingsAsync(pageRequest);
                return Ok(packagings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackagingDto>> GetPackagingById(int id)
        {
            try
            {
                var packaging = await _packagingService.GetPackagingByIdAsync(id);
                return Ok(packaging);
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
        public async Task<ActionResult<PackagingDto>> CreatePackaging([FromBody] PackagingDto newPackaging)
        {
            try
            {
                var createdPackaging = await _packagingService.CreatePackagingAsync(newPackaging);
                return CreatedAtAction(nameof(GetPackagingById), new { id = createdPackaging.PackagingId }, createdPackaging);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePackaging([FromBody] PackagingDto updatedPackaging)
        {
            try
            {
                await _packagingService.UpdatePackagingAsync(updatedPackaging);
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
        public async Task<IActionResult> DeletePackaging(int id)
        {
            try
            {
                await _packagingService.DeletePackagingAsync(id);
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
