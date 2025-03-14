namespace EF_Core_Project.Data.Models;

public class Genre
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public List<Game> Games { get; set; }
}