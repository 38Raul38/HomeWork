class Park
{
    public List<Transport> vehicles = new List<Transport>();

    public void Show_Menu()
    {
        Console.WriteLine("$-----MENU-----$\n");
        Console.WriteLine("1. Add a vehicle");
        Console.WriteLine("2. Show all vehicles");
        Console.WriteLine("3. Start a vehicle");
        Console.WriteLine("4. Remove a vehicle");
        Console.WriteLine("5. Filter vehicles by type");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    public void Add_Transport()
    {
        Console.WriteLine("Select type of vehicle:");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Truck");
        Console.WriteLine("3. Bike");
        Console.WriteLine("4. Bus");
        Console.Write("Enter choice to Add: ");
        string vehicles_type = Console.ReadLine();

        Console.WriteLine("Enter Brand");
        string brand = Console.ReadLine();
        Console.Write("Enter model: ");
        string model = Console.ReadLine();

        int year;
        while (true)
        {
            Console.Write("Enter year: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out year) &&year > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid year.");
        }

        int maxSpeed;
        while (true)
        {
            Console.Write("Enter max speed: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out maxSpeed))
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid speed.");
        }


        switch (vehicles_type)
        {
            case "1":
                FuelType fuel;
                while (true)
                {
                    Console.WriteLine("Enter Fuel (1 - Petrol, 2 - Diesel, 3 - Electro): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int fuelValue) && Enum.IsDefined(typeof(FuelType), fuelValue))
                    {
                        fuel = (FuelType)fuelValue;
                        break;
                    }
                    Console.WriteLine("Invalid input! Please enter a valid Fuel Type.");
                }
                vehicles.Add(new Car("Car", brand, model, year, maxSpeed, fuel));
                break;
            
            case "2":
                int loadCapasity;
                while (true)
                {
                    Console.WriteLine("Enter load capacity: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out loadCapasity))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input! Please enter a valid Load Capasity.");
                }
                vehicles.Add(new Truck("Truck", brand, model, year, maxSpeed, loadCapasity));
                break;
            
            case "3":
                bool hasSidecar;
                while (true)
                {
                    Console.WriteLine("Does the bike have pedals? (true/false): ");
                    string input = Console.ReadLine();
                    if (bool.TryParse(input, out hasSidecar))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input! Please enter a valid value.");
                }
                vehicles.Add(new Bike("Bike", brand, model, year, maxSpeed, hasSidecar));
                break;
            
            case "4":
                int passengerCapacity;
                while (true)
                {
                    Console.WriteLine("Enter Passenger Capacity: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out passengerCapacity))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input! Please enter a valid Passenger Capasity.");
                }
                vehicles.Add(new Bus("Bus", brand, model, year, maxSpeed, passengerCapacity));
                break;
            
            default:
                Console.WriteLine("Invalid Input! ");
                break;
        }
    }

    public void ShowAllVehicles()
    {
        if (vehicles.Count == 0)
        {
            Console.WriteLine("No vehicles in the park.");
            return;
        }

        for (int i = 0; i < vehicles.Count; i++)
        {
            Console.WriteLine($"{i + 1})");
            vehicles[i].ShowInfo();
            Console.WriteLine();
        }
    }

    public void Start_Transport()
    {
        ShowAllVehicles();
        if (vehicles.Count == 0) return;

        Console.WriteLine("Choose index Transport to Move: ");
        int index = int.Parse(Console.ReadLine());
        if (index >= 0 && index < vehicles.Count)
        {
            vehicles[index].Move();
        }
        else
        {
            Console.WriteLine("Invalid Input! ");
        }
    }

    public void Remove_Transport()
    {
        ShowAllVehicles();
        Console.WriteLine("Enter index to Remove the transport: ");
        int index = int.Parse(Console.ReadLine());

        if (index > 0 && index < vehicles.Count)
        {
            vehicles.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void Filtering_Transport()
    {
        Console.WriteLine("Enter transport Type: ");
        string type = Console.ReadLine();
        for (int i = 0; i < vehicles.Count(); i++)
        {
            if (vehicles[i].Type == type)
            {
                vehicles[i].ShowInfo();
                Console.WriteLine();
            }
        }
    }
}

class Programm
{
    static void Main()
    {
        Park park = new Park();
        bool exit = false;


        while (!exit)
        {
            park.Show_Menu();
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    park.Add_Transport();
                    break;
                case "2":
                    park.ShowAllVehicles();
                    break;
                case "3":
                    park.Start_Transport();
                    break;
                case "4":
                    park.Remove_Transport();
                    break;
                case "5":
                    park.Filtering_Transport();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choose!!!");
                    break;
            }
        }
    }
}


class Transport
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }

        protected Transport(string type, string brand, string model, int year, int maxSpeed)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Year = year;
            MaxSpeed = maxSpeed;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"MaxSpeed: {MaxSpeed}");
        }

        public virtual void Move()
        {
            Console.WriteLine(
                $"The {Brand}\n{Model} vehicle is traveling on the road at a speed of up to {MaxSpeed} km/h.");
        }
    }

    enum FuelType
    {
        Petrol = 1,
        Diesel = 2,
        Electro = 3
    }

    class Car : Transport
    {
        public FuelType FuelType { get; set; }

        public Car(string type, string brand, string model, int year, int maxSpeed, FuelType fuelType) : base(type, brand,
            model, year, maxSpeed)
        {
            FuelType = fuelType;
        }

        public override void Move()
        {
            Console.WriteLine(
                $"The {Brand}\n{Model} car is traveling on the road at a speed of up to {MaxSpeed} km/h.");
        }
        
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Fuel Type: {FuelType}");
        }
    }

    class Truck : Transport
    {
        public int LoadCapacity { get; set; }

        public Truck(string type, string brand, string model, int year, int maxSpeed, int loadCapacity) : base(type, brand, model, year, maxSpeed)
        {
            LoadCapacity = loadCapacity;
        }

        public override void Move()
        {
            Console.WriteLine(
                $"Truck {Brand} {Model} is transporting cargo.");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Load Capacity: {LoadCapacity}");
        }
    }
  
    class Bike : Transport
    {
        public bool HasSidecar { get; set; }

        public Bike(string type, string brand, string model, int year, int maxSpeed, bool hasSidecar) : base(type, brand, model, year, maxSpeed)
        {
            HasSidecar = hasSidecar;
        }

        public override void Move()
        {
            Console.WriteLine(
                $"A {Brand} {Model} motorcycle is speeding down the road.");
        }
        
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Has a Sidecar: {HasSidecar}");
        }
    }

    class Bus : Transport
    {
        public int PassengerCapacity { get; set; }

        public Bus(string type, string brand, string model, int year, int maxSpeed, int passengerCapacity) : base(type, brand, model, year, maxSpeed)
        {
            PassengerCapacity = passengerCapacity;
        }

        public override void Move()
        {
            Console.WriteLine(
                $"The {Brand} {Model} bus carries passengers.”");
        }
        
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Passenger Capacity: {PassengerCapacity}");
        }
    }