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
            RouletteGame roulette = new RouletteGame();

            Player1 player1 = new Player1(roulette, "Kirill", "Korzun", 1);
            Player2 player2 = new Player2(roulette, "Oleg", "Olegich", 12);

            roulette.SimulateGame();

            Console.ReadLine();
        }
    }
}
