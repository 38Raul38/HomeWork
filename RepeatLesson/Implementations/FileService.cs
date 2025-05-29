using System.Text.Json;
using Lesson11.Interfaces;
using Lesson11.Data.Model;



public class FileService : IFileService
{
    public List<Results> results { get; set; } = new();
    
    private readonly string filePath = "./Data/History.json";
    
    public void Save(Results result)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);

            if (!string.IsNullOrWhiteSpace(json))
            {
                results = JsonSerializer.Deserialize<List<Results>>(json) ?? new List<Results>();

            }
        }
        
        results.Add(result);
        
        var jsonString = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
        File.WriteAllText("./Data/History.json", jsonString);
        
    }

    public void Delete()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No history file found.");
            return;
        }

        var json = File.ReadAllText(filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("History is empty.");
            return;
        }

        results = JsonSerializer.Deserialize<List<Results>>(json) ?? new List<Results>();

        Console.Write("Enter movie title to delete: ");
        var titleToDelete = Console.ReadLine();

        var initialCount = results.Count;
        results = results.Where(r => !string.Equals(r.title, titleToDelete, StringComparison.OrdinalIgnoreCase)).ToList();

        if (results.Count == initialCount)
        {
            Console.WriteLine("Movie not found in history.");
        }
        else
        {
            var jsonString = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Movie deleted.");
        }
    }

}