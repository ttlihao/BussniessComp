using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class CoffeeMixDetailRepository : GenericRepository<CoffeeMixDetail>
    {
        public CoffeeMixDetailRepository() { }

        public CoffeeMixDetailRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<CoffeeMixDetail>> GetAllAsync()
        {
            return await _context.CoffeeMixDetail
                .Include(cmd => cmd.CoffeeMix)
                .Include(cmd => cmd.CoffeeBean)
                .ToListAsync();
        }
        public async Task<PagedResult<CoffeeMixDetail>> GetPagedCoffeeMixDetailsAsync(PageRequest pageRequest)
        {
            var query = _context.CoffeeMixDetail
                .Include(cmd => cmd.CoffeeMix)
                .Include(cmd => cmd.CoffeeBean);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
