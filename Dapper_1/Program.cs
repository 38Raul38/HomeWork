using System.Data;
using Dapper;
using EF_Project_1;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");

#region Task 1

// using var connection = new SqlConnection(connectionString);
// var sqlQuery = "SELECT * FROM Cars";
//
// connection.Open();
//
// var cars = connection.Query<Car>(sqlQuery);
//
// foreach (var car in cars)
// {
//         Console.WriteLine($"{car.Id} - {car.Brand} - {car.Model} - {car.Price} - {car.Year}");
// }

#endregion

#region Task 2

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery = "UPDATE Cars SET Price = @NewPrice WHERE Id = @CarId";
//
// var parameters = new { NewPrice = 22000, CarId = 1 };
//
// var rowsAffected = connection.Execute(sqlQuery, parameters);
//
// Console.WriteLine($"{rowsAffected} rows affected...");

#endregion

#region Task 3

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery = "DELETE FROM Cars WHERE Id = @CarId";
//
// var rowsAffected = connection.Execute(sqlQuery, new {CarId = 1});

#endregion

#region Task 4

// using var connection = new SqlConnection(connectionString);
// var sqlQuery = "SELECT * FROM Cars WHERE Brand = @BrandName";
//
// connection.Open();
//
// var cars = connection.Query<Car>(sqlQuery, new {BrandName = "Honda"});
//
// foreach (var car in cars)
// {
//     Console.WriteLine($"{car.Id} - {car.Brand} - {car.Model} - {car.Price} - {car.Year}");
// }

#endregion