using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Project1;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Make { get; set; }

    [Required]
    [StringLength(100)]
    public string Model { get; set; }

    [Range(1900, 2100)]
    public int Year { get; set; }

    [ForeignKey("DealerId")]
    public int DealerId { get; set; }

    public virtual Dealer Dealer { get; set; } 

    public List<Customer> Customers { get; set; } = new();
}