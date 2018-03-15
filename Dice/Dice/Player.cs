using System;
using System.Threading;

namespace Dice
{
    public class Player
    {
        public const int BiggestFigureOnDice = 6;

        private int _numberAttempts = 0;
        private int _numberOfDice;
        private Game _game;

        public string Name { get; private set; }

        public Player(string name, uint numberOfDice)
        {
            Name = name;

            _numberOfDice = (int)numberOfDice;
            _game = new Game(numberOfDice);
            _game.FellOutTwelve += ReactionToTheGame;
        }
        
        public void ReactionToTheGame(object sender, EventArgs e)
        {
            Game game = sender as Game;
            Console.WriteLine($"Your result is {game.Result}");

            if (game.Result == BiggestFigureOnDice * _numberOfDice)
            {
                Console.WriteLine($" ");
                Console.WriteLine($"{Name} - You win!!!");
                Console.WriteLine($"Number of attempts is {_numberAttempts}");
                Console.WriteLine($"Your result is {game.Result}");
                _numberAttempts = 0;
                Console.WriteLine($"Press any key...");
                Console.WriteLine($" ");
                Console.ReadKey();
            }
        }

        public void StartGame()
        {
            while (true)
            {
                _numberAttempts++;
                _game.StartGame();
                Thread.Sleep(300);
            }
        }
    }
}