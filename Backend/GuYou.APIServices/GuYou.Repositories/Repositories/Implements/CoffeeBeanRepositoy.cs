using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class CoffeeBeanRepository : GenericRepository<CoffeeBean>
    {
        public CoffeeBeanRepository() { }

        public CoffeeBeanRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<CoffeeBean>> GetAllAsync()
        {
            return await _context.CoffeeBean
                .Include(cb => cb.Category)
                .Include(cb => cb.Supplier)
                .Include(cb => cb.CoffeeMixDetails)
                .Include(cb => cb.Inventory)
                .Include(cb => cb.Reviews)
                .ToListAsync();
        }

        public async Task<PagedResult<CoffeeBean>> GetPagedCoffeeBeansAsync(PageRequest pageRequest)
        {
            var query = _context.CoffeeBean
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(cb => cb.Category)
                .Include(cb => cb.Supplier)
                .Include(cb => cb.CoffeeMixDetails)
                .Include(cb => cb.Inventory)
                .Include(cb => cb.Reviews);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
