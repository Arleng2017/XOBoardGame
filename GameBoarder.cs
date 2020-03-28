using System;
using System.Collections.Generic;
using System.Linq;

namespace XOBoardGame
{
    public class GameBoarder
    {
        public Player player1;
        public Player player2;
        private Player theWinner { get; set; } = null;

        readonly List<List<int>> WinnerCheck = new List<List<int>>() {
            new List<int>{0,1,2 },
            new List<int>{3,4,5 },
            new List<int>{6,7,8 },
            new List<int>{0,3,6 },
            new List<int>{1,4,7 },
            new List<int>{2,5,8 },
            new List<int>{0,4,8 },
            new List<int>{2,4,6 }
         };

        static List<string> valueInBoard = new List<string>()
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
                Console.Write($"{value}  ");
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

        //public bool Gram(this Player player)
        //{
        //    bool haveTheWinner = false;
        //    foreach (var winnercheck in WinnerCheck)
        //    {
        //        haveTheWinner = player.PlayerInput.Intersect(winnercheck).Count() == 3 ? true : false;
        //    }

        //    return haveTheWinner;
        //}


        public bool GameCalulate(bool isPlayer1)
        {
            var haveTheWinner = false;
            foreach (var check in WinnerCheck)
            {
                if (isPlayer1)
                {
                    if (player1.PlayerInput.Intersect(check).Count() == 3)
                    {
                        theWinner = player1;
                        haveTheWinner = true;
                        break;
                    };
                }
                else
                {
                    if (player2.PlayerInput.Intersect(check).Count() == 3)
                    {
                        haveTheWinner = true;
                        theWinner = player2;
                        break;
                    };
                }
            }
            return haveTheWinner;
        }

        public Player GetTheWinner() => theWinner;
    }
}
