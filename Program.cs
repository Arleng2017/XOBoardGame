using System;

namespace XOBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoarder gameboarder = new GameBoarder("Nerd", "Arleng");
            gameboarder.GameStart();
        }
    }
}
