using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Customers
{
    public class ShowCustomersModel : PageModel
    {
        private ICustomerRepository _customerRepository;
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public List<Customer> Customers { get; private set; }

        public ShowCustomersModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
     
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Customers = _customerRepository.FilterCustomers(FilterCriteria);
            }
            else
            {
                Customers = _customerRepository.GetAll();
            }
        }
    }
}
