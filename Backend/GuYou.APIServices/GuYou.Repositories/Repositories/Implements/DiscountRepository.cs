using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class DiscountRepository : GenericRepository<Discount>
    {
        public DiscountRepository() { }

        public DiscountRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<PagedResult<Discount>> GetPagedDiscountsAsync(PageRequest pageRequest)
        {
            var query = _context.Discount
                .Where(e => e.IsActive && !e.IsDelete);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
