namespace EF_Core_Project.Data.Models;

public class Order
{
    public int Id { get; set; }
    
    public string UserId { get; set; }
    public User User { get; set; }
    
    public DateTime Date { get; set; }
    
    public Decimal totalAmount { get; set; }
    public List<OrderСomposition> OrderСomposition { get; set; }
}