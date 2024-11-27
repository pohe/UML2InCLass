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
        private IShoppingBasket _shoppingBasket;
        private IAccessoriesRepository _aRepo;
        private IOrderRepository _oRepo;

        [BindProperty]
        public string SearchCustomerMobile { get; set; }
        public string MessageCustomer { get; set; }
        public string MessageOrder { get; set; }

        public Customer TheCustomer { get; set; }

        [BindProperty]
        public int ChosenMenuItem { get; set; }

        public List<SelectListItem> MenuItemSelectList { get; set; }

        [BindProperty]
        public int Amount { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        public List<SelectListItem> AsseccorySelectList { get; set; }

        [BindProperty]
        public int ChoosenAsseccory { get; set; }

        public string Delivery { get; set; }

        public string[] WhereToEat = new string[] { "Deliver", "Eat here" };


        public List<OrderLine> OrderLines { get; set; }

        public CreateOrderModel(
            ICustomerRepository customerRepository,
            IMenuItemRepository menuItemRepository, 
            IShoppingBasket shoppingBasket, 
            IAccessoriesRepository accessoriesRepository,
            IOrderRepository orderRepository)
        {
            _cRepo = customerRepository;
            _mRepo = menuItemRepository;
            _shoppingBasket = shoppingBasket;
            _aRepo = accessoriesRepository;
            _oRepo = orderRepository;
            createMenuSelectList();
            CreateAsseccorySelectList();
            if (_shoppingBasket.CurrentCustomer != null)
                TheCustomer = _shoppingBasket.CurrentCustomer;

            if (_shoppingBasket.GetAll().Count > 0)
                OrderLines = _shoppingBasket.GetAll();
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

        private void CreateAsseccorySelectList()
        {
            AsseccorySelectList = new List<SelectListItem>();
            AsseccorySelectList.Add(new SelectListItem("Select an item", "-1"));
            foreach (var item in _aRepo.GetAll())
            {
                SelectListItem sli = new SelectListItem(item.Name, item.Id.ToString());
                AsseccorySelectList.Add(sli);
            }
        }

        public void OnGet()
        {
        }

        public void OnPostCustomer()
        {
            TheCustomer = _cRepo.GetCustomerByMobile(SearchCustomerMobile);
            if (TheCustomer == null)
                MessageCustomer = "Customer does not exist - create a new customer";
            else
                _shoppingBasket.CurrentCustomer = TheCustomer;
        }

        public void OnPostAddToOrder()
        {
            if( Amount >0)
            {
                MenuItem menuItemToOrder = _mRepo.GetMenuItemByNo(ChosenMenuItem);
                if (menuItemToOrder != null)
                {
                    OrderLine ol = new OrderLine(menuItemToOrder, Amount, Comment);
                    _shoppingBasket.AddOrderLine(ol);
                }
            }
            OrderLines = _shoppingBasket.GetAll();
        }

        public void OnPostAddAccessories(int orderLineId)
        {
            if (ChoosenAsseccory > -1)
            {
                OrderLine currentOrderline = _shoppingBasket.GetOrderLineById(orderLineId);
                Accessory addAccessoryToOrderLine = _aRepo.GetAccessoryById(ChoosenAsseccory);

                if (currentOrderline != null)
                {
                    currentOrderline.AddExtraAccessory(addAccessoryToOrderLine);
                }
            }
            //OrderLines = _shoppingBasket.GetAll();

        }

        public void OnPostDeleteOrderLine(int orderLineId)
        {
            _shoppingBasket.RemoveOrderLine(orderLineId);
            //OrderLines = _shoppingBasket.GetAll();
        }

        public IActionResult OnPostCreateOrder()
        {
            if (TheCustomer == null || _shoppingBasket.GetAll().Count == 0)
            {
                MessageCustomer = TheCustomer == null ? "Please select a customer" : "";
                MessageOrder = _shoppingBasket.GetAll().Count == 0 ? "Please add a menuitem" : "";
            }
            else
            {
                _shoppingBasket.ToBeDelivered = Delivery == "Deliver";
                OrderLines = _shoppingBasket.GetAll();
                Order newOrder = new Order(TheCustomer, _shoppingBasket.ToBeDelivered);
                foreach (OrderLine item in OrderLines)
                {
                    newOrder.AddOrderLine(item);
                }
                _oRepo.AddOrder(newOrder);
                _shoppingBasket.ClearAll();
                return RedirectToPage("ShowOrder", "ShowOrder", new { id = newOrder.Id });
            }

            return Page();
        }
    }
}
