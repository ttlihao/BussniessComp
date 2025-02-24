using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class PackagingRepository : GenericRepository<Packaging>
    {
        public PackagingRepository() { }

        public PackagingRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Packaging>> GetAllAsync()
        {
            return await _context.Packaging
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .ToListAsync();
        }

        public async Task<PagedResult<Packaging>> GetPagedPackagingsAsync(PageRequest pageRequest)
        {
            var query = _context.Packaging
                .Include(p => p.Category)
                .Include(p => p.Inventory);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
