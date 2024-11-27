using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfoSingleton
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public double Vat { get; set; }
        public string CVR { get; set; }
        public int ClubDiscount { get; set; }

        public int DeliveryCost { get; set; }
        private CompanyInfoSingleton()
        {
            Name = "Big Mamma";
            Mobile = "45656566";
            Vat = 25;
            CVR = "34345634";
            ClubDiscount = 10;
            DeliveryCost = 40;
        }

        private static CompanyInfoSingleton theInstance = null;
        

        public static CompanyInfoSingleton GetInstance()
        {
            if (theInstance == null)
                theInstance = new CompanyInfoSingleton();
            return theInstance;
        }

    }
}
