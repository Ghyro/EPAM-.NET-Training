using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.Interfaces;

namespace Task.BLL.BussinessModel
{
    public class FileSource : IFileSource
    {
        private string _path;

        /// <summary>
        /// Current text file for pars
        /// </summary>
        public FileSource() : this(@"D:\EPAM-.NET\EPAM-.NET-Training\NET.W.2018.Korzun.18\Tests\example.txt")
        {
        }

        public FileSource(string path)
        {
            if (path == string.Empty)
            {
                throw new ArgumentException(nameof(path));
            }

            this._path = path;
        }

        /// <summary>
        /// Generates a list of addresses
        /// </summary>
        /// <returns>List of addresses</returns>
        public IEnumerable<string> GetRows()
        {
            List<string> outputList = new List<string>();

            using (TextReader textReader = new StreamReader(File.Open(_path, FileMode.Open)))
            {
                while (textReader.Peek() != -1)
                {
                    outputList.Add(textReader.ReadLine());
                }
            }

            return outputList;
        }
    }
}
