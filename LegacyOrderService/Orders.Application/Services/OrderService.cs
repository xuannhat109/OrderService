
using Orders.Application.Ports;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        public OrderService(IOrderRepository repo) => _repo = repo;

        private readonly Dictionary<string, double> _productPrices = new()
        {
            ["Widget"] = 12.99,
            ["Gadget"] = 15.49,
            ["Doohickey"] = 8.75
        };

        private double GetPrice(string productName)
        {
            if (_productPrices.TryGetValue(productName, out var price))
                return price;

            throw new Exception("Product not found");
        }
        public void CreateOrder(Order order)
        {
            order.Price = GetPrice(order.ProductName);

            _repo.Create(order);
        }
        public IEnumerable<Order> GetOrders() => _repo.GetAll();
    }
}
