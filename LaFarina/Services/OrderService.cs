using LaFarina.Entities;
using LaFarina.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaFarina.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }

    public class OrderService : IOrderService
    {
        public LaFarinaContext _context;

        public OrderService(LaFarinaContext context)
        {
            _context = context;
        }

        public Order Create(Order order)
        {
            if (order.Pizzas == null)
                throw new AppException("No Pizza is added to the order");

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public void Update(Order order)
        {
            var _order = _context.Orders.Find(order.Id);

            if (_order == null)
            {
                throw new AppException("Ingredient not found");
            }

            _order = order;
           
            _context.Orders.Add(_order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var _order = _context.Orders.Find(id);
            if (_order != null)
            {
                _context.Orders.Remove(_order);
                _context.SaveChanges();
            }
        }
    }
}
