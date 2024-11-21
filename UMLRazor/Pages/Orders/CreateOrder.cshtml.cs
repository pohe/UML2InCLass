using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        private ICustomerRepository _cRepo;
        private IMenuItemRepository _mRepo;

        [BindProperty]
        public string SearchCustomerMobile { get; set; }


        public Customer TheCustomer { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        public List<SelectListItem> MenuItemSelectList { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public CreateOrderModel(
            ICustomerRepository customerRepository,
            IMenuItemRepository menuItemRepository)
        {
            _cRepo = customerRepository;
            _mRepo = menuItemRepository;
            createMenuSelectList();
        }

        private void createMenuSelectList()
        {
            MenuItemSelectList = new List<SelectListItem>();
            MenuItemSelectList.Add(new SelectListItem("Select an item", "-1"));
            foreach(MenuItem item in _mRepo.GetAll())
            {
                SelectListItem sli = new SelectListItem(item.Name, item.No.ToString());
                MenuItemSelectList.Add(sli);
            }
        }

        public void OnGet()
        {
        }

        public void OnPostCustomer()
        {
            TheCustomer = _cRepo.GetCustomerByMobile(SearchCustomerMobile);
            if (TheCustomer == null)
            {
                //ErrorMessage
            }
        }

        public void OnPostAddToOrder()
        {

        }
    }
}
