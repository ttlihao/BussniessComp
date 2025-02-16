using GuYou.Repositories.DTOs;
using GuYou.Repositories.DTOs.Paging;


namespace GuYou.Services.Interfaces
{
    public interface IReviewLikeService
    {
        Task<IEnumerable<ReviewLikeDto>> GetAllReviewLikesAsync();
        Task<ReviewLikeDto> GetReviewLikeByIdAsync(int id);
        Task<ReviewLikeDto> CreateReviewLikeAsync(ReviewLikeDto reviewLikeDto);
        Task<bool> UpdateReviewLikeAsync(ReviewLikeDto reviewLikeDto);
        Task<bool> DeleteReviewLikeAsync(int id);
    }

}
