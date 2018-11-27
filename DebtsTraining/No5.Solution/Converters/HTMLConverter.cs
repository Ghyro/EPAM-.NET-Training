using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No5.Solution.Parts;

namespace No5.Solution.Converters
{
    /// <summary>
    /// Specific class of template method
    /// </summary>
    public class HTMLConverter : Converter
    {
        protected override string ConvertTo(Hyperlink hyperlink)
        {
            return "<a href=\"" + hyperlink.Url + "\">" + hyperlink.Text + "</a>";
        }

        protected override string ConvertTo(PlainText plainText)
        {
            return plainText.Text;
        }

        protected override string ConvertTo(BoldText boldText)
        {
            return "<b>" + boldText.Text + "</b>";
        }
    }
}
