using CodeFirst.Data.Contexts;
using EF_Project1;             
using Microsoft.EntityFrameworkCore; 


namespace EF_Project2;

public class CRUD
{
    private readonly ShowroomContext _context;

    public CRUD(ShowroomContext context)
    {
        _context = context;
    }

    public void AddCar(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
        Console.WriteLine("✅ Машина добавлена");
    }

    public void UpdateCar(int id, string make, string model, int year)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            Console.WriteLine("❌ Машина не найдена");
            return;
        }

        car.Make = make;
        car.Model = model;
        car.Year = year;

        _context.SaveChanges();
        Console.WriteLine("✅ Машина обновлена");
    }

    public void DeleteCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            Console.WriteLine("❌ Машина не найдена");
            return;
        }

        _context.Cars.Remove(car);
        _context.SaveChanges();
        Console.WriteLine("✅ Машина удалена");
    }

    public void GetAllCars()
    {
        var cars = _context.Cars.Include(c => c.Dealer).ToList();

        foreach (var car in cars)
        {
            string dealerName = car.Dealer != null ? car.Dealer.Name : "No Dealer Assigned";
            Console.WriteLine($"🚗 {car.Make} {car.Model} ({car.Year}) - Dealer: {dealerName}");
        }
    }

}