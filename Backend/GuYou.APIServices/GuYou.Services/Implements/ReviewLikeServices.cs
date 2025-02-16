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
    public class ReviewLikeServices : IReviewLikeService
    {
        private readonly ReviewLikeRepository _reviewLikeRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public ReviewLikeServices(ReviewLikeRepository reviewLikeRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _reviewLikeRepository = reviewLikeRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<ReviewLikeDto>> GetAllReviewLikesAsync()
        {
            var reviewLikes = await _reviewLikeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewLikeDto>>(reviewLikes);
        }

        public async Task<ReviewLikeDto> GetReviewLikeByIdAsync(int id)
        {
            var reviewLikeEntity = await _reviewLikeRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewLikeDto>(reviewLikeEntity);
        }

        public async Task<ReviewLikeDto> CreateReviewLikeAsync(ReviewLikeDto newReviewLikeDto)
        {
            try
            {
                var newReviewLike = _mapper.Map<ReviewLike>(newReviewLikeDto);
                var createdReviewLike = await _reviewLikeRepository.CreateAsync(newReviewLike);
                return _mapper.Map<ReviewLikeDto>(createdReviewLike);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the review like", ex);
            }
        }

        public async Task<bool> UpdateReviewLikeAsync(ReviewLikeDto updatedReviewLikeDto)
        {
            try
            {
                var existingReviewLike = await _reviewLikeRepository.GetByIdAsync(updatedReviewLikeDto.ReviewLikeId);
                if (existingReviewLike == null)
                {
                    throw new Exception("Review like not found");
                }
                _mapper.Map(updatedReviewLikeDto, existingReviewLike); // Map updated fields to existing entity
                return await _reviewLikeRepository.UpdateAsync(existingReviewLike);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the review like", ex);
            }
        }

        public async Task<bool> DeleteReviewLikeAsync(int id)
        {
            try
            {
                var entity = await _reviewLikeRepository.GetByIdAsync(id);
                return await _reviewLikeRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the review like", ex);
            }
        }

    }
}
