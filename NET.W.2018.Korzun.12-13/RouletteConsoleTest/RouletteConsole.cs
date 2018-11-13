using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Task2;

namespace RouletteConsoleTest
{
    class RouletteConsole
    {
        static void Main()
        {
            Roulette roulette = new Roulette();

            roulette.Win += WinMessage;
            roulette.Lose += LoseMessage;

            int k = 3;

            while (k >= 0)
            {
                Console.WriteLine("Enter your number for the game (number from 0 to 36)...");

                int number = Convert.ToInt32(Console.ReadLine());

                roulette.Game(number);

                Console.WriteLine($"Number of attempts: {k}");

                --k;
            }

            Console.WriteLine("Closing the program...");

            System.Threading.Thread.Sleep(2000);
        }

        private static void WinMessage(object sender, RouletteEventArgs e)
        {
            Console.Write(e.Message);
            Console.WriteLine($" Your number: {e.Number}");
        }

        private static void LoseMessage(object sender, RouletteEventArgs e)
        {
            Console.Write(e.Message);
            Console.WriteLine($" Your number: {e.Number}");
        }
    }
}
