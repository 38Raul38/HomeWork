namespace EF_Core_Project;
using System.ComponentModel.DataAnnotations;
using CodeFirst.Data.Contexts;
using EF_Core_Project.Data.Models;



public class Methods
{
    private readonly GameShopContext _context;

    public Methods(GameShopContext context)
    {
        _context = context;
    }
    

    public void GetGameCatalog()
    {
        var gameCatalog = _context.Games
            .Select(g => new { 
                g.Id,
                g.Name,
                GenreName = g.Genre.Name,
                PlatformName = g.Platform.Name,
                g.Price
                
            })
            .ToList();

        foreach (var game in gameCatalog)
        {
            Console.WriteLine(
                $"Id: {game.Id}" +
                $"   Name: {game.Name}" +
                $" - Genre: {game.GenreName}" +
                $" - Platform: {game.PlatformName}" +
                $" - Price: {game.Price} USD");
        }
    }

    public void TopUpBalance(decimal amount, int userId)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Error! Amount must be greater than 0");
        }
        
        var user = _context.Users.Find(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Balance += amount;
        _context.SaveChanges();
    }

    public void BuyGame(int userId, int gameId, int count)
    {
        var user = _context.Users.Find(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var game = _context.Games.Find(gameId);
        if (game == null)
        {
            Console.WriteLine("Game not found");
            return;
        }

        decimal totalAmount = game.Price * count;

        if (user.Balance < totalAmount )
        {
            Console.WriteLine("You don't have enough funds");
            return;
        }
        
        user.Balance -= totalAmount;

        Order order = new()
        {   
            UserId = userId,
            Date = DateTime.Now,
            totalAmount = totalAmount,
            OrderСompositions = new List<OrderСomposition>
            {
                new()
                {
                    GameId = gameId,
                    Count = count,
                    TotalAmount = totalAmount
                }
            }
        };
        
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}





