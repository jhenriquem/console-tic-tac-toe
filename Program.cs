class TicTacToe
{
  static void Main(string[] args)
  {
    char[,] table = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

    char checkWinner(char[,] board)
    {
      for (int i = 0; i < 3; i++)
      {
        // Column check
        if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] != ' ')
        {
          return board[0, i];
        }
        // Line check
        if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != ' ')
        {
          return board[i, 0];
        }
      }

      // Diagonal checks
      if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != ' ')
      {
        return board[0, 0];
      }
      if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] != ' ')
      {
        return board[0, 2];
      }

      foreach (char cell in board)
      {
        if (cell == ' ')
        {
          return ' ';
        }
      }

      return 'd';
    }

    void displayTable(char[,] board)
    {
      Console.WriteLine($"   1   2   3");
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine($"{i + 1}  {board[i, 0]} | {board[i, 1]} | {board[i, 2]}");
        if (i < 2)
        {
          Console.WriteLine("  ---|---|---");
        }
      }
    }

    char crrPlayer = 'X';
    char result = ' ';

    Console.WriteLine("Hi! Good to see you!\nDo you want to play? Y or N");
    var startGame = Console.ReadLine();

    if (startGame == "Y" || startGame == "y")
    {
      while (result == ' ')
      {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------\n");
        Console.WriteLine($"{crrPlayer}'s turn\n");
        displayTable(table);

        int line, column;
        bool validInput;

        do
        {
          Console.Write("Line number (1-3) => ");
          validInput = int.TryParse(Console.ReadLine(), out line) && line >= 1 && line <= 3;
          if (!validInput)
          {
            Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");
          }
        } while (!validInput);

        do
        {
          Console.Write("Column number (1-3) => ");
          validInput = int.TryParse(Console.ReadLine(), out column) && column >= 1 && column <= 3;
          if (!validInput)
          {
            Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");
          }
        } while (!validInput);

        if (table[line - 1, column - 1] != ' ')
        {
          Console.WriteLine("Invalid position! Please choose another spot.");
          continue;
        }

        table[line - 1, column - 1] = crrPlayer;
        result = checkWinner(table);

        crrPlayer = crrPlayer == 'X' ? 'O' : 'X';
      }

      Console.Clear();
      Console.WriteLine("--------------------------------------------------\n");
      displayTable(table);
      if (result == 'd')
      {
        Console.WriteLine("It's a draw!");
      }
      else
      {
        Console.WriteLine($"{result} wins!");
      }
    }
  }
}
