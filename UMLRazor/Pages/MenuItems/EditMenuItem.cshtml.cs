using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class EditMenuItemModel : PageModel
    {
        private IMenuItemRepository repo;

        //[BindProperty]
        //public MenuItem CurrentMenuItem { get; set; }

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


        [BindProperty]
        public MenuType UpDatedMenuType { get; set; }

        public EditMenuItemModel(IMenuItemRepository menuItemRepository)
        {
            this.repo = menuItemRepository;
        }

        public IActionResult OnGet(int editNo)
        {
            MenuItem CurrentMenuItem = repo.GetMenuItemByNo(editNo);
            No = CurrentMenuItem.No;
            Name = CurrentMenuItem.Name;
            Description = CurrentMenuItem.Description;
            Price = CurrentMenuItem.Price;
            TheMenuType = CurrentMenuItem.TheMenuType;
            return Page();
        }

        public IActionResult OnPostEdit()
        {

            repo.UpdateMenuItem(No, Name, Description, Price, UpDatedMenuType);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
