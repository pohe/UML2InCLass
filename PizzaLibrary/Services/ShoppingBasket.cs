using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class ShoppingBasket : IShoppingBasket
    {
        private List<OrderLine> _orderLines;

        public int Count { get { return _orderLines.Count; } }

        public Customer CurrentCustomer { get; set; }
        public bool ToBeDelivered { get; set; }

        public ShoppingBasket()
        {
            _orderLines = new List<OrderLine>();
        }

        public void ClearAll()
        {
            _orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }

        public List<OrderLine> GetAll()
        {
            return _orderLines;
        }

        public void RemoveOrderLine(int id)
        {
            OrderLine? orderLineToBeDeleted = GetOrderLineById(id);
            if (orderLineToBeDeleted != null)
            {
                _orderLines.Remove(orderLineToBeDeleted);
            }
        }
        public OrderLine? GetOrderLineById(int id)
        {
            foreach (OrderLine ol in _orderLines)
            {
                if (ol.Id == id)
                {
                    return ol;
                }
            }
            return null;
        }

        
    }
}
