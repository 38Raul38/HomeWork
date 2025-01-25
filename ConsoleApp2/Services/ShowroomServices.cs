namespace ConsoleApp2.Services;

public class ShowroomServices
{
    List<Showroom> showrooms = new List<Showroom>();

    public void AddShowroom(Showroom showroom)
    {
        showrooms.Add(showroom);
    }

    public void RemoveShowroom()
    {
        showrooms.ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("Enter Showroom name to remove: ");
        string name = Console.ReadLine();
        foreach (var i in showrooms)
        {
            if (name == i.Name)
            {
                showrooms.Remove(i.Name);
            }
        }
    }
}