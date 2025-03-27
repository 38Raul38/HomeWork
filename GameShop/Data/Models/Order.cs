namespace EF_Core_Project.Data.Models;

public class Order
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal totalAmount { get; set; }
    public List<OrderСomposition> OrderСompositions { get; set; }
}