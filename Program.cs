
Park park = new Park();
bool exit = false;
while (!exit)
{
    Console.WriteLine
    ("Select action\n " +
     "1. Add transport\n" +
     " 2. Delete transport\n" +
     " 3. Show All Transport\n" +
     " 4. Edit Transport\n" +
     " 5. Exit");

    int choose = int.Parse(Console.ReadLine());
    switch (choose)
    {
        case 1:
            park.AddTransport();
            break;
        case 2:
            park.RemoveTransport();
            break;
        case 3:
            park.ShowAllTransport();
            break;
        case 4:
            park.EditTransport();
            break;
        case 5:
            exit = true;
            break;
        default:
            Console.WriteLine("Wrong choose!!!");
            break;
    }
}



class Park
{
    public List<Transport> Vehicles = new List<Transport>();


    public void ShowAllTransport()
    {
        if (Vehicles.Count == 0)
        {
            Console.WriteLine("No vehicles in the park.");
            return;
        }

        for (int i = 0; i < Vehicles.Count; i++)
        {
            Console.WriteLine($"{i + 1})");
            Vehicles[i].ShowInfo();
            Console.WriteLine();
        }
    }

    public void AddTransport()
    {
        Console.WriteLine("Select type of vehicle:");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Bus");
        Console.Write("Enter choice to Add: ");
        string vehicles_type = Console.ReadLine();

        int maxSpeed;
        while (true)
        {
            Console.WriteLine("Enter max speed: ");
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
                    Console.WriteLine("Enter Fuel (1 - Gas, 2 - Diesel, 3 - Petrol):");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int fuelValue) && Enum.IsDefined(typeof(FuelType), fuelValue))
                    {
                        fuel = (FuelType)fuelValue;
                        break;
                    }

                    Console.WriteLine("Invalid input! Please enter a valid Fuel Type.");
                }

                Vehicles.Add(new Car("Car", fuel, maxSpeed));
                Console.WriteLine("Car added succesfully!!!");
                break;

            case "2":
                int capacity;
                while (true)
                {
                    Console.WriteLine("Enter Capacity: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out capacity))
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input! Please enter a valid Capacity.");
                }

                Vehicles.Add(new Bus("Bus", capacity, maxSpeed));
                break;
        }
    }


    public void RemoveTransport()
    {
        ShowAllTransport();
        Console.WriteLine("Enter index to Remove the transport: ");
        int index = int.Parse(Console.ReadLine());

        if (index > 0 && index <= Vehicles.Count)
        {
            Vehicles.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }

    public void EditTransport()
    {

        ShowAllTransport();
        Console.WriteLine("Enter index to Edit the transport: ");
        int index = int.Parse(Console.ReadLine());

        if (index > 0 && index <= Vehicles.Count)
        {
            Console.WriteLine("Select type of the new vehicle:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.Write("Enter choice: ");
            string vehicles_type = Console.ReadLine();

            int maxSpeed;
            while (true)
            {
                Console.Write("Enter  new max speed: ");
                if (int.TryParse(Console.ReadLine(), out maxSpeed))
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
                        Console.WriteLine("Enter Fuel (1 - Gas, 2 - Diesel, 3 - Petrol):");
                        if (int.TryParse(Console.ReadLine(), out int fuelValue) && Enum.IsDefined(typeof(FuelType), fuelValue))
                        {
                            fuel = (FuelType)fuelValue;
                            break;
                        }

                        Console.WriteLine("Invalid input! Please enter a valid Fuel Type.");
                    }

                    Vehicles[index - 1] = new Car("Car", fuel, maxSpeed);
                    break;
                case "2":
                    int capacity;
                    while (true)
                    {
                        Console.WriteLine("Enter Capacity: ");
                      
                        if (int.TryParse(Console.ReadLine(), out capacity))
                        {
                            break;
                        }
                        Console.WriteLine("Invalid input! Please enter a valid Capacity.");
                    }
                    Vehicles[index - 1] = new Bus("Bus" , capacity, maxSpeed);
                    break;
                default:
                    Console.WriteLine("Invalid choice! No changes were made.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
}


enum FuelType
    {
        Gas = 1,
        Diesel = 2,
        Petrol = 3
    }

    class Transport
    {
        public string Type { get; set; }
        public int MaxSpeed { get; set; }
        
        protected Transport(string type, int maxspeed)
        {
            Type = type;
            MaxSpeed = maxspeed;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"MaxSpeed: {MaxSpeed}");
        }
    }

    class Car : Transport
    {
        public FuelType FuelType { get; set; }

        public Car(string type, FuelType fuelType, int maxspeed) : base(type, maxspeed)
        {
            FuelType = fuelType;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Fuel Type: {FuelType}");
        }
    }

    class Bus : Transport
    {
        public int Capacity { get; set; }

        public Bus(string type, int сapacity, int maxspeed) : base(type, maxspeed)
        {
            Capacity = сapacity;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Capacity: {Capacity}");
        }
    }
