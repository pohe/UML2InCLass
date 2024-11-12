// See https://aka.ms/new-console-template for more information
using ConsoleMenu24.Menu;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");

MenuItemRepository mr = new MenuItemRepository();
MenuItem expensivePizza = mr.MostExpensivePizza();
if (expensivePizza != null)
    Console.WriteLine($"dyreste pizza {expensivePizza}");
else
    Console.WriteLine("Der findes ikke en dyreste pizza");

UserMenu menu = new UserMenu();
menu.ShowMenu();
