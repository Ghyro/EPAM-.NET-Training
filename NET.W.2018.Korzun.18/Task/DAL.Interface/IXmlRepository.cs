using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task.DAL.Interfaces
{
    /// <summary>
    /// Repository
    /// </summary>
    public interface IXmlRepository
    {
        /// <summary>
        /// Save document
        /// </summary>
        /// <param name="xDocument">Input document</param>
        void Save(XDocument xDocument);
    }
}
