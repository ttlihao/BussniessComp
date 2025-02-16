using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class ReviewLikeRepository : GenericRepository<ReviewLike>
    {
        public ReviewLikeRepository() { }

        public ReviewLikeRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<ReviewLike>> GetAllAsync()
        {
            return await _context.ReviewLike
                .Include(rl => rl.Review)
                .Include(rl => rl.User)
                .ToListAsync();
        }
    }
}
