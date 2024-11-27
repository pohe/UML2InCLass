using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderRepository
    {
        int Count { get; }
        List<Order> GetAll();
        void AddOrder(Order order);

        Order GetOrderById(int id);
        void RemoveOrder(int id);
        void PrintAllOrder();

    }
}
