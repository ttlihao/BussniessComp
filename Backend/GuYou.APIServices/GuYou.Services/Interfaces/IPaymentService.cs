using GuYou.Contracts.DTOs;
using GuYou.Contracts.DTOs.Paging;
using GuYou.Contracts.DTOs.UserDTO;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
    Task<PaymentDto> GetPaymentByIdAsync(int id);
    Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto);
    Task<bool> UpdatePaymentAsync(PaymentDto paymentDto);
    Task<bool> DeletePaymentAsync(int id);
    Task<PagedResult<PaymentDto>> GetPagedPaymentsAsync(PageRequest pageRequest);
}
