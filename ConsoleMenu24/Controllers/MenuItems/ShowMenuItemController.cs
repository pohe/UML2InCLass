using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu24.Controllers.MenuItems
{
    public class ShowMenuItemController
    {
        private IMenuItemRepository _menuItemRepo;
        public ShowMenuItemController(IMenuItemRepository menuRepository)
        {
            _menuItemRepo = menuRepository;
        }

        public void ShowAllMenuItems()
        {
            _menuItemRepo.PrintAllMenuItems();
        }

    }
}
