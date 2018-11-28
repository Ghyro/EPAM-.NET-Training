using No5.Solution.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<DocumentPart> parts = new List<DocumentPart>();

            parts.Add(new BoldText() { Text = "Hi, this is EPAM's HR" });
            parts.Add(new Hyperlink() { Text = "You have applied for .NET training", Url = "training.by" });
            parts.Add(new PlainText() { Text = "Can I ask you any questions?" });

            Document document = new Document(parts);

            System.Console.WriteLine(document.ToPlainText());

            System.Console.ReadKey();
        }
    }
}
