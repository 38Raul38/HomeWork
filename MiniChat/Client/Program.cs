using System.Net;
using System.Net.Sockets;
using System.Text;

var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

var address = IPAddress.Parse("127.0.0.1");
var serverEndPoint = new IPEndPoint(address, 3003);

var buffer = new byte[1024]; // делаю буферный массив для получения данных 


try
{
    clientSocket.Connect(serverEndPoint);

        while (true)
        {
            Console.WriteLine("Enter message to send to server or type 'quit' to exit:");
            string Smessage = Console.ReadLine();

            byte[] messageBytes = Encoding.UTF8.GetBytes(Smessage);
            clientSocket.Send(messageBytes);
            Console.WriteLine($"Sent message: {Smessage}");

            if (Smessage.ToLower() == "quit")
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                break;
            }
            
            var bytesRead = clientSocket.Receive(buffer);
            var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received message: {message}");
        }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
