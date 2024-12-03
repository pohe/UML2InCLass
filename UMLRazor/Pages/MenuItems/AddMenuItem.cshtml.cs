using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class AddMenuItemModel : PageModel
    {
        private IMenuItemRepository repo;


        [BindProperty]
        public MenuItem MenuItem { get; set; }

        public AddMenuItemModel(IMenuItemRepository menuItemRepository)
        {
            repo = menuItemRepository;
        }

        public IActionResult OnGet()
        {
            return Page();

        }

        public IActionResult OnPost()
        {

            repo.AddMenuItem(MenuItem);
            return RedirectToPage("ShowMenuItems");
        }
    }
}
