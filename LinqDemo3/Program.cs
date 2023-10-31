namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 23, 45, 2, 45, 56, 78, 67, 45, 34 };

            // get all evens, sort and display
            // select n from numbers where n mod 2 = 0 order by n desc

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}