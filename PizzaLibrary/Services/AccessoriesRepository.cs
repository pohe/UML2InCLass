using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private List<Accessory> _accessories;
        public int Count { get { return _accessories.Count; } }

        public AccessoriesRepository()
        {
            _accessories = MockData.AccessoryData;
        }

        public void AddAccessory(Accessory accessory)
        {
            _accessories.Add(accessory);
        }
        public List<Accessory> GetAll()
        {
            return _accessories;
        }

        public Accessory GetAccessoryById(int id)
        {
            foreach (Accessory ac in _accessories)
            {
                if (ac.Id == id)
                {
                    return ac;
                }
            }
            return null;
        }

        public void PrintAllAccessories()
        {
            foreach (Accessory ac in _accessories)
            {
                Console.WriteLine(ac.ToString());
            }
        }

        public void RemoveAccessory(int id)
        {
            Accessory accessoryToRemove = GetAccessoryById(id);
            if (accessoryToRemove != null)
                _accessories.Remove(accessoryToRemove);
        }
    }
}
