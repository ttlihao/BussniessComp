using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuYou.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int id);
        Task<OrderDetailDto> CreateOrderDetailAsync(OrderDetailDto orderDetailDto);
        Task<bool> UpdateOrderDetailAsync(OrderDetailDto orderDetailDto);
        Task<bool> DeleteOrderDetailAsync(int id);
        Task<PagedResult<OrderDetailDto>> GetPagedOrderDetailsAsync(PageRequest pageRequest);
    }

}
