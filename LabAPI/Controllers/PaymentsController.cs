using LabAPI.Model;
using LabAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabApi.Model;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class PaymentsController : ControllerBase
    {

        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _paymentService;
        public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserPayment user)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            _logger.LogInformation("PaymentsController.Post: ");

            bool charged = false;
            try
            {

                charged = await _paymentService.Charge(user);
                _logger.LogInformation("Out from PaymentsController.Post: ");
                return Ok(charged);
            }
            catch (SystemException ex)
            {
                _logger.LogInformation($"Exception occurred: {ex.Message} ");
                return Ok(charged);
            }
        }

    }
}
