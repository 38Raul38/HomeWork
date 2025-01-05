namespace ConsoleApp1;

public class Multiplication : ICalculatorOperation
{
    public string Name { get; set; } = nameof(Multiplication);
    public double Execute(double a, double b) => a * b;
}