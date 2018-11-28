using No1.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Checkers
{
    /// <summary>
    /// Checking password letters
    /// </summary>
    public class CheckerLetter : IPassword
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            // check if password contains at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");
            }               

            // check if password contains at least one digit character 
            if (!password.Any(char.IsNumber))
            {
                return Tuple.Create(false, $"{password} hasn't digits");
            }

            return Tuple.Create(true, $"Password {password} is Ok. User was created");
        }
    }
}
