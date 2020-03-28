using System;

namespace XOBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoarder gameboarder = new GameBoarder("Nerd", "Arleng");
            bool isPlayer1;
            GameBoarder.BoardGameDisplay();
            int i = 0;
            do
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{gameboarder.player1.Name} input : ");
                    isPlayer1 = true;
                }
                else
                {
                    Console.Write($"{gameboarder.player2.Name} input : ");
                    isPlayer1 = false;

                }

                if (gameboarder.InputValueToBorder(int.Parse(Console.ReadLine()), isPlayer1))
                {
                    i++;
                };

                Console.WriteLine();
                GameBoarder.BoardGameDisplay();
                if (gameboarder.GameCalulate(isPlayer1))
                {
                    Console.WriteLine("the winner is " + gameboarder.GetTheWinner().Name);
                    break;
                };
            } while (!gameboarder.GameCalulate(isPlayer1) && i < 9);
        }
    }
}
