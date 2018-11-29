using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.Interfaces
{
    /// <summary>
    /// Load text file
    /// </summary>
    public interface IFileSource
    {
        /// <summary>
        /// Load text file and write to list
        /// </summary>
        /// <returns>outputList</returns>
        IEnumerable<string> GetRows();
    }
}
