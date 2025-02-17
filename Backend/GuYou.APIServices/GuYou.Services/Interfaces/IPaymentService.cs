using GuYou.Repositories.DTOs.Paging;
using GuYou.Repositories.DTOs;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
    Task<PaymentDto> GetPaymentByIdAsync(int id);
    Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto);
    Task<bool> UpdatePaymentAsync(PaymentDto paymentDto);
    Task<bool> DeletePaymentAsync(int id);
    Task<PagedResult<PaymentDto>> GetPagedPaymentsAsync(PageRequest pageRequest);
}
