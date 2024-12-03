using PizzaLibrary.Data;
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
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> _menuItemList;

        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }
        public int Count { get { return _menuItemList.Count; } }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.No == no)
                    return menuItem;
            }
            return null;
        }

        public void RemoveMenuItem(int no)
        {
            MenuItem foundMenuItem = GetMenuItemByNo(no);
            if (foundMenuItem != null)
            {
                _menuItemList.Remove(foundMenuItem);
            }
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem menuItem in _menuItemList)
            {
                Console.WriteLine(menuItem);
            }
        }

        public MenuItem MostExpensivePizza()
        {
            if(_menuItemList== null || _menuItemList.Count == 0)
            {
                return null;
            }
            MenuItem mostExpensive = new MenuItem();
            mostExpensive.Price = 0;//Er default 0
            foreach(MenuItem menuItem in _menuItemList)
            {
                if (menuItem.TheMenuType == MenuType.PIZZECLASSSICHE 
                    || menuItem.TheMenuType == MenuType.PIZZESPECIALI  
                    && menuItem.Price > mostExpensive.Price)
                {
                    mostExpensive = menuItem;
                }

            }
            return mostExpensive;
        }

        public List<MenuItem> FilterMenuItems(string filterCriteria)
        {
            List<MenuItem> filteredList = new List<MenuItem>();
            foreach (var mi in _menuItemList)
            {
                if (mi.Name.Contains(filterCriteria))
                {
                    filteredList.Add(mi);
                }
            }
            return filteredList;
        }

        public void UpdateMenuItem(MenuItem currentMenuItem)
        {
            if (currentMenuItem != null)
            {
                foreach (var menuItem in _menuItemList)
                {
                    if (menuItem.No == currentMenuItem.No)
                    {
                        //menuItem.No = currentMenuItem.No;
                        menuItem.Name = currentMenuItem.Name;
                        menuItem.Description = currentMenuItem.Description;
                        menuItem.Price = currentMenuItem.Price;
                        menuItem.TheMenuType = currentMenuItem.TheMenuType;
                        return;
                    }
                }
            }
        }

        

        public void UpdateMenuItem(int no, string name, string description, double price, MenuType upDatedMenuType)
        {
            MenuItem menuItemToUpdate = GetMenuItemByNo(no);
            menuItemToUpdate.Name = name;
            menuItemToUpdate.Description = description;
            menuItemToUpdate.Price = price;
            menuItemToUpdate.TheMenuType = upDatedMenuType;
        }

        
    }
}
