using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    /// <summary>
    /// Create <see cref="List{DocumentPart}"/>
    /// </summary>
    public class Document
    {
        public readonly List<DocumentPart> parts; // IEnumerable<DocumentPart>

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException();
            }

            this.parts = new List<DocumentPart>(parts);
        }
    }
}
