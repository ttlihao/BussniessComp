using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviewsAsync();
        Task<ReviewDto> GetReviewByIdAsync(int id);
        Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
        Task<bool> UpdateReviewAsync(ReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(int id);
        Task<PagedResult<ReviewDto>> GetPagedReviewsAsync(PageRequest pageRequest);
    }

}
