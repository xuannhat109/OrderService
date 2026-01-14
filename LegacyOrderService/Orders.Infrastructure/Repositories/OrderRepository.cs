
using Orders.Application.Ports;
using Orders.Domain.Entities;
using Orders.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _db;
        public OrderRepository(OrdersDbContext db) => _db = db;

        public void Create(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }

        public IEnumerable<Order> GetAll() => _db.Orders.ToList();

    }
}
