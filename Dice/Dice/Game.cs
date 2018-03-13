using System;

namespace Dice
{
    public class Game
    {
        private readonly int _numberOfDices;
        private Random r;
        private int[] _dices;

        public event Action FellOutTwelve;

        public int Result { get; private set; }
       
        public Game(uint numberOfDices)
        {
            if (numberOfDices == 0 && numberOfDices < 6)
            {
                throw new Exception("The number of dices must be greater than 0, but not more than 5");
            }

            r = new Random();
            _dices = new int[numberOfDices];
            _numberOfDices = (int)numberOfDices;
        }

        public void StartGame()
        {
            Result = ThrowDice();

            Console.WriteLine($"You threw {_numberOfDices} dice, your result -  {Result}");

            if (Result == 12)
            {
                FellOutTwelve?.Invoke();
            }
        }

        private int ThrowDice()
        {
            int result = 0;

            for (int i = 0; i < _dices.Length; i++)
            {
                _dices[i] = r.Next(1, 7);
                result += _dices[i];
            }

            return result;
        }
    }
}
