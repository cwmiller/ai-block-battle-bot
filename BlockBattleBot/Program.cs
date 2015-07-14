using System;
using System.IO;

namespace BlockBattleBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(10240)));

            Game game = new Game();
            Brain brain = new Brain(game);
            Parser parser = new Parser(game, brain);

            string line = null;
            while ((line = Console.ReadLine()) != null) 
            {
                object response = parser.Parse(line);

                if (response != null)
                {
                    Console.WriteLine(response);
                }
            }
        }
    }
}
