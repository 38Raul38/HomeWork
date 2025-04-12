using ConsoleApp2;
using ConsoleApp2.Context;

var context = new AppDbContext();
var studentManager = new Methods.StudentManager(context);

Console.WriteLine("Enter Choise:");
Console.WriteLine("1 - Add Student");
Console.WriteLine("2 - Show Students");
Console.WriteLine("3 - Exit");

string choose = Console.ReadLine();

switch (choose)
{
    case "1":
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        studentManager.AddStudentManually(name); 
        break;
    case "2":
        studentManager.ShowAllStudentsManually();
        break;
    case "3":
        return;
    default:
        Console.WriteLine("Wrong Choise!");
        break;
}