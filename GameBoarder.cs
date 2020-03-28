﻿using System;
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
            bool canInputValue;
            GameBoarder.BoardGameDisplay();
            int i = 0;
            do
            {
                if (i % 2 == 0)
                {
                    canInputValue = player1.InputValueToBorder(true);
                }
                else
                {
                    canInputValue = player2.InputValueToBorder(false);

                }
                if (canInputValue) { i++; };


                Console.WriteLine();
                GameBoarder.BoardGameDisplay();
                if (GameCalulate(i%2==0))
                {
                    Console.WriteLine("the winner is " + GetTheWinner().Name);
                    break;
                };
            } while (!GameCalulate(i % 2==0) && i < 9);
        }

    }
}
