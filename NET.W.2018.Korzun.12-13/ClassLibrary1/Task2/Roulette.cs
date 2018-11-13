using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2
{
    /// <summary>
    /// Class <see cref="RouletteEventArgs">consist two values for storage <see cref="Message">
    /// and <see cref="Number"/>/></see>/>
    /// </summary>
    public class RouletteEventArgs : EventArgs
    {      
        public RouletteEventArgs(string message, int number)
        {
            this.Message = message;
            this.Number = number;
        }

        public string Message { get; }

        public int Number { get; }
    }

    /// <summary>
    /// The implementation of the simulation game Roulette
    /// </summary>
    public class Roulette
    {   
        Random random = new Random();

        public delegate void RouletteStateHandler(object sender, RouletteEventArgs e);

        public event RouletteStateHandler Win;

        public event RouletteStateHandler Lose;

        public void Game(int number)
        {
            if (number > 36 || number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (ReferenceEquals(number, null))
            {
                throw new ArgumentNullException(nameof(number));
            }

            int result = random.Next(0, 36);

            Console.WriteLine("Roulette rotates...");
            System.Threading.Thread.Sleep(1500);

            if (result == number)
            {
                Win?.Invoke(this, new RouletteEventArgs($"You are winner!!! Dropped number: {result}", number));
            }
            else
            {
                Lose?.Invoke(this, new RouletteEventArgs($"You are loser!!! Dropped number: {result}", number));
            }
        }        
    }
}
