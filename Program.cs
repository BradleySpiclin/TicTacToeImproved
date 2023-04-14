namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain)
            {
                Game game = new Game();
                game.Play();
                Console.Write("Play again? (y/n) ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                playAgain = (input == 'y' || input == 'Y');
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}