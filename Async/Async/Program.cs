namespace Async;

class Program
{
    static async Task Main()
    {
        Random random = new();
        List<int> list = new();

         for (int i = 0; i < 20; i++)
        {
            int number = random.Next(1, 100);   
            list.Add(number);
        }
            
         
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"Number{i + 1}: {list[i]}");
        }

        var even = await FilterEvenAsync(list);
        var odd = await FilterOddAsync(list);
        var sum = await CalculateSumAsync(list);

        Console.WriteLine("\nEven Numbers:");
        even.ForEach(Console.WriteLine);

        Console.WriteLine("\nOdd Numbers:");
        odd.ForEach(Console.WriteLine);

        Console.WriteLine($"\nSum: {sum}"); 
    }

    
    #region Task1

static async Task<List<int>> FilterEvenAsync(List<int> numbers)
{
    return await Task.Run(async () =>
    {
        await Task.Delay(1500);
        return numbers.Where(x => x % 2 == 0).ToList();
    });
}
#endregion

    #region Task2

static async Task<List<int>> FilterOddAsync(List<int> numbers)
{
    return await Task.Run(async () =>
    {
        await Task.Delay(1500);
        return numbers.Where(x => x % 2 != 0).ToList();
    });
}
#endregion

    #region Task3

static async Task<int> CalculateSumAsync(List<int> numbers)
{
        await Task.Delay(1000);
        return numbers.Sum();
}
#endregion
}
