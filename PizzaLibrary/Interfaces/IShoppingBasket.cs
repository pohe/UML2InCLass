using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IShoppingBasket
    {
        List<OrderLine> GetAll();
        void AddOrderLine(OrderLine orderLine);

        void RemoveOrderLine(int id);
        public int Count { get; }

        public Customer CurrentCustomer { get; set; }
        public void ClearAll();
        public OrderLine? GetOrderLineById(int id);
        bool ToBeDelivered { get; set; }
    }
}
