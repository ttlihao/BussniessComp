using GuYou.Contracts.DTOs.Paging;
using GuYou.Repositories.DbContext;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        public OrderDetailRepository() { }

        public OrderDetailRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _context.OrderDetail
                .Include(od => od.Order)
                .Include(od => od.CoffeeMix)
                .ToListAsync();
        }

        public async Task<PagedResult<OrderDetail>> GetPagedOrderDetailsAsync(PageRequest pageRequest)
        {
            var query = _context.OrderDetail
                .Include(od => od.Order)
                .Include(od => od.CoffeeMix);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
