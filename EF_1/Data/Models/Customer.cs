using System.ComponentModel.DataAnnotations;

namespace EF_Project2.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    
    public string Phone { get; set; }
    public string Email { get; set; }

    public List<Sale> Sales { get; set; } = new();
}