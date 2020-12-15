using LabAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LabAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class InventoriesController : ControllerBase
    {
        
        private readonly ILogger<InventoriesController> _logger;
        private readonly IInvenotySerivce _inventoryService;
        public InventoriesController(ILogger<InventoriesController> logger, IInvenotySerivce inventoryService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }
        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            return Ok("ping is okay.");
        }

        [HttpGet("{porductid}/{qty}")]
        public async Task<IActionResult> CheckInvenotry(string porductid, int qty)
        {
            bool result = false;
            try
            {
                _logger.LogInformation("Entering InventoriesController.CheckInvenotry: ");
                result = await _inventoryService.CheckInvenotry(porductid, qty);
                _logger.LogInformation("Out from InventoriesController.CheckInvenotry: ");
                return Ok(result);
            }
            catch (SystemException ex)
            {
                _logger.LogInformation($"Exception occurred: {ex.Message} ");
                return Ok(result);
            }
        }
        
    }
}
