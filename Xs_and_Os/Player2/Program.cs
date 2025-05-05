using System.Net;
using System.Net.Sockets;
using System.Text;

try
{
    using var client = new TcpClient();
    await client.ConnectAsync("127.0.0.1", 3003);

    using var stream = client.GetStream();
    using var reader = new StreamReader(stream, Encoding.UTF8);
    using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

    List<List<char>> matrix = new()
    {
        new() { '_', '_', '_' },
        new() { '_', '_', '_' },
        new() { '_', '_', '_' }
    };

    while (true)
    {
        string currentTurn = await reader.ReadLineAsync();
        if (currentTurn == "Game Over") break;

        Console.Clear();
        Console.WriteLine($"It's {currentTurn}'s turn");
        OutputArray(matrix);

        if (currentTurn == "O")
        {
            Console.WriteLine("Your turn!");

            int cursorX = 0, cursorY = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Player Turn: {currentTurn}");
                OutputArrayWithCursor(matrix, cursorX, cursorY);

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow && cursorX > 0)
                    cursorX--;
                if (key.Key == ConsoleKey.RightArrow && cursorX < 2)
                    cursorX++;
                if (key.Key == ConsoleKey.UpArrow && cursorY > 0)
                    cursorY--;
                if (key.Key == ConsoleKey.DownArrow && cursorY < 2)
                    cursorY++;

                if (key.Key == ConsoleKey.Enter)
                {
                    await writer.WriteLineAsync($"{cursorX} {cursorY}");
                    break;
                }
            }
        }

        string boardState = await reader.ReadLineAsync();
        if (boardState == "Game Over") break;
        UpdateMatrixFromString(matrix, boardState);
    }

    Console.WriteLine("Game over!");
}
catch (Exception e)
{
    Console.WriteLine($"Client error: {e.Message}");
}

void UpdateMatrixFromString(List<List<char>> board, string data)
{
    for (int y = 0; y < 3; y++)
        for (int x = 0; x < 3; x++)
            board[y][x] = data[y * 3 + x];
}

void OutputArray(List<List<char>> board)
{
    Console.WriteLine("   0   1   2");
    for (int y = 0; y < board.Count; y++)
    {
        Console.Write($"{y}  ");
        for (int x = 0; x < board[y].Count; x++)
        {
            Console.Write($" {board[y][x]} ");
            if (x < 2) Console.Write("|");
        }
        Console.WriteLine();
        if (y < 2) Console.WriteLine("  ---+---+---");
    }
}

void OutputArrayWithCursor(List<List<char>> board, int cursorX, int cursorY)
{
    Console.WriteLine("   0   1   2");
    for (int y = 0; y < board.Count; y++)
    {
        Console.Write($"{y}  ");
        for (int x = 0; x < board[y].Count; x++)
        {
            if (x == cursorX && y == cursorY)
                Console.Write($"[{board[y][x]}]");
            else
                Console.Write($" {board[y][x]} ");
            if (x < 2) Console.Write("|");
        }
        Console.WriteLine();
        if (y < 2) Console.WriteLine("  ---+---+---");
    }
}
