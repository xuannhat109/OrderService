
using Orders.Domain.Entities;
using System.Collections.Generic;
namespace Orders.Application.Ports
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetOrders();
    }
}
