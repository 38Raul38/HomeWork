using System.Text.Json;
namespace ConsoleApp2.Services;

public class ShowroomServices : IShowroomService
{
    List<Showroom> showrooms = new List<Showroom>();

    public void CreateShowroom(string name, int carCapacity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
          throw new Exception("Showroom name cannot be empty.");
        }
        
        try
        {
            if (carCapacity <= 0 || carCapacity > 51)
            {
                throw new Exception("Showroom capacity must be between 1 and 50.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        
        var json = File.ReadAllText("./Data/showrooms.json");

         if (json.Length > 0)
         {
             showrooms = JsonSerializer.Deserialize<List<Showroom>>(json);
         }
         
         foreach (var showroom in showrooms)
         {
             if (showroom.Name == name)
             {
                 throw new Exception("Showroom already exists.");
             }
         }
        
        // showrooms.Add(new Showroom(name, carCapacity));
        
        showrooms.Add(new Showroom(name, carCapacity)
         {
             Name = name,
             CarCapacity = carCapacity,
             Cars = new List<Car>()
         });
        
        var jsonString = JsonSerializer.Serialize(showrooms);
         
        File.WriteAllText("./Data/showrooms.json", jsonString);
        Console.WriteLine("Showroom created successfully");
    }

    public void RemoveShowroom()
    {
        var json = File.ReadAllText("./Data/showrooms.json");
     
         if (json.Length > 0)
         {
             showrooms = JsonSerializer.Deserialize<List<Showroom>>(json);
         }
        
        showrooms.ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("Enter Showroom name to remove: ");
        string name = Console.ReadLine();
        var showroomToRemove = showrooms.FirstOrDefault(i => i.Name == name);
        if (showroomToRemove != null)
        {
            showrooms.Remove(showroomToRemove);
        }
        else
        {
            Console.WriteLine("Showroom not found");
        }
        
        var jsonString = JsonSerializer.Serialize(showrooms);
        
        File.WriteAllText("./Data/showrooms.json", jsonString);
        Console.WriteLine("Showroom successfully removed");
    }

    public void EditShowroom(string name, string newName, int newCarCapacity)
    {
        var json = File.ReadAllText("./Data/showrooms.json");

         if (json.Length > 0)
         {
             showrooms = JsonSerializer.Deserialize<List<Showroom>>(json);
         }
         
         var srToEdit = showrooms.FirstOrDefault(x => x.Name == name);

         if (srToEdit == null)
         {
             throw new Exception("Room not found.");
         }
         
         if (!string.IsNullOrWhiteSpace(newName))
         {
             if (showrooms.Any(x => x.Name == newName))
             {
                 throw new Exception("Room already exists.");
             }
             
             srToEdit.Name = newName;
         }

         if (newCarCapacity < srToEdit.Cars.Count)
         {
             throw new Exception("Car capacity must be greater than or equal to car capacity.");
         }
         
         srToEdit.CarCapacity = newCarCapacity;
         
         var jsonString = JsonSerializer.Serialize(showrooms);
         
         File.WriteAllText("./Data/showrooms.json", jsonString);

         Console.WriteLine("Showroom successfully edited");
    }
}
