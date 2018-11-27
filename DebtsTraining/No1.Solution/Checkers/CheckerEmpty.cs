using No1.Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Checkers
{
    /// <summary>
    /// Checking password for emptiness
    /// </summary>
    public class CheckerEmpty : IPassword
    {
        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException($"{nameof(password)} is null arg");
            }

            if (password == string.Empty)
            {
                return Tuple.Create(false, $"{password} is empty ");
            }

            return Tuple.Create(true, $"Password {password} is Ok. User was created");
        }
    }
}
