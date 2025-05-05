using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener listener = new(IPAddress.Any, 3003);
listener.Start();

Console.WriteLine("Server started. Waiting for a connection...");

using TcpClient client = await listener.AcceptTcpClientAsync();

using var networkStream = client.GetStream();
using var writer = new StreamWriter(networkStream, Encoding.UTF8) { AutoFlush = true };
using var reader = new StreamReader(networkStream, Encoding.UTF8);

Console.WriteLine("Client connected.");

var Task1 = Task.Run(async () => {
    while (true)
    {

        string? message = await reader.ReadLineAsync();
        Console.WriteLine($"Received: {message}");
    }
});


while (true)
{
    Console.WriteLine("Enter message to send to client or type 'quit' to exit:");
    string Smessage = Console.ReadLine();

    await writer.WriteLineAsync(Smessage);
    if (Smessage.ToLower() == "quit")
        break;
}

await Task1;

listener.Stop();
Console.WriteLine("Server Stopped!!!");