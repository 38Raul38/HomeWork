namespace EF_Core_Project.Data.Models;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }
    
    public decimal Balance { get; set; }
    
    public List<Order> Orders { get; set; }
}