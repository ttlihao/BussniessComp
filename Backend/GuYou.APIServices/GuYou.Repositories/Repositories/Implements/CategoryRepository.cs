using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository() { }

        public CategoryRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category
                .Include(c => c.CoffeeBeans)
                .Include(c => c.Packagings)
                .ToListAsync();
        }
        public async Task<PagedResult<Category>> GetPagedCategorysAsync(PageRequest pageRequest)
        {
            var query = _context.Category
                .Include(c => c.CoffeeBeans)
                .Include(c => c.Packagings);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
