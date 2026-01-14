
using Moq;
using Orders.Application.Ports;
using Orders.Application.Services;
using Orders.Domain.Entities;
using Xunit;

namespace Orders.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_Should_Call_Repository()
        {
            var repoMock = new Mock<IOrderRepository>();
            var service = new OrderService(repoMock.Object);

            var order = new Order { CustomerName = "Test" };

            service.CreateOrder(order);

            repoMock.Verify(r => r.Create(order), Times.Once);
        }

        [Fact]
        public void GetOrders_Should_Return_Data()
        {
            var repoMock = new Mock<IOrderRepository>();
            repoMock.Setup(r => r.GetAll())
                    .Returns(new[] { new Order() });

            var service = new OrderService(repoMock.Object);

            var result = service.GetOrders();

            Assert.Single(result);
        }
    }
}
