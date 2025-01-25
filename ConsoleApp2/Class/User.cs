namespace ConsoleApp2;


public class User : IUser
{
    public Guid Id { get; set; }
    
    public Guid ShowroomId { get; set; }

    public string Username{ get; set; }
    
   public string Password { get; set; }
}