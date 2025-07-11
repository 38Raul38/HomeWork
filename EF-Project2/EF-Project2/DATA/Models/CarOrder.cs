using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Project1;

public class CarOrder
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("CarId")]
    public int CarId { get; set; }
    public Car Car { get; set; }
    
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}