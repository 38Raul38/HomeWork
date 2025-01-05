using ConsoleApp1;

Addition add = new();
Subtraction subs = new();
Multiplication mul = new();
Division div = new();

double a;
while (true)
{
    Console.WriteLine("Enter first number: ");
    string input = Console.ReadLine();
    if (double.TryParse(input, out a))
    {
        break;
    }
    Console.WriteLine("Invalid Input! Try again");
}

double b;
while (true)
{
    Console.WriteLine("Enter second number: ");
    string input = Console.ReadLine();
    if (double.TryParse(input, out b))
    {
        break;
    }
    Console.WriteLine("Invalid Input! Try again");
}

Console.WriteLine("Choose operation: \n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division");

try
{
    int choise = int.Parse(Console.ReadLine());

    ICalculatorOperation operatoin = choise switch
    {
        1 => add,
        2 => subs,
        3 => mul,
        4 => div,
        _ => throw new ArgumentException("Error!!")
    };

    Console.WriteLine($"Result: {operatoin.Execute(a, b)}");
}

catch(Exception e)
{
    Console.WriteLine(e.Message);
}