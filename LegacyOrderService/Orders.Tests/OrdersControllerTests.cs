
using Microsoft.AspNetCore.Mvc;
using Moq;
using Orders.API.Controllers;
using Orders.Application.Ports;
using Orders.Domain.Entities;
using Xunit;

namespace Orders.Tests
{
    public class OrdersControllerTests
    {
        [Fact]
        public void GetAll_ReturnsOk()
        {
            var mock = new Mock<IOrderService>();
            mock.Setup(s => s.GetOrders())
                .Returns(new[] { new Order() });

            var controller = new OrdersController(mock.Object);

            var result = controller.GetAll();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Create_ReturnsOk()
        {
            var mock = new Mock<IOrderService>();
            var controller = new OrdersController(mock.Object);

            var order = new Order();

            var result = controller.Create(order);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
