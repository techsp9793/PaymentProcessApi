using PaymentProcessApi.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessApi.Application
{
    public interface IPaymentGateway
    {
        PaymentStateDto ProcessPayment(PaymentRequestDto paymentRequest);
    }
}
