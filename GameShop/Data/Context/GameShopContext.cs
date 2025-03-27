using CodeFirst.Data;
using EF_Core_Project;
using EF_Core_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Data.Contexts;

public class GameShopContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderСomposition> DealerOrderCompositions { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    
    public GameShopContext(DbContextOptions<GameShopContext> options) : base(options) { }
    
    public GameShopContext() { }
    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
            .GetConnectionString("Default");
        
        optionsBuilder.UseSqlServer(connectionString);
    }
}