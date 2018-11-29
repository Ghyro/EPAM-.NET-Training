using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task.DAL.Interfaces;

namespace Task.DAL.Repository
{
    public class XmlRepository : IXmlRepository
    {
        private string _path;

        /// <summary>
        /// Current xml document for save
        /// </summary>
        public XmlRepository() : this(@"D:\EPAM-.NET\EPAM-.NET-Training\NET.W.2018.Korzun.18\Tests\XmlResult.xml")
        {
        }

        public XmlRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(nameof(path));
            }

            this._path = path;
        }

        /// <summary>
        /// Save document
        /// </summary>
        /// <param name="xDocument">Input XML document</param>
        public void Save(XDocument xDocument)
        {
            xDocument.Save(_path);
        }
    }
}
