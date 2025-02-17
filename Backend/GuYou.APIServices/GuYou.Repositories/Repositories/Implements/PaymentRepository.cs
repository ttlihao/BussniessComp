using GuYou.Repositories.DbContext;
using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuYou.Repositories.Repositories.Implements
{
    public class PaymentRepository : GenericRepository<Payment>
    {
        public PaymentRepository() { }

        public PaymentRepository(CoffeShopManagementContext context) : base(context) { }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _context.Payments
                .Include(p => p.Order)
                .ToListAsync();
        }

        public async Task<PagedResult<Payment>> GetPagedPaymentsAsync(PageRequest pageRequest)
        {
            var query = _context.Payments
                .Where(e => e.IsActive && !e.IsDelete)
                .Include(p => p.Order);

            return await query.CreatePagingAsync(pageRequest.PageNumber, pageRequest.PageSize);
        }
    }
}
