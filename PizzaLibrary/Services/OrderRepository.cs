using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaLibrary.Services
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }
        public int Count { get { return _orders.Count; } }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order? GetOrderById(int id)
        {
            foreach (Order o in _orders)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }

        public void PrintAllOrder()
        {
            foreach (Order item in _orders)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void RemoveOrder(int id)
        {
            Order? orderToRemove = GetOrderById(id);
            if (orderToRemove != null)
            {
                _orders.Remove(orderToRemove);
            }
        }
    }
}
