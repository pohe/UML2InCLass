using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private int _id;
        private static int _counter = 0;

        [Required(ErrorMessage = "Write your address"), DisplayName("Home address")]
        public string Address { get; set;}
        public bool ClubMember { get; set; }
        public int Id { get { return _id; } set { _id = value; } }

        [Required(ErrorMessage = "Write your phone number"), DisplayName("Mobile number")]
        [StringLength(18, ErrorMessage = "Phonenumber can not be longer than 18 chars")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Write your name"), MaxLength(30), DisplayName("Customer name")]
        public string Name { get; set; }

        public string CustomerImage { get; set; }

        public Customer()
        {
            CustomerImage = "default.jpeg";
            _counter++;
            _id = _counter;
        }
        public Customer(string name, string mobile, string address)
        {
            CustomerImage = "default.jpeg";
            _counter++;
            _id = _counter;
            Name = name;
            Mobile = mobile;
            Address = address;
            ClubMember = false;
        }
        #region Methods
        public override string ToString()
        {
            return $"{_id} {Name} {Mobile} {Address} {(ClubMember ? "er medlem" : "Er ikke medlem")}";
        }
        #endregion
    }
}
