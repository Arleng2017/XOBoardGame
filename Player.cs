using System;
using System.Collections.Generic;

namespace XOBoardGame
{
    public class Player
    {
        public string Name { get; private set; }
        public List<int> PlayerInput { get;private set; }

        public Player(string name)
        {
            Name = name;
            PlayerInput = new List<int>();
        }

        public void InputValue(int input)
            => PlayerInput.Add(input);
    }
}
