namespace ConsoleApp2;
public interface IUser
{
    public Guid Id { get; set; }
    public Guid ShowroomId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}