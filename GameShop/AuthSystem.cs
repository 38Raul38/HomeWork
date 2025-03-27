using System.ComponentModel.DataAnnotations;
using CodeFirst.Data.Contexts;
using EF_Core_Project.Data.Models;

namespace EF_Core_Project;

public class SignUp
{

    private readonly GameShopContext _context;

    public SignUp(GameShopContext context)
    {
        _context = context;
    }
    
    public void Register()
    {

            Console.WriteLine("Enter your email address");
            var email = Console.ReadLine();
        
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email can't be empty");
                return;
            }
        
            if (_context.Users.Any(u => u.Email == email))
            {
                Console.WriteLine("Email is already in use");

            }

            

            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password can't be empty");
            }
            
            
            
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can't be empty");
            }
        
        
        
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Balance = 0
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            
            Console.WriteLine("User registered successfully");
    }
}



public class SignIn
{
    
    private readonly GameShopContext _context;

    public SignIn(GameShopContext context)
    {
        _context = context;
    }
    

    public void Login()
    {
        Console.WriteLine("Enter your email address:");
        var email = Console.ReadLine();

        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }

        Console.WriteLine("Enter Password:");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Password can't be empty");
            return;
        }

        if (user.Password != password) 
        {
            Console.WriteLine("Incorrect password");
            return;
        }
        
        Console.WriteLine("Login successful");

        while (true)
        {
            Console.WriteLine("1. Get Game Catalog");
            Console.WriteLine("2. Top Up Balance");
            Console.WriteLine("3. Buy a Game");
            Console.WriteLine("Exit");
            Console.Write("Enter choose: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new Methods(_context).GetGameCatalog();
                    break;
                case "2":
                    Console.WriteLine("Enter amount: ");
                    if(decimal.TryParse(Console.ReadLine(), out var amount))
                        new Methods(_context).TopUpBalance(amount, user.Id);
                    else
                        Console.WriteLine("Invalid Input");
                    break;
                case "3":
                    Console.WriteLine("Enter Game Id: ");
                    if (!int.TryParse(Console.ReadLine(), out var gameId))
                    {
                        Console.WriteLine("Invalid Game Id");
                        break;
                    }

                    Console.WriteLine("Enter quantity");
                    if (!int.TryParse(Console.ReadLine(), out var count))
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }


                    try
                    {
                        new Methods(_context).BuyGame(user.Id, gameId, count);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Error! Try again");
                    break;
            }
        }

    }
}