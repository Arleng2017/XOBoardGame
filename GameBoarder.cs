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

        static List<string> valueInBoard = new List<string>()
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

        bool InputValueToBorder(int input, bool isPlayer1)
        {
            if (valueInBoard.ElementAt(input) != "x" && valueInBoard.ElementAt(input) != "o")
            {
                if (isPlayer1)
                {
                    player1.inputValue(input);
                }
                else
                {
                    player2.inputValue(input);
                }

                valueInBoard[input] = isPlayer1 ? "x" : "o"; ;
                return true;
            }
            else
                return false;

        }

        bool GameCalulate(bool isPlayer1)
        {
            var haveTheWinner = false;
            if (player1.CheckTheGameEnd() == true || player2.CheckTheGameEnd() == true)
            {
                theWinner = isPlayer1 ? player1 : player2;
                haveTheWinner = true;
            }
            return haveTheWinner;
        }

        Player GetTheWinner() => theWinner;

        public void GameStart()
        {

            bool isPlayer1;
            GameBoarder.BoardGameDisplay();
            int i = 0;
            do
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{player1.Name} input : ");
                    isPlayer1 = true;
                }
                else
                {
                    Console.Write($"{player2.Name} input : ");
                    isPlayer1 = false;

                }

                if (InputValueToBorder(int.Parse(Console.ReadLine()), isPlayer1))
                {
                    i++;
                };

                Console.WriteLine();
                GameBoarder.BoardGameDisplay();
                if (GameCalulate(isPlayer1))
                {
                    Console.WriteLine("the winner is " + GetTheWinner().Name);
                    break;
                };
            } while (!GameCalulate(isPlayer1) && i < 9);
        }

    }
}
