using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener listener = new(IPAddress.Any, 3003);
listener.Start();

Console.WriteLine("Server started. Waiting for a connection...");

using TcpClient client = await listener.AcceptTcpClientAsync();
Console.WriteLine("Client connected.");

using NetworkStream stream = client.GetStream();
using var reader = new StreamReader(stream, Encoding.UTF8);
using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

List<List<char>> matrix = new()
{
    new() { '_', '_', '_' },
    new() { '_', '_', '_' },
    new() { '_', '_', '_' }
};

char currentPlayer = 'X';
bool gameOver = false;

while (!gameOver)
{
    Console.Clear();
    Console.WriteLine($"Player Turn: {currentPlayer}");
    OutputArray(matrix);

    await writer.WriteLineAsync(currentPlayer.ToString());

    if (currentPlayer == 'X')
    {
        int cursorX = 0, cursorY = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Player Turn: {currentPlayer}");
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
                if (matrix[cursorY][cursorX] == '_')
                {
                    matrix[cursorY][cursorX] = currentPlayer;
                    break;
                }
            }
        }
    }
    else
    {
        string move = await reader.ReadLineAsync();
        if (move == null) break;

        string[] parts = move.Split(' ');
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);

        if (matrix[y][x] == '_')
        {
            matrix[y][x] = currentPlayer;
        }
    }

    string boardState = string.Join("", matrix.SelectMany(row => row));
    await writer.WriteLineAsync(boardState);

    if (CheckWin(matrix, currentPlayer))
    {
        Console.Clear();
        OutputArray(matrix);
        Console.WriteLine($"Player {currentPlayer} won!");
        await writer.WriteLineAsync("Game Over");
        gameOver = true;
    }
    else if (IsDraw(matrix))
    {
        Console.Clear();
        OutputArray(matrix);
        Console.WriteLine("Draw!");
        await writer.WriteLineAsync("Game Over");
        gameOver = true;
    }
    else
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
    }
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

bool CheckWin(List<List<char>> board, char player)
{
    for (int i = 0; i < 3; i++)
        if (board[i][0] == player && board[i][1] == player && board[i][2] == player)
            return true;

    for (int j = 0; j < 3; j++)
        if (board[0][j] == player && board[1][j] == player && board[2][j] == player)
            return true;

    if (board[0][0] == player && board[1][1] == player && board[2][2] == player)
        return true;

    if (board[0][2] == player && board[1][1] == player && board[2][0] == player)
        return true;

    return false;
}

bool IsDraw(List<List<char>> board)
{
    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
            if (board[i][j] == '_')
                return false;

    return true;
}
