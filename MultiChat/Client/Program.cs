using System.Net.Sockets;
using System.Text;

try
{
    using var client = new TcpClient();
    await client.ConnectAsync("127.0.0.1", 3003);

    using var networkStream = client.GetStream();
    using var writer = new StreamWriter(networkStream, Encoding.UTF8) { AutoFlush = true };
    using var reader = new StreamReader(networkStream, Encoding.UTF8);

    var Task1 = Task.Run(async () =>
    {
        while (true)
        {
            string? message = await reader.ReadLineAsync();

            Console.WriteLine($"Received: {message}");
        }
    });

    while (true)
    {
        Console.WriteLine("Enter message to send to server or type 'quit' to exit:");
        string Cmessage = Console.ReadLine();

        await writer.WriteLineAsync(Cmessage);

        if (Cmessage == null)
            continue;

        if (Cmessage.ToLower() == "quit")
            break;
    }
    
    
}
catch (Exception e)
{
    Console.WriteLine($"Client error: {e.Message}");
}