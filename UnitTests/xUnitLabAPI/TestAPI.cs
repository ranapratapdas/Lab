using LabAPI.Controllers;
using LabAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace xUnitLabAPI
{
    /// <summary>
    /// We can and should write many test cases
    /// due to time crunch, I am writing just one for demonstratation purpose
    /// </summary>
    public class TestAPI
    {
        [Fact]
        public async Task Test_CheckInvenotry_qty1_sends_ok_status()
        {
            //Arrange
            string productId = "productid";
            int qty = 1;
            CreateSystemUnderTest(out var mockLogger, out var mockInventoryService);
            var controller = new InventoriesController(mockLogger.Object, mockInventoryService.Object);
            mockInventoryService.Setup(i => i.CheckInvenotry(productId, qty)).ReturnsAsync(true);
            //Act
            var actual = await controller.CheckInvenotry(productId, qty);

            //Assert
            Assert.IsType<OkObjectResult>(actual);
        }

        private void CreateSystemUnderTest(out Mock<ILogger<InventoriesController>> mockLogger, out Mock<IInvenotySerivce> mockService)
        {
            mockLogger = new Mock<ILogger<InventoriesController>>();
            mockService = new Mock<IInvenotySerivce>();
        }
    }
}
