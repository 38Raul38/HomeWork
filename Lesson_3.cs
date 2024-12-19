var park = new Park();

var car1 = new Car(FuelType.Diesel, BodyType.Sedan);
var bus1 = new Bus(FuelType.Diesel, BodyType.Sedan, 28);

park.AddTransport(car1);
park.AddTransport(bus1);

var bus2 = new Bus(FuelType.Petrol, BodyType.Coupe, 30);
park.EditTransport(bus1, bus2);

park.RemoveTransport(car1);


class Park
{
    public List<Transport> Vehicles = [];

     public void AddTransport(Transport transport)
    {
        Vehicles.Add(transport);
        Console.WriteLine("Transport Added");
    }

    public void RemoveTransport(Transport transport)
    {
        Vehicles.Remove(transport);
        Console.WriteLine("Transport Removed");
    }

    public void EditTransport(Transport oldtransport, Transport newtransport)
    {
        int index = Vehicles.IndexOf(oldtransport);
        Vehicles[index] = newtransport;
        Console.WriteLine("Transport Edited");
    }
}

enum FuelType
{
    Gas,
    Diesel,
    Petrol
}

enum BodyType
{
    Sedan,
    Coupe,
    Universal
}

class Transport
{
    public  FuelType FuelType { get; set; }
    public  BodyType BodyType { get; set; }

    protected Transport(FuelType fuelType, BodyType bodyType)
    {
        FuelType = fuelType;
        BodyType = bodyType;
    }
}

class Car : Transport
{
    public Car(FuelType fuel, BodyType body) : base(fuel, body)
    {
        
    }
}

class Bus : Transport
{
    public int Capasity { get; set; }
    
    public Bus(FuelType fuel, BodyType body, int capasity  ) : base(fuel, body)
    {
        Capasity = capasity;
    }
}

