using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class ReviewRepository : GenericRepository<Review>
    {
        public ReviewRepository() { }

        public ReviewRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Review
                .Include(r => r.User)
                .Include(r => r.CoffeeMix)
                .Include(r => r.ReviewLikes)
                .ToListAsync();
        }

        public async Task<PagedResult<Review>> GetPagedReviewsAsync(PageRequest pageRequest)
        {
            var query = _context.Review
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(r => r.User)
                .Include(r => r.CoffeeMix)
                .Include(r => r.ReviewLikes);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
