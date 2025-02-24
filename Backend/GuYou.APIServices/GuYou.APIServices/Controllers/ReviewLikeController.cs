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
    public class ReviewLikeController : ControllerBase
    {
        private readonly IReviewLikeService _reviewLikeService;

        public ReviewLikeController(IReviewLikeService reviewLikeService)
        {
            _reviewLikeService = reviewLikeService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewLikeDto>> GetReviewLikeById(int id)
        {
            try
            {
                var reviewLike = await _reviewLikeService.GetReviewLikeByIdAsync(id);
                return Ok(reviewLike);
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
        public async Task<ActionResult<ReviewLikeDto>> CreateReviewLike([FromBody] ReviewLikeDto newReviewLike)
        {
            try
            {
                var createdReviewLike = await _reviewLikeService.CreateReviewLikeAsync(newReviewLike);
                return CreatedAtAction(nameof(GetReviewLikeById), new { id = createdReviewLike.ReviewLikeId }, createdReviewLike);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReviewLike([FromBody] ReviewLikeDto updatedReviewLike)
        {
            try
            {
                await _reviewLikeService.UpdateReviewLikeAsync(updatedReviewLike);
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
        public async Task<IActionResult> DeleteReviewLike(int id)
        {
            try
            {
                await _reviewLikeService.DeleteReviewLikeAsync(id);
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
