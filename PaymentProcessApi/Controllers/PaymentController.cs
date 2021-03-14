using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentProcessApi.Entity.Dtos;
using PaymentProcessApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentRequestService _paymentRequestService;

        public PaymentController(IPaymentRequestService paymentRequestService, ILogger<PaymentController> logger)
        {
            _logger = logger;
            _paymentRequestService = paymentRequestService;
        }

        [HttpGet]
        public string Get()
        {
            return "Payment Api is online";
        }


        [HttpPost]
        public async Task<IActionResult> Post(PaymentRequestDto paymentRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var paymentState = await _paymentRequestService.Pay(paymentRequest);
                    var paymentResponse = new PaymentResponseDto()
                    {
                        IsProcessed = paymentState.PaymentState == PaymentStateEnum.Processed,
                        PaymentState = paymentState
                    };

                    if (!paymentResponse.IsProcessed)
                        return StatusCode(500, new { error = "Payment process failure." });
                    return Ok(paymentResponse);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
