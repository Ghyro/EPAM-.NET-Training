using No5.Solution.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    /// <summary>
    /// Template Method (abstract class)
    /// </summary>
    public abstract class Converter
    {
        public string Convert(DocumentPart part)
        {
            return this.ConvertTo((dynamic)part); // Use only dynamic (type conversion)
        }

        protected abstract string ConvertTo(Hyperlink hyperlink);

        protected abstract string ConvertTo(PlainText plainText);

        protected abstract string ConvertTo(BoldText boldText);
    }
}
