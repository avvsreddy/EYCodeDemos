namespace LineDemo7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 14, 25, 3, 42, 5, 62, 7, 80, 9 };

            // get all evens in assendign order

            // sql: select number from numbers where number mod 2 = 0 order by number

            // linq expression
            var result1 = from n in numbers
                          where n % 2 == 0
                          orderby n descending
                          select n;

            // linq statement - extension methods, lamba

            Console.WriteLine("result 1");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }


            Func<int, bool> filter = new Func<int, bool>(IsEven);

            var result2 = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(i => i)
                .Select(x => x);

            Console.WriteLine("result 2");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

        }

        public static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}