class Tic_Tac_Toe
{

  static void Main(string[] args)
  {

    char[,] table = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    char checkWinner()
    {
      char returnValue = ' ';
      for (int i = 0; i < 3; i++)
      {
        // Column check
        if (table[0, i] == table[1, i] & table[0, i] == table[2, i])
        {
          returnValue = table[0, i];
        }
        // Line check
        else if (table[i, 0] == table[i, 1] & table[i, 0] == table[i, 2])
        {
          returnValue = table[i, 0];
        }
      }
      if (table[0, 0] == table[1, 1] & table[0, 0] == table[2, 2])
      {
        returnValue = table[0, 0];
      }
      else if (table[0, 2] == table[1, 1] & table[0, 2] == table[2, 0])
      {
        returnValue = table[0, 2];
      }
      return returnValue;
    }

    char crrPlayer = 'x';
    char check = ' ';

    Console.WriteLine(@"Hi! Good to see you\n
                        Do you want to play ? S or N");
    string startGame = Console.ReadLine();

    while (startGame == "S")
    {
      Console.WriteLine($@" 1   2   3\n");
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine($@"${i + 1} ${table[i, 0]}   |${table[i, 1]}   |${table[i, 2]}  \n -------------");
      }
      int line = Convert.ToInt32(Console.ReadLine());
      int column = Convert.ToInt32(Console.ReadLine());

      if (table[line, column] == ' ')
      {
        table[line, column] = crrPlayer;
        check = checkWinner();
      }
      if (check != ' ')
      {
        //
      }
      Console.WriteLine("Invalid position!");
    }
  }
}
