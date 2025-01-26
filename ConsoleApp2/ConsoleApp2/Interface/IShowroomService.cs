namespace ConsoleApp2;

public interface IShowroomService
{
    public void CreateShowroom(string name, int carCapacity);
    public void RemoveShowroom();
    public void EditShowroom(string name, string newName, int newCarCapacity);
}