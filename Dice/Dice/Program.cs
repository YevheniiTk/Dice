namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numberOfDice = 1;
            Player player = new Player("John", numberOfDice);
           
            player.StartGame();
        }
    }
}
