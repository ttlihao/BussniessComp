using AutoMapper;
using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using GuYou.Repositories.Repositories.Implements;
using GuYou.Repositories.Repositories.Interfaces;
using GuYou.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuYou.Services.Implements
{
    public class ReviewServices : IReviewService
    {
        private readonly ReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ITimeService _timeService;

        public ReviewServices(ReviewRepository reviewRepository, IMapper mapper, IUserContextService userContextService, ITimeService timeService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _userContextService = userContextService;
            _timeService = timeService;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int id)
        {
            var reviewEntity = await _reviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDto>(reviewEntity);
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewDto newReviewDto)
        {
            try
            {
                var newReview = _mapper.Map<Review>(newReviewDto);
                newReview.CreatedBy = _userContextService.GetCurrentUserId();
                newReview.LastUpdatedBy = newReview.CreatedBy;
                newReview.CreatedTime = _timeService.SystemTimeNow;
                newReview.LastUpdatedTime = _timeService.SystemTimeNow;
                var createdReview = await _reviewRepository.CreateAsync(newReview);
                return _mapper.Map<ReviewDto>(createdReview);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the review", ex);
            }
        }

        public async Task<bool> UpdateReviewAsync(ReviewDto updatedReviewDto)
        {
            try
            {
                var existingReview = await _reviewRepository.GetByIdAsync(updatedReviewDto.ReviewId);
                if (existingReview == null)
                {
                    throw new Exception("Review not found");
                }
                _mapper.Map(updatedReviewDto, existingReview); // Map updated fields to existing entity
                existingReview.LastUpdatedBy = _userContextService.GetCurrentUserId();
                existingReview.LastUpdatedTime = _timeService.SystemTimeNow;
                return await _reviewRepository.UpdateAsync(existingReview);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the review", ex);
            }
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            try
            {
                var entity = await _reviewRepository.GetByIdAsync(id);
                return await _reviewRepository.RemoveAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the review", ex);
            }
        }

        public async Task<PagedResult<ReviewDto>> GetPagedReviewsAsync(PageRequest pageRequest)
        {
            var pagedReviews = await _reviewRepository.GetPagedReviewsAsync(pageRequest);
            return new PagedResult<ReviewDto>
            {
                Items = _mapper.Map<List<ReviewDto>>(pagedReviews.Items),
                TotalCount = pagedReviews.TotalCount,
                PageSize = pagedReviews.PageSize,
                PageNumber = pagedReviews.PageNumber
            };
        }
    }
}
