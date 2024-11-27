using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Accessory : IAccessory
    {
        #region Instance fields
        private int _id;
        private static int _counter = 0;

        #endregion

        #region Properties
        public int Id { get { return _id; } }
        public string Name { get; }

        public double Price { get; private set; }
        #endregion

        #region Constructors
        public Accessory(string name, double price)
        {
            _counter++;
            _id = _counter;
            Name = name;
            Price = price;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Id {_id} Navn {Name}";
        }

        #endregion


    }
}
