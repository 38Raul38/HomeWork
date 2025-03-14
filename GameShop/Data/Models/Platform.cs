namespace EF_Core_Project.Data.Models;

public class Platform
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public List<Game> Games { get; set; }
}