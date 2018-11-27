using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Interfaces
{
    /// <summary>
    /// Interface which contains <see cref="Tuple{Boolean, String}"/> for checking password
    /// </summary>
    public interface IPassword
    {
        Tuple<bool, string> VerifyPassword(string password);
    }
}
