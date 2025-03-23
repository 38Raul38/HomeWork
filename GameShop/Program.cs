using System;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Data.Contexts;
using EF_Core_Project;

class Program
{
    static void Main()
    {
        var options = new DbContextOptionsBuilder<GameShopContext>()
            .UseSqlServer("Data Source=localhost,56210;Initial Catalog=GameShop;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        using var context = new GameShopContext(options);

        while (true)
        {
            Console.WriteLine("1. Registration");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choise: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new SignUp(context).Register();
                    break;
                case "2":
                    new SignIn(context).Login();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Error! Try again");
                    break;
            }
        }
    }
}
