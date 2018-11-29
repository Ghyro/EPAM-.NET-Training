using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.Interfaces
{
    /// <summary>
    /// Basic convert methods for XML
    /// </summary>
    public interface IXmlService
    {
        /// <summary>
        /// Get host by string
        /// </summary>
        /// <param name="url">Input string</param>
        /// <returns>Host URL</returns>
        string GetHost(string url);

        /// <summary>
        /// Create uri for segments xml
        /// </summary>
        /// <param name="url">Input string</param>
        /// <returns>Segments</returns>
        IEnumerable<string> GetUri(string url);

        /// <summary>
        /// Get values as value - key
        /// </summary>
        /// <param name="url">Input string</param>
        /// <returns>Value - key</returns>
        Dictionary<string, string> GetParam(string url);        

        /// <summary>
        /// Validation
        /// </summary>
        /// <param name="url">Input string</param>
        /// <returns>true if string is validate</returns>
        bool ValidDocument(string url);
    }
}
