namespace ConsoleApp1;

public class Division : ICalculatorOperation
{
    public string Name { get; set; } = nameof(Division);
    public double Execute(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException();
}