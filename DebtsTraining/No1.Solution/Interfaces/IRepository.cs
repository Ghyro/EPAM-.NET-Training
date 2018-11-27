using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Interfaces
{
    /// <summary>
    /// Contains one method <see cref="IEnumerable{Tuple}"/> for create password
    /// </summary>
    public interface IRepository
    {
        IEnumerable<Tuple<bool, string>> Create(string password);
    }
}
