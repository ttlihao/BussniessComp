using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class CoffeeMixRepository : GenericRepository<CoffeeMix>
    {
        public CoffeeMixRepository() { }

        public CoffeeMixRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<CoffeeMix>> GetAllAsync()
        {
            return await _context.CoffeeMix
                .Include(cm => cm.CoffeeMixDetails)
                .Include(cm => cm.Reviews)
                .ToListAsync();
        }
        public async Task<PagedResult<CoffeeMix>> GetPagedCoffeeMixesAsync(PageRequest pageRequest)
        {
            var query = _context.CoffeeMix
                .Include(cm => cm.CoffeeMixDetails)
                .Include(cm => cm.Reviews);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
