using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class ShippingDetailRepository : GenericRepository<ShippingDetail>
    {
        public ShippingDetailRepository() { }

        public ShippingDetailRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<ShippingDetail>> GetAllAsync()
        {
            return await _context.ShippingDetail
                .Include(sd => sd.Order)
                .ToListAsync();
        }

        public async Task<PagedResult<ShippingDetail>> GetPagedShippingDetailsAsync(PageRequest pageRequest)
        {
            var query = _context.ShippingDetail
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(sd => sd.Order);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
