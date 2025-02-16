using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class InventoryRepository : GenericRepository<Inventory>
    {
        public InventoryRepository() { }

        public InventoryRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Inventory>> GetAllAsync()
        {
            return await _context.Inventory
                .Include(i => i.CoffeeBean)
                .Include(i => i.Packaging)
                .ToListAsync();
        }

        public async Task<PagedResult<Inventory>> GetPagedInventoriesAsync(PageRequest pageRequest)
        {
            var query = _context.Inventory
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(i => i.CoffeeBean)
                .Include(i => i.Packaging);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
