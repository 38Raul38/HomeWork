using System.ComponentModel.DataAnnotations;

namespace EF_Project2.Models;

public class Car
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Brand { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Model { get; set; }
    
    public int Year { get; set; }
    public decimal Price { get; set; }

    public List<ServiceHistory> ServiceHistories { get; set; } = new();

}