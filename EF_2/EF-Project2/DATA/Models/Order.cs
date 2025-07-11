using System.ComponentModel.DataAnnotations;

namespace EF_Project1;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    
    public DateTime OrderDate { get; set; }
}