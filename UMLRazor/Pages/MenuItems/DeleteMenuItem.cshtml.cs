using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class DeleteMenuItemModel : PageModel
    {
        private IMenuItemRepository repo;

        
        //public MenuItem MenuItem { get; set; }

        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int No { get; set; }
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public MenuType TheMenuType { get; set; }

        public DeleteMenuItemModel(IMenuItemRepository menuItemRepository)
        {
            this.repo = menuItemRepository;
        }

        public void OnGet(int deleteNo)
        {
            MenuItem theMenuItem = repo.GetMenuItemByNo(deleteNo);
            No = theMenuItem.No;
            Name = theMenuItem.Name;
            Description = theMenuItem.Description;
            Price = theMenuItem.Price;
            TheMenuType = theMenuItem.TheMenuType;
        }

        public IActionResult OnPost()
        {
            repo.RemoveMenuItem(this.No);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
