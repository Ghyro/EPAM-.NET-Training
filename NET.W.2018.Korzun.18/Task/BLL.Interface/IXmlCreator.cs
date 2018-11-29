using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task.BLL.Interfaces
{
    /// <summary>
    /// Creator of XML document
    /// </summary>
    public interface IXmlCreator
    {
        /// <summary>
        /// Create some document
        /// </summary>
        /// <param name="uris">List of URL</param>
        /// <returns></returns>
        XDocument CreateXml(IEnumerable<string> uris);
    }
}
