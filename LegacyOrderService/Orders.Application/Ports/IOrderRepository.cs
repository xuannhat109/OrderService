
using Orders.Domain.Entities;
using System.Collections.Generic;
namespace Orders.Application.Ports
{
    public interface IOrderRepository
    {
        void Create(Order order);
        IEnumerable<Order> GetAll();
    }
}
