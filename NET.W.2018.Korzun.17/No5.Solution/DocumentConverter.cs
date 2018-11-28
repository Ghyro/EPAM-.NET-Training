using No5.Solution.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    /// <summary>
    /// Use extension methods
    /// </summary>
    public static class DocumentConverter
    {
        public static string ToHtml(this Document document)
        {
            return Convert(document, new HTMLConverter());
        }

        public static string ToLaTex(this Document document)
        {
            return Convert(document, new LaTeXConverter());
        }

        public static string ToPlainText(this Document document)
        {
            return Convert(document, new PlainTextConverter());
        }

        private static string Convert(Document document, Converter converter)
        {
            string result = null;

            // Get result
            foreach (DocumentPart part in document.parts)
            {
                result = result + converter.Convert(part) + "\n";
            }

            return result;
        }
    }
}
