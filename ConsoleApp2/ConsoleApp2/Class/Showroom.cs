// namespace ConsoleApp2;
//
// public class Showroom : IShowroom
// {
//     public Guid Id { get; set; }
//     public string Name { get; set; }
//     public List<Car> Cars { get; set; }
//     public int CarCapacity { get; set; }
//     public int CarCount { get; set; }
//     public int SalesCount { get; set; }
//
//     public Showroom(string name, int carCapacity)
//     {
//         Id = Guid.NewGuid();
//         Name = name;
//         CarCapacity = carCapacity;
//         Cars = [];
//         SalesCount = 0;
//     }
//
//     List<Showroom> showrooms = new List<Showroom>();
//
//     public Showroom()
//     {
//     }
//
//     public void AddCar()
//     {
//         showrooms.ForEach(x => Console.WriteLine(x.Name));
//         Console.WriteLine("Choose Showroom to Add car");
//         string showroomName = Console.ReadLine();
//         Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(showroomName, StringComparison.OrdinalIgnoreCase));
//
//         Console.WriteLine("Enter car make:");
//         string make = Console.ReadLine();
//         Console.WriteLine("Enter car model:");
//         string model = Console.ReadLine();
//         Console.WriteLine("Enter car year:");
//         int year;
//         while (true)
//         {
//             string input = Console.ReadLine();
//
//             if (int.TryParse(input, out year) && year > 1885 && year <= DateTime.Now.Year)
//             {
//                 break;
//             }
//
//             Console.WriteLine("Invalid year. Please enter a valid car year (after 1885 and not in the future).");
//
//         }
//         DateTime carYear = new DateTime(year, 1, 1);
//
//         if (selectedShowroom.CarCount < selectedShowroom.CarCapacity)
//         {
//             selectedShowroom.Cars.Add(new Car
//             {
//                 Make = make,
//                 Model = model,
//                 Year = carYear
//             });
//             selectedShowroom.CarCount++;
//             Console.WriteLine("Car added successfully!");
//         }
//         else
//         {
//             Console.WriteLine("Showroom is at full capacity.");
//         }
//     }
//
//     public void DeleteCar()
//     {
//         showrooms.ForEach(x => Console.WriteLine(x.Name));
//         Console.WriteLine("Enter Showroom to remove");
//         string make = Console.ReadLine();
//         Showroom selectedShowroom =
//             showrooms.FirstOrDefault(x => x.Name.Equals(make, StringComparison.OrdinalIgnoreCase));
//
//         if (selectedShowroom == null)
//         {
//             Console.WriteLine("Showroom not found.");
//             return;
//         }
//
//         Cars.ForEach(x => Console.WriteLine($"Model: {x.Make}, Year: {x.Model}"));
//         Console.WriteLine("Enter car make to remove:");
//         string makeToRemove = Console.ReadLine();
//
//         var carToRemove = selectedShowroom.Cars.FirstOrDefault(c => c.Make.Equals(makeToRemove));
//         if (carToRemove != null)
//         {
//             selectedShowroom.Cars.Remove(carToRemove);
//             selectedShowroom.CarCount--;
//             Console.WriteLine("Car removed successfully!");
//         }
//         else
//         {
//             Console.WriteLine("Car not found in the selected showroom.");
//         }
//     }
//
//     public void UpdateCar()
//     {
//         showrooms.ForEach(x => Console.WriteLine(x.Name));
//         Console.WriteLine("Enter Showroom to edit");
//         string make = Console.ReadLine();
//         Showroom selectedShowroom =
//             showrooms.FirstOrDefault(x => x.Name.Equals(make, StringComparison.OrdinalIgnoreCase));
//
//         if (selectedShowroom == null)
//         {
//             Console.WriteLine("Showroom not found.");
//             return;
//         }
//
//         selectedShowroom.Cars.ForEach(x => Console.WriteLine($"Model: {x.Model}, Make: {x.Make}"));
//         Console.WriteLine("Enter car make to edit:");
//         string makeToEdit = Console.ReadLine();
//
//         var carToEdit = selectedShowroom.Cars.FirstOrDefault(c => c.Make.Equals(makeToEdit, StringComparison.OrdinalIgnoreCase));
//
//         if (carToEdit == null)
//         {
//             Console.WriteLine("Car not found.");
//             return;
//         }
//
//         Console.WriteLine($"Editing car: {carToEdit.Make} {carToEdit.Model} ({carToEdit.Year.Year})");
//
//         Console.WriteLine("Enter new make (leave empty to keep current):");
//         string newMake = Console.ReadLine();
//         if (!string.IsNullOrEmpty(newMake)) carToEdit.Make = newMake;
//
//         Console.WriteLine("Enter new model (leave empty to keep current):");
//         string newModel = Console.ReadLine();
//         if (!string.IsNullOrEmpty(newModel)) carToEdit.Model = newModel;
//
//         Console.WriteLine("Enter new year (leave empty to keep current):");
//         string newYearInput = Console.ReadLine();
//         if (int.TryParse(newYearInput, out int newYear) && newYear >= 1885 && newYear <= DateTime.Now.Year)
//         {
//             carToEdit.Year = new DateTime(newYear, 1, 1);
//         }
//         else if (!string.IsNullOrEmpty(newYearInput))
//         {
//             Console.WriteLine("Invalid year entered.");
//         }
//
//         Console.WriteLine("Car updated successfully!");
//     }
//
//     public void ShowCars()
//     {
//         showrooms.ForEach(x => Console.WriteLine(x.Name));
//         Console.WriteLine("Enter Showroom to show car");
//         string make = Console.ReadLine();
//         Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(make, StringComparison.OrdinalIgnoreCase));
//
//         if (selectedShowroom == null)
//         {
//             Console.WriteLine("Showroom not found.");
//             return;
//         }
//         
//         selectedShowroom.Cars.ForEach(x => Console.WriteLine($"Model: {x.Model}, Make: {x.Make}, Year: {x.Year}"));
//     }
// }
//
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
        Cars = new List<Car>();
        SalesCount = 0;
    }

    public Showroom()
    {
        Cars = new List<Car>();
    }

    public void AddCar(List<Showroom> showrooms)
    {
        showrooms.ForEach(x => Console.WriteLine(x.Name));
        Console.WriteLine("Choose Showroom to Add car");
        string showroomName = Console.ReadLine();
        Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(showroomName, StringComparison.OrdinalIgnoreCase));

        if (selectedShowroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }

        Console.WriteLine("Enter car make:");
        string make = Console.ReadLine();
        Console.WriteLine("Enter car model:");
        string model = Console.ReadLine();
        Console.WriteLine("Enter car year:");
        int year;
        while (!int.TryParse(Console.ReadLine(), out year) || year <= 1885 || year > DateTime.Now.Year)
        {
            Console.WriteLine("Invalid year. Please enter a valid car year (after 1885 and not in the future).");
        }

        if (selectedShowroom.CarCount < selectedShowroom.CarCapacity)
        {
            selectedShowroom.Cars.Add(new Car { Make = make, Model = model, Year = new DateTime(year, 1, 1) });
            selectedShowroom.CarCount++;
            Console.WriteLine("Car added successfully!");
        }
        else
        {
            Console.WriteLine("Showroom is at full capacity.");
        }
    }

    public void DeleteCar(List<Showroom> showrooms)
    {
        showrooms.ForEach(x => Console.WriteLine(x.Name));
        Console.WriteLine("Enter Showroom to remove a car from");
        string showroomName = Console.ReadLine();
        Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(showroomName, StringComparison.OrdinalIgnoreCase));

        if (selectedShowroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }

        selectedShowroom.Cars.ForEach(x => Console.WriteLine($"Make: {x.Make}, Model: {x.Model}, Year: {x.Year.Year}"));
        Console.WriteLine("Enter car make to remove:");
        string makeToRemove = Console.ReadLine();

        var carToRemove = selectedShowroom.Cars.FirstOrDefault(c => c.Make.Equals(makeToRemove, StringComparison.OrdinalIgnoreCase));
        if (carToRemove != null)
        {
            selectedShowroom.Cars.Remove(carToRemove);
            selectedShowroom.CarCount--;
            Console.WriteLine("Car removed successfully!");
        }
        else
        {
            Console.WriteLine("Car not found in the selected showroom.");
        }
    }

    public void UpdateCar(List<Showroom> showrooms)
    {
        showrooms.ForEach(x => Console.WriteLine(x.Name));
        Console.WriteLine("Enter Showroom to update car");
        string showroomName = Console.ReadLine();
        Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(showroomName, StringComparison.OrdinalIgnoreCase));

        if (selectedShowroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }

        selectedShowroom.Cars.ForEach(x => Console.WriteLine($"Make: {x.Make}, Model: {x.Model}, Year: {x.Year.Year}"));
        Console.WriteLine("Enter car make to update:");
        string makeToUpdate = Console.ReadLine();

        var carToUpdate = selectedShowroom.Cars.FirstOrDefault(c => c.Make.Equals(makeToUpdate, StringComparison.OrdinalIgnoreCase));

        if (carToUpdate == null)
        {
            Console.WriteLine("Car not found.");
            return;
        }

        Console.WriteLine("Enter new make (leave empty to keep current):");
        string newMake = Console.ReadLine();
        if (!string.IsNullOrEmpty(newMake)) carToUpdate.Make = newMake;

        Console.WriteLine("Enter new model (leave empty to keep current):");
        string newModel = Console.ReadLine();
        if (!string.IsNullOrEmpty(newModel)) carToUpdate.Model = newModel;

        Console.WriteLine("Enter new year (leave empty to keep current):");
        string newYearInput = Console.ReadLine();
        if (int.TryParse(newYearInput, out int newYear) && newYear >= 1885 && newYear <= DateTime.Now.Year)
        {
            carToUpdate.Year = new DateTime(newYear, 1, 1);
        }
        else if (!string.IsNullOrEmpty(newYearInput))
        {
            Console.WriteLine("Invalid year entered.");
        }

        Console.WriteLine("Car updated successfully!");
    }
    
    public void ShowCars(List<Showroom> showrooms)
    {
        showrooms.ForEach(x => Console.WriteLine(x.Name));
        Console.WriteLine("Enter Showroom to show cars");
        string showroomName = Console.ReadLine();
        Showroom selectedShowroom = showrooms.FirstOrDefault(x => x.Name.Equals(showroomName, StringComparison.OrdinalIgnoreCase));

        if (selectedShowroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }

        if (selectedShowroom.Cars.Count > 0)
        {
            selectedShowroom.Cars.ForEach(x => Console.WriteLine($"Make: {x.Make}, Model: {x.Model}, Year: {x.Year.Year}"));
        }
        else
        {
            Console.WriteLine("No cars available in this showroom.");
        }
    }
}

