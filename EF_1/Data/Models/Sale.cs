using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Project2.Models;
            
public class Sale
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Car")]
    public int CarID { get; set; }
    public Car Car { get; set; }

    
    [ForeignKey("Customer")]
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }

    
    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }
    public Employee Employee { get; set; }


    public DateTime SaleDate { get; set; } = DateTime.Now;
}