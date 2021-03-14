using PaymentProcessApi.Entity.Dtos;
using System.Threading.Tasks;

namespace PaymentProcessApi.Services
{
    public interface IPaymentRequestService
    {
        Task<PaymentStateDto> Pay(PaymentRequestDto paymentRequestDto);
    }
}