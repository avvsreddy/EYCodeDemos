using System.Xml.Linq;

namespace LinqDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load xml doc
            XDocument books = XDocument.Load("XMLFile1.xml");
            // get all book titles

            //var titles = from t in books.Descendants("title")
            //             select t.Value;


            // get all book titles whos price is <= 5
            var titles = from book in books.Descendants("book")
                         where double.Parse(book.Element("price").Value) <= 5.0
                         select book.Element("title").Value;

            // get total cost of all books
            // sql : select sum(price) from books

            var totalCost = (from price in books.Descendants("price")
                             select double.Parse(price.Value)).Sum();

            //Console.WriteLine(totalCost);
            //foreach (var item in titles)
            //{
            //    Console.WriteLine(item);
            //}

            // get all book title and author then display
            // sql: select title, author from books

            var titleAuthors = from b in books.Descendants("book")
                               select new
                               {
                                   Title = b.Element("title").Value,
                                   Author = b.Element("author").Value
                               };

            var titlePrice = from b in books.Descendants("book")
                             select new
                             {
                                 Title = b.Element("title").Value,
                                 Price = double.Parse(b.Element("price").Value)
                             };


            foreach (var item in titleAuthors)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Author);
            }
        }
    }

    //class TitleAuthor
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}

    //class TitleCost
    //{
    //    public string Title { get; set; }
    //    public Double Price { get; set; }
    //}
}