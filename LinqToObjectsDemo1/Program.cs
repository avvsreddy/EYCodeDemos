namespace LinqToObjectsDemo1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // LINQ to Objects Demo



            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // extract all even numbers into another array and display
            // by traditional approach - c/c++/java/????



            // table: numbers
            // column: number
            // SQL: select number from numbers where number mod 2 = 0;

            // var : local variable type inference
            // LINQ Expression

            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;




            //List<int> evens = new List<int>();

            //foreach (var number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        evens.Add(number);
            //    }
            //}

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }

        }
    }
}