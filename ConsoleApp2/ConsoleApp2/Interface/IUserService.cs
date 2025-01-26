namespace ConsoleApp2;

public interface IUserService
{
    public User LoginUser(LoginDto loginDto);
    public void RegisterUser(RegisterDto registerDto);
}