using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tasks.Task2
{
    /// <summary>
    /// Definition of the type for storage of information,
    /// which recipients are set notice about event
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
    /// This class contain implementation of method <see cref="OnGame(RouletteEventArgs)"/>,
    /// which responsible for notice objects (about events).
    /// </summary>
    public class RouletteGame
    {
        Random randon = new Random();

        public event EventHandler<RouletteEventArgs> ResultOfGame;

        public void SimulateGame()
        {
            int number = randon.Next(0, 36);

            Console.WriteLine("Roulette rotates...");

            Thread.Sleep(1500);

            RouletteEventArgs e = new RouletteEventArgs($"Dropped number: {number}", number);

            OnGame(e);
        }       

        protected virtual void OnGame(RouletteEventArgs e)
        {
            ResultOfGame?.Invoke(this, e);
        }
    }

    /// <summary>
    /// The abstaract class, which describe all players
    /// </summary>
    public abstract class Player
    {
        public Player(string name, string surname, int bet)
        {
            this.Name = name;
            this.Surname = surname;
            this.Bet = bet;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Bet { get; set; }

        public abstract void Result(object sender, RouletteEventArgs e);
    }

    /// <summary>
    /// The first player
    /// </summary>
    public class Player1 : Player
    {
        public Player1(RouletteGame roulette, string name, string surname, int bet) : base(name, surname, bet)
        {
            roulette.ResultOfGame += Result;
        }

        public override void Result(object sender, RouletteEventArgs e)
        {
            Console.WriteLine($"Dropped number: {e.Number}");

            Console.WriteLine($"{Name} has dropped: {Bet}");

            if (this.Bet == e.Number)
            {
                Console.WriteLine($"Player {Name} has won!");
            }
        }

        public void Unregister(RouletteGame roulette)
        {
            roulette.ResultOfGame -= Result;
        }
    }

    /// <summary>
    /// The second player
    /// </summary>
    public class Player2 : Player
    {
        public Player2(RouletteGame roulette, string name, string surname, int bet) : base(name, surname, bet)
        {
            roulette.ResultOfGame += Result;
        }

        public override void Result(object sender, RouletteEventArgs e)
        {
            Console.WriteLine($"{Name} has dropped: {Bet}");

            if (this.Bet == e.Number)
            {
                Console.WriteLine($"Player {Name} has won!");
            }
        }

        public void Unregister(RouletteGame roulette)
        {
            roulette.ResultOfGame -= Result;
        }
    }
}
