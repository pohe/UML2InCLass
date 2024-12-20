﻿using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface ICustomerRepository
    {
        public int Count { get; }
        List<Customer> GetAll();
        void AddCustomer(Customer customer);
        Customer GetCustomerByMobile(string mobile);
        void RemoveCustomer(string mobile);
        void PrintAllCustomers();
        Customer? GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void AddCustomer2(string name, string mobile, string address);
        List<Customer> FilterCustomers(string name);

    }
}
