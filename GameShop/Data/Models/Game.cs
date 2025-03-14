namespace EF_Core_Project.Data.Models;

public class Game
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    public decimal Price { get; set; }
}
