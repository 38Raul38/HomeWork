using CodeFirst.Data.Contexts;
using EF_Project1;
using EF_Project2;
using Microsoft.EntityFrameworkCore;

using var context = new ShowroomContext();

//1) Eager Loading

// var cars = context.Cars
//     .Include(c => c.Dealer)
//     .ToList();
//
// foreach (var car in cars)
// {
//     Console.WriteLine($"{car.Make} {car.Model} ({car.Year}) - Dealer: {car.Dealer?.Name}");
// }

//2) Explicit Loading

// var car = context.Cars.FirstOrDefault();
//
// if (car != null)
// {
//     context.Entry(car)
//         .Reference(c => c.Dealer)
//         .Load();
//
//     Console.WriteLine($"{car.Make} {car.Model} - Dealer: {car.Dealer?.Name}");
// }

//3)  Lazy Loading

var dealers = context.Dealers.ToList(); // или даже без ToList() в foreach

foreach (var dealer in dealers)
{
    Console.WriteLine(dealer.Name + " | " + dealer.Location);

    foreach (var car in dealer.Cars) // EF сам делает запрос
    {
        Console.WriteLine($"Make: {car.Make}, Model: {car.Model}");
    }
}




var crud = new CRUD(context);

if (!context.Dealers.Any())
{
    context.Dealers.Add(new Dealer { Name = "Default Dealer", Location = "Baku" });
    context.SaveChanges();
    Console.WriteLine("✅ Created default dealer with Id = 1\n");
}

bool exit = false;

while (!exit)
{
    Console.WriteLine("\n====== Car Management ======");
    Console.WriteLine("1. Add new car");
    Console.WriteLine("2. Update existing car");
    Console.WriteLine("3. Delete car");
    Console.WriteLine("4. View all cars");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Make: ");
            string make = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year.");
                break;
            }

            Console.Write("Dealer Id: ");
            if (!int.TryParse(Console.ReadLine(), out int dealerId))
            {
                Console.WriteLine("Invalid dealer Id.");
                break;
            }

            var newCar = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                DealerId = dealerId
            };

            crud.AddCar(newCar);
            break;

        case "2":
            Console.Write("Enter car Id to update: ");
            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid ID.");
                break;
            }

            Console.Write("New Make: ");
            string newMake = Console.ReadLine();

            Console.Write("New Model: ");
            string newModel = Console.ReadLine();

            Console.Write("New Year: ");
            if (!int.TryParse(Console.ReadLine(), out int newYear))
            {
                Console.WriteLine("Invalid year.");
                break;
            }

            crud.UpdateCar(updateId, newMake, newModel, newYear);
            break;

        case "3":
            Console.Write("Enter car Id to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invalid ID.");
                break;
            }

            crud.DeleteCar(deleteId);
            break;

        case "4":
            crud.GetAllCars();
            break;

        case "5":
            exit = true;
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}
