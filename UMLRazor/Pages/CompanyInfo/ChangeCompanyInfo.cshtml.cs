using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLibrary.Models;

namespace UMLRazor.Pages.CompanyInfo
{
    public class ChangeCompanyInfoModel : PageModel
    {
        private CompanyInfoSingleton CompanyInfo { get; set; }


        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Mobile { get; set; }

        [BindProperty]
        public double Vat { get; set; }

        [BindProperty]
        public string CVR { get; set; }

        [BindProperty]
        public int ClubDiscount { get; set; }

        public ChangeCompanyInfoModel()
        {
            CompanyInfo = CompanyInfoSingleton.GetInstance();
            Name = CompanyInfo.Name;
            Mobile = CompanyInfo.Mobile;
            CVR = CompanyInfo.CVR;
            Vat = CompanyInfo.Vat;
            ClubDiscount = CompanyInfo.ClubDiscount;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            CompanyInfo.Name = Name;
            CompanyInfo.Mobile = Mobile;
            CompanyInfo.CVR = CVR;
            CompanyInfo.Vat = Vat;
            CompanyInfo.ClubDiscount = ClubDiscount;
            return RedirectToPage("/Index");
        }
    }
}
