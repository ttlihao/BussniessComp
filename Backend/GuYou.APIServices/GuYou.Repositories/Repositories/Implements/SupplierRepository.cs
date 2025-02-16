using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class SupplierRepository : GenericRepository<Supplier>
    {
        public SupplierRepository() { }

        public SupplierRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Supplier
                .Include(s => s.CoffeeBeans)
                .ToListAsync();
        }

        public async Task<PagedResult<Supplier>> GetPagedSuppliersAsync(PageRequest pageRequest)
        {
            var query = _context.Supplier
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(s => s.CoffeeBeans);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
