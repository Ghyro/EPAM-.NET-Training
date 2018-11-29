using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task.BLL.Interfaces;

namespace Task.BLL.BussinessModel
{
    public class XmlService : IXmlService
    {      
        /// <summary>
        /// Gets host name
        /// </summary>
        /// <param name="url">Input url</param>
        /// <returns>Host name</returns>
        public string GetHost(string url)
        {
            int start = url.IndexOf('/', 0) + 2;

            int end = url.IndexOf('/', start);

            string value = url.Substring(start, end - start);

            return value;
        }

        /// <summary>
        /// Gets sequence of segments
        /// </summary>
        /// <param name="url">Input url</param>
        /// <returns>Sequence of segments</returns>
        public IEnumerable<string> GetUri(string url)
        {
            List<string> result = new List<string>();

            int index = url.IndexOf("/", url.IndexOf('/', 0) + 2) + 1;

            while (index != -1)
            {
                int secondIndex = url.IndexOfAny(new char[] { '/', '?' }, index);
                result.Add(url.Substring(index, secondIndex - index));
                index = secondIndex + 1;
                if (url.IndexOfAny(new char[] { '/', '?' }, index) == -1)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get dictionary (value - key)
        /// </summary>
        /// <param name="url">input url</param>
        /// <returns>value - key</returns>
        public Dictionary<string, string> GetParam(string url)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            int indexQuestion = url.LastIndexOf('?');

            int indexCompare = -1;

            while (indexQuestion < url.Length && indexQuestion != -1)
            {
                int secondIndex = url.IndexOf("&", indexQuestion);

                secondIndex = secondIndex == -1 ? url.Length : secondIndex - 1;
                indexCompare = url.IndexOf('=', indexQuestion);

                string key = url.Substring(indexQuestion + 1, indexCompare - indexQuestion - 1);
                string value = url.Substring(indexCompare + 1, secondIndex - indexCompare - 1);

                result.Add(key, value);

                indexQuestion = secondIndex;
            }

            return result;
        }

        /// <summary>
        /// Validate url
        /// </summary>
        /// <param name="url">Input url</param>
        /// <returns>True if URL is valid</returns>
        public bool ValidDocument(string url)
        {
            const string HTTPS_PATTERN = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+";

            return Regex.IsMatch(url, HTTPS_PATTERN);
        }
    }
}
