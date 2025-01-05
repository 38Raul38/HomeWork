namespace ConsoleApp1;

public class Addition : ICalculatorOperation
{
    public string Name { get; set; } = "Addition";
    public double Execute(double a, double b) => a + b;
}