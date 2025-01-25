using System.Text.RegularExpressions;
namespace ConsoleApp2;

public static class ValidateService
{
    private static Regex loginRegex = new Regex(@"^(?=.*[A-Za-z0-9]$)[A-Za-z]([A-Za-z\d.-_]){0,19}$");
    private static Regex passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%&_])[A-Za-z\d!@#$%&_]{8,16}$");

    public static bool ValidateLogin(LoginDto loginDto)
    {
        return loginRegex.IsMatch(loginDto.username) && loginRegex.IsMatch(loginDto.password);
    }
    
    public static bool ValidateRegister(RegisterDto registerDto)
    {
        return loginRegex.IsMatch(registerDto.username) && loginRegex.IsMatch(registerDto.password);
    }
}