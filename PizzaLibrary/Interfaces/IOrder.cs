using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IOrder
    {
        int Id { get; }
        bool ToBeDelivered { get; }
        void AddOrderLine(OrderLine line);
        double CalculateTotal();
        void PrintReciept();
        public List<OrderLine> GetAllOrderLines();
    }
}
