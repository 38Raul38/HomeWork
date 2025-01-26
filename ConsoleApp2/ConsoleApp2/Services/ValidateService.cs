using System.Text.RegularExpressions;
namespace ConsoleApp2;

public static class ValidateService
{
    private static Regex loginRegex = new Regex(@"^[A-Za-z\d]{3,16}$");
    private static Regex passwordRegex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

    public static bool ValidateLogin(LoginDto loginDto)
    {
        return loginRegex.IsMatch(loginDto.username) && loginRegex.IsMatch(loginDto.password);
    }
    
    public static bool ValidateRegister(RegisterDto registerDto)
    {
        return loginRegex.IsMatch(registerDto.username) && passwordRegex.IsMatch(registerDto.password);
    }
}