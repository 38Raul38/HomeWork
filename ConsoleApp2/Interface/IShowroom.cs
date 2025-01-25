namespace ConsoleApp2;

public interface IShowroom
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public int CarCapacity { get; set; }
    public int CarCount { get; set; }
    public int SalesCount { get; set; }
}