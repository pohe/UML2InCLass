using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.Orders
{
    public class ShowOrderModel : PageModel
    {

        private IOrderRepository _oRepo;
        public CompanyInfoSingleton TheCompanyInfo { get; set; }
        public Order Order { get; set; }
        public ShowOrderModel(IOrderRepository orderRepository)
        {
            _oRepo = orderRepository;
            TheCompanyInfo = CompanyInfoSingleton.GetInstance();
        }
        public void OnGetShowOrder(int id)
        {
            Order = _oRepo.GetOrderById(id);
        }
    }
}
