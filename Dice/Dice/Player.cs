using System;
using System.Threading;

namespace Dice
{
    public class Player
    {
        private int numberAttempts = 0;

        public string Name { get; private set; }

        public Player(string name, uint numberOfDices)
        {
            Name = name;

            Game game = new Game(numberOfDices);

            game.FellOutTwelve += () => Win();

            while (true)
            {
                numberAttempts++;
                game.StartGame();
                Thread.Sleep(300);
            }
        }

        public void Win()
        {
            Console.WriteLine($"{Name} - You win!!!");
            Console.WriteLine($"Number of attempts is {numberAttempts}");
            numberAttempts = 0;
            Console.WriteLine($"Press any key...");
            Console.ReadKey();
        }
    }
}
