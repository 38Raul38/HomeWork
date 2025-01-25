namespace ConsoleApp2;

public class Showroom : IShowroom
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public int CarCapacity { get; set; }
    public int CarCount { get; set; }
    public int SalesCount { get; set; }

    public Showroom(string name, int carCapacity)
    {
        Id = Guid.NewGuid();
        Name = name;
        CarCapacity = carCapacity;
        Cars = [];
        SalesCount = 0;
    }

    // void AddCar()
    // {
    //     Console.WriteLine("Enter car make:");
    //     string make = Console.ReadLine();
    //     Console.WriteLine("Enter car model:");
    //     string model = Console.ReadLine();
    //     Console.WriteLine("Enter car year:");
    //     while (true)
    //     {
    //         
    //     }
    }
    
