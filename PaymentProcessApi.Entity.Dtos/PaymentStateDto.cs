using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessApi.Entity.Dtos
{
    public class PaymentStateDto
    {
        public PaymentStateEnum PaymentState { get; set; }
        public DateTime PaymentStateDate { get; set; }
    }
}
