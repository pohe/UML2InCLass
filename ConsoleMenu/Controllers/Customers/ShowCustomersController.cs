using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.Customers
{
    public class ShowCustomersController
    {
        private ICustomerRepository _customerRepository;
        public ShowCustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void ShowAllMenuItems()
        {
            _customerRepository.PrintAllCustomers();
        }
    }
}
