using System.Runtime.InteropServices;
using EF_Project2.Data.Context;
using EF_Project2.Models;
using Microsoft.EntityFrameworkCore;

using var context = new ShowroomContext();


    var customers = new List<Customer>
        {
        new () { FirstName = "John", LastName = "Smith", Phone = "+19111111111", Email = "john.smith@mail.com" },
        new () { FirstName = "Michael", LastName = "Johnson", Phone = "+19222222222", Email = "michael.johnson@mail.com" },
        new () { FirstName = "David", LastName = "Brown", Phone = "+19333333333", Email = "david.brown@mail.com" },
        new () { FirstName = "Emily", LastName = "Davis", Phone = "+19444444444", Email = "emily.davis@mail.com" },
        new () { FirstName = "Sarah", LastName = "Miller", Phone = "+19555555555", Email = "sarah.miller@mail.com" },
        new () { FirstName = "James", LastName = "Wilson", Phone = "+19666666666", Email = "james.wilson@mail.com" },
        new () { FirstName = "Emma", LastName = "Moore", Phone = "+19777777777", Email = "emma.moore@mail.com" },
        new () { FirstName = "Robert", LastName = "Taylor", Phone = "+19888888888", Email = "robert.taylor@mail.com" },
        new () { FirstName = "Olivia", LastName = "Anderson", Phone = "+19999999999", Email = "olivia.anderson@mail.com" },
        new () { FirstName = "William", LastName = "Thomas", Phone = "+19000000000", Email = "william.thomas@mail.com" }
    };

    context.Customers.AddRange(customers);
    context.SaveChanges();


    var cars = new List<Car>
    {
        new () {  Brand = "Toyota", Model = "Camry", Year = 2022, Price = 30000 },
        new () {  Brand = "Honda", Model = "Civic", Year = 2023, Price = 25000 },
        new () {  Brand = "Ford", Model = "Mustang", Year = 2021, Price = 45000 },
        new () {  Brand = "BMW", Model = "X5", Year = 2020, Price = 60000 },
        new () {  Brand = "Mercedes", Model = "C-Class", Year = 2022, Price = 55000 }
    };

    context.Cars.AddRange(cars);
    context.SaveChanges();


var employees = new List<Employee>
{
    new Employee { FirstName = "Alice", LastName = "Johnson", Salary = 50000 },
    new Employee { FirstName = "Bob", LastName = "Anderson", Salary = 55000 },
    new Employee { FirstName = "Charlie", LastName = "Robinson", Salary = 60000 }
};

    context.Employees.AddRange(employees);
    context.SaveChanges();
    

    var sales = new List<Sale>
    {
        new Sale {  CarID = 1, CustomerID = 1, EmployeeID = 1, SaleDate = DateTime.Now},
        new Sale {  CarID = 2, CustomerID = 2, EmployeeID = 2, SaleDate = DateTime.Now},
        new Sale {  CarID = 3, CustomerID = 3, EmployeeID = 1, SaleDate = DateTime.Now},
        new Sale {  CarID = 4, CustomerID = 4, EmployeeID = 3, SaleDate = DateTime.Now},
        new Sale {  CarID = 5, CustomerID = 5, EmployeeID = 2, SaleDate = DateTime.Now}
    };

    context.Sales.AddRange(sales);
    context.SaveChanges();



    Console.WriteLine("Enter Customer Id: ");
    int customerID = int.Parse(Console.ReadLine());

    #region LINQ1

    // var carsPurchased = context.Sales
    //     .Where(s => s.CustomerID == customerID)
    //     .Select(s => s.Car)
    //     .ToList();
    //
    // foreach (var car in carsPurchased)
    // {
    //     Console.WriteLine($"{car.Id} - {car.Year} - {car.Brand} - {car.Model} - {car.Price}");
    // }

    #endregion

    #region LINQ2

    // var start = new DateTime(2021, 1, 5);
    // var end = new DateTime(2025, 4,9);
    //
    // var result = context.Sales.Where(s => s.SaleDate > start && s.SaleDate < end).ToList();
    //
    // foreach (var res in result)
    // {
    //     Console.WriteLine($"{res.Id} - {res.CustomerID} - {res.EmployeeID} - {res.CarID} - {res.SaleDate}");
    // }

    #endregion

    #region LING 3

    var result = context.Sales
        .Include(s => s.Employee)
        .GroupBy(s => s.EmployeeID)
        ;
        

    #endregion




    
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 