// See https://aka.ms/new-console-template for more information
using ConsoleMenu.Menu;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Velkommen til Big Mamma Pizzaria");


//CustomerRepository crep = new CustomerRepository();
//List<Customer> customerMembers = crep.GetAllMembers();
//foreach(Customer c in customerMembers)
//{
//    Console.WriteLine(c.ToString());
//}

UserMenu menu = new UserMenu();
menu.ShowMenu();