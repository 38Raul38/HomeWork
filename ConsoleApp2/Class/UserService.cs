namespace ConsoleApp2;
using System.Text.Json;

public class UserService : IUserService
{
    public List<User> Users { get; set; } = new();

    public User LoginUser(LoginDto loginDto)
    {
        if (!ValidateService.ValidateLogin(loginDto))
            throw new Exception("Invalid login credentials");

        var json = File.ReadAllText("./Data/Users.json");

        if (json.Length > 0)
        {
            Users = JsonSerializer.Deserialize<List<User>>(json);

            foreach (var user in Users)
            {
                if (user.Username == loginDto.username && user.Password == loginDto.password)
                {
                    Console.WriteLine("User logged in successfully");
                    return user;
                }
            }

            throw new Exception("Invalid login credentials");
        }

        throw new Exception("No users found");
    }

    public void RegisterUser(RegisterDto registerDto)
    {
        if (!ValidateService.ValidateRegister(registerDto))
        {
            throw new Exception("Invalid registration credentials");
        }

        var json = File.ReadAllText("Data/Users.json");

        if (json.Length > 0)
        {
            Users = JsonSerializer.Deserialize<List<User>>(json);
        }

        Users.Add(new User()
        {
            Username = registerDto.username,
            Password = registerDto.password,
        });

        var jsonString = JsonSerializer.Serialize(Users);

        File.WriteAllText("./Data/Users.json", jsonString);

        Console.WriteLine("User registered successfully");
    }
}