﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, Customer> _customers;
        public int Count { get { return _customers.Count; } }

        public CustomerRepository()
        {
            //_customers = new Dictionary<string, Customer>();
            _customers = MockData.CustomerData;
        }

        public List<Customer> GetAllMembers()
        {
            List<Customer> result = new List<Customer>();
            foreach(Customer c in _customers.Values)
            {
                if (c.ClubMember== true)
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public void AddCustomer(Customer customer)
        {
            if (!_customers.ContainsKey(customer.Mobile))
            {
                _customers.Add(customer.Mobile, customer);
            }
        }
        public List<Customer> GetAll()
        {
            //List<Customer> clist = new List<Customer>();
            //foreach (Customer customer in _customers.Values.)
            //{
            //    clist.Add(customer);
            //}
            return _customers.Values.ToList();
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if (mobile != null && _customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            else
            {
                return null;
            }
        }

        public void RemoveCustomer(string mobile)
        {
            if (mobile != null && _customers.ContainsKey(mobile))
            {
                _customers.Remove(mobile);
            }
        }

        public void PrintAllCustomers()
        {
            foreach (Customer customer in _customers.Values)
            {
                Console.WriteLine(customer);
            }
        }

        public override string ToString()
        {
            string returnString = "";
            foreach (Customer customer in _customers.Values)
            {
                returnString = customer.Name;
            }
            return returnString;
        }

    }
}
