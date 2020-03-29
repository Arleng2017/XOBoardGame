using System;
using System.Collections.Generic;
using System.Linq;

namespace XOBoardGame
{
    public class GameBoarder
    {
        Player player1;
        Player player2;
        Player theWinner { get; set; } = null;

        public static List<string> valueInBoard = new List<string>()
        {
            "0","1","2","3","4","5","6","7","8"
        };

        public GameBoarder(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        static void BoardGameDisplay()
        {
            int i = 0;
            foreach (var value in valueInBoard)
            {
                Console.Write($"{value}  ");
                if (i == 2) { Console.WriteLine(); i = 0; }
                else i++;
            }
        }

        bool GameProcessing(bool isPlayer1)
        {
            var haveTheWinner = false;
            if (player1.CheckTheGameEnd() == true || player2.CheckTheGameEnd() == true)
            {
                theWinner = isPlayer1 ? player2 : player1;
                haveTheWinner = true;
            }
            return haveTheWinner;
        }

        Player GetTheWinner() => theWinner;

        public void GameStart()
        {
            BoardGameDisplay();
            int i = 0;
            do
            {
                var turn = i % 2 == 0;
                if (turn.InputValueToBoarder(player1, player2)) { i++; };
                Console.WriteLine();
                BoardGameDisplay();
                if (GameProcessing(i%2==0))
                {
                    Console.WriteLine("Game Over!!!");
                    Console.WriteLine("the winner is " + GetTheWinner().Name);
                    break;
                };
            } while (!GameProcessing(i % 2==0) && i < 9);
        }
    }
}
