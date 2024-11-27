using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IAccessory
    {
        int Id { get; }
        string Name { get; }
        double Price { get; }

        string ToString();
    }
}
