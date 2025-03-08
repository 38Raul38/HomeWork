using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Project2.Models;

public class ServiceHistory
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Car")]
    public int CarID { get; set; }
    public Car Car { get; set; }
    
    public DateTime ServiceDate { get; set; }
    
    [Required]
    public decimal ServicePrice { get; set; }
}