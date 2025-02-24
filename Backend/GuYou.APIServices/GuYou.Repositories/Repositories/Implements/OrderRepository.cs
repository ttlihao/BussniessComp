using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() { }

        public OrderRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Order
                .Include(o => o.User)
                .Include(o => o.Discount)
                .Include(o => o.Packaging)
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .Include(o => o.ShippingDetail)
                .ToListAsync();
        }

        public async Task<PagedResult<Order>> GetPagedOrdersAsync(PageRequest pageRequest)
        {
            var query = _context.Order
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(o => o.User)
                .Include(o => o.Discount)
                .Include(o => o.Packaging)
                .Include(o => o.OrderDetails)
                .Include(o => o.Payments)
                .Include(o => o.ShippingDetail);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
