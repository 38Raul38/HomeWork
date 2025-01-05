namespace ConsoleApp1;

public interface ICalculatorOperation
{
    public string Name { get; set; }
    public double Execute(double a, double b);
}