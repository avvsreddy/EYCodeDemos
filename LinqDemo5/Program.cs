using System.Xml.Linq;

namespace LinqDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };

            // load xml doc into mem
            XDocument xml = XDocument.Load("XMLFile1.xml");

            // get all short words = 3 or less char

            //var shortWords = from w in words
            //                 where w.Length <= 3
            //                 select w;

            var shortWords = from w in xml.Descendants("word")
                             where w.Value.Length <= 3
                             select w.Value;

            foreach (var item in shortWords)
            {
                Console.WriteLine(item);
            }

            // load xml doc

        }
    }
}