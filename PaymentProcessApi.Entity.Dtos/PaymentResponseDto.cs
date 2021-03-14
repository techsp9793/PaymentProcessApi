using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessApi.Entity.Dtos
{
    public class PaymentResponseDto
    {
        public bool IsProcessed { get; set; }
        public PaymentStateDto PaymentState { get; set; }
    }
}
