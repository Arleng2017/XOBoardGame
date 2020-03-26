using System;
using System.Collections.Generic;
using System.Linq;

namespace XOBoardGame
{
    public class GameBoarder
    {
        Player player1;
        Player player2;
        public Player theWinner { get; private set; } = null;

        static List<List<int>> WinnerCheck = new List<List<int>>() {
            new List<int>{0,1,2 },
            new List<int>{3,4,5 },
            new List<int>{6,7,8 },
            new List<int>{0,3,6 },
            new List<int>{1,4,7 },
            new List<int>{2,5,8 },
            new List<int>{0,4,8 },
            new List<int>{2,4,6 }
         };

        public static List<string> valueInBoard = new List<string>()
        {
            "0","1","2","3","4","5","6","7","8"
        };

        public GameBoarder(string player1Name, string player2Name)
        {
            player1 = new Player(player1Name);
            player2 = new Player(player2Name);
        }

        public static void BoardGameDisplay()
        {
            int i = 0;
            foreach (var value in valueInBoard)
            {
                Console.Write(value);
                if (i == 2) { Console.WriteLine(); i = 0; }
                else i++; 
            }
        }

        public bool InputValueToBorder(int input, bool isPlayer1)
        {
            if (valueInBoard.ElementAt(input) != "x" && valueInBoard.ElementAt(input) != "o")
            {
                if (isPlayer1)
                {
                    valueInBoard[input] = "x";
                    player1.inputValue(input);
                }
                else
                {
                    valueInBoard[input] = "o";
                    player2.inputValue(input);

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GameCalulate(bool isPlayer1)
        {
            int winner = 0;
            var haveTheWinner = false;
            foreach (var check in WinnerCheck)
            {
                winner = 0;
                foreach (var data in check)
                {
                    if (isPlayer1)
                    {
                        if (player1.PlayerInput.Any(it => it == data)) { winner++; };
                    }
                    else
                    {
                        if (player2.PlayerInput.Any(it => it == data)) { winner++; };
                    }
                }
                if (winner >= 3)
                {
                    haveTheWinner = true;
                    theWinner = isPlayer1 ? player1 : player2;
                    break;
                }
            }
            return haveTheWinner;
        }

        public Player GetTheWinner()
            => theWinner;
    }
}
