// See https://aka.ms/new-console-template for more information
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");
Customer c1 = new Customer("Peter","121212", "Gade 123");
Console.WriteLine(c1.ToString());

CustomerRepository crep = new CustomerRepository();
crep.AddCustomer(c1);
