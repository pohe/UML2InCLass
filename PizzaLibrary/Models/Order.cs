using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Order : IOrder
    {
        #region instance fields
        private static int _counter;
        private int _id;
        private DateTime _created;
        private List<OrderLine> _lines;
        private Customer _customer;
        #endregion

        #region Properties
        public int Id { get { return _id; } }
        #endregion

        public DateTime Created { get { return _created; } }

        public Customer Customer { get { return _customer; } }
        public bool ToBeDelivered { get; private set; }

        #region Constructors
        public Order(Customer customer, bool toBeDelivered) : this()
        {
            _customer = customer;
            ToBeDelivered = toBeDelivered;
        }
        public Order()
        {
            _counter++;
            _id = _counter;
            _created = DateTime.Now;
            _lines = new List<OrderLine>();
        }
        #endregion

        #region Methods
        public void AddOrderLine(OrderLine line)
        {
            _lines.Add(line);
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (OrderLine line in _lines)
            {
                total += line.SubTotal();
            }
            total += (ToBeDelivered) ? CompanyInfoSingleton.GetInstance().DeliveryCost : 0;
            return total;
        }

        public void PrintReciept()
        {
            Console.WriteLine($"Order nummer {_id}");
            Console.WriteLine($"Orderdato {_created.ToShortDateString()}");
            foreach (OrderLine line in _lines)
            {
                Console.WriteLine(line.ToString());
            }
            Console.WriteLine($"Total pris {CalculateTotal()} kr. moms {CalculateTotal() / 5}");
        }

        public List<OrderLine> GetAllOrderLines()
        {
            return _lines;
        }
        #endregion
    }
}
