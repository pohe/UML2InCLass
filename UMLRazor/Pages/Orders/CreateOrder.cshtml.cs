using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        private ICustomerRepository _cRepo;

        [BindProperty]
        public string SearchCustomerMobile { get; set; }


        public Customer TheCustomer { get; set; }

        public CreateOrderModel(ICustomerRepository customerRepository)
        {
            _cRepo = customerRepository;
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
    }
}
