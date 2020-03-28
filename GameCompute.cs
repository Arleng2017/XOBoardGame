using System;
using System.Collections.Generic;
using System.Linq;

namespace XOBoardGame
{
    public static class GameCompute
    {
        static readonly List<List<int>> WinnerCheck = new List<List<int>>() {
            new List<int>{0,1,2 },
            new List<int>{3,4,5 },
            new List<int>{6,7,8 },
            new List<int>{0,3,6 },
            new List<int>{1,4,7 },
            new List<int>{2,5,8 },
            new List<int>{0,4,8 },
            new List<int>{2,4,6 }
         };

        public static bool CheckTheGameEnd(this Player player)
        {
            bool haveTheWinner = false;
            foreach (var winnercheck in WinnerCheck)
            {
                if (!haveTheWinner)
                {
                    haveTheWinner = player.PlayerInput.Intersect(winnercheck).Count() == 3 ? true : false;
                }
                else
                    break;
            }

            return haveTheWinner;
        }

    }
}
