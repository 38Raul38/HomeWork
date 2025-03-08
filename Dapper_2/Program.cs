using System.Collections;
using System.Data;
using Azure.Core;
using Dapper;
using EF_Project_1;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var config = configBuilder.Build();

var connectionString = config.GetConnectionString("Default");

#region Task 1.1

// using var connection = new SqlConnection(ConnectionStrings);
//
// connection.Open();
// var insertQuery = """
//                       INSERT INTO Cars (Brand, Model, Year, Price) VALUES
//                       ('Toyota', 'Camry', 2020, 25000),
//                       ('Honda', 'Civic', 2021, 22000),
//                       ('Ford', 'Mustang', 2019, 35000);
//                   """;
//
// connection.Execute(insertQuery);
//
// var selectQuery = "SELECT * FROM Cars";
// var cars = connection.Query<Car>(selectQuery);
//
// foreach (var car in cars)
// {
//     Console.WriteLine($"{car.Id} - {car.Brand} - {car.Model} - {car.Year} - {car.Price}");
// }

#endregion

#region Task 1.2

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var insertQuery = """
//                       INSERT INTO Owners (Name, CarId) 
//                       VALUES 
//                       ('John Smith', 1),
//                       ('Peter Johnson', 2),
//                       ('Michael Brown', 3);
//                   """;
//
// connection.Execute(insertQuery);
//
// var selectQuery = "SELECT * FROM Owners";
//
// var owners = connection.Query<Owners>(selectQuery);
//
// foreach (var owner in owners)
// {
//     Console.WriteLine($"{owner.Id} - {owner.Name} - {owner.CarId}");
// }
    
#endregion

#region Task 2

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery = "UPDATE Owners SET Name = @NewOwner WHERE CarId = @CarId";
//
// var parameters = new {NewOwner = "Lje Dmitriy", CarId = 1};
//
// var rowAffected = connection.Execute(sqlQuery, parameters);

#endregion

#region Task 3

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery1 = "DELETE FROM Owners WHERE CarId = @CarId";
// var sqlQuery2 = "DELETE FROM Cars WHERE Id = @CarId";
//
// var parametrs = new { CarId = 1 };
//
// connection.Execute(sqlQuery1, parametrs);
// connection.Execute(sqlQuery2, parametrs);   
    
#endregion

#region Task 4

using var connection = new SqlConnection(connectionString);

connection.Open();

var sqlQuery = @"
    SELECT c.Id, c.Brand, c.Model, c.Year, c.Price, o.Name AS OwnerName
    FROM Cars c
    INNER JOIN Owners o ON c.Id = o.CarId";

var a = connection.Query<Car>(sqlQuery);

foreach (var i in a)
{
    Console.WriteLine($"{i.Id} - {i.Brand} - {i.Model} - {i.Price} - {i.Year}");
    Console.WriteLine("________________________________________________________");
}

#endregion

#region Task 5

// using var connection = new SqlConnection(connectionString);
//
// connection.Open();
//
// var sqlQuery = @"
//     SELECT c.Id, c.Brand, c.Model, c.Year, c.Price
//     FROM Cars c
//     INNER JOIN Owners o ON c.Id = o.CarId
//     WHERE o.Name = @OwnerName";
//
// var a = connection.Query<Car>(sqlQuery, new {OwnerName = "Michael Brown" });
//
// foreach (var i in a)
// {
//      Console.WriteLine($"{i.Id} - {i.Brand} - {i.Model} - {i.Price} - {i.Year}");
//      Console.WriteLine("________________________________________________________");
// }


#endregion

