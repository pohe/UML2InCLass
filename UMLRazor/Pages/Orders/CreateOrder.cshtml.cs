using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UMLRazor.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {

        [BindProperty]
        public string SearchCustomerMobile { get; set; }



        public void OnGet()
        {
        }

        public void OnPostCustomer()
        {

        }
    }
}
