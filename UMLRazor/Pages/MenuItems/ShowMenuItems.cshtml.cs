using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.MenuItems
{
    public class ShowMenuItemsModel : PageModel
    {
        private IMenuItemRepository _repo;

        public List<MenuItem> MenuItems { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public ShowMenuItemsModel(IMenuItemRepository menuItemRepository)
        {
            _repo = menuItemRepository;
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                MenuItems = _repo.FilterMenuItems(FilterCriteria);
            }
            else
            {
                MenuItems = _repo.GetAll();
            }

        }
    }
}
