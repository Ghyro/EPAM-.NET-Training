using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using No1.Solution.Checkers;
using No1.Solution.Interfaces;
using No1.Solution.Service;

namespace No1.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<IPassword> check = new List<IPassword>();

                // Add three checkers (empty, length, letter)
                check.Add(new CheckerEmpty());
                check.Add(new CheckerLength());
                check.Add(new CheckerLetter());

                IRepository repository = new SQLRepository(check);

                System.Console.WriteLine("Enter your password...");

                string password = System.Console.ReadLine();

                var res = repository.Create(password);

                System.Console.WriteLine("Results...");

                //Errors
                foreach (var item in res)
                {
                    System.Console.WriteLine($"Return bool: {item.Item1} ----- Message:{item.Item2}");
                }
            }          
        }
    }
}
