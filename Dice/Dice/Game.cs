using System;

namespace Dice
{
    public class Game
    {
        private readonly int _numberOfDice;
        private Random _randon;
        private int[] _dice;
        
        public event EventHandler FellOutTwelve;

        public int Result { get; private set; }
       
        public Game(uint numberOfDice)
        {
            if (numberOfDice == 0 && numberOfDice < 6)
            {
                throw new Exception("The number of dice must be greater than 0, but not more than 5");
            }

            _randon = new Random();
            _dice = new int[numberOfDice];
            _numberOfDice = (int)numberOfDice;
        }

        public void StartGame()
        {
            Result = ThrowDice();
            FellOutTwelve?.Invoke(this, EventArgs.Empty);
        }

        private int ThrowDice()
        {
            int result = 0;

            for (int i = 0; i < _dice.Length; i++)
            {
                _dice[i] = _randon.Next(1, 7);
                result += _dice[i];
            }

            return result;
        }
    }
}
