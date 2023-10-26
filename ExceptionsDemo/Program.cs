namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            // accept two ints and find the sum continuesly
            //sdfsdfsdf

            while (true)
            {
                try
                {
                    int a;
                    int b;
                    int sum;

                    Console.Write("Enter First Number :");
                    a = int.Parse(Console.ReadLine());

                    Console.Write("Enter Second Number: ");
                    b = int.Parse(Console.ReadLine());

                    sum = Calculator.FindSum(a, b);

                    Console.WriteLine($"The sum of {a} and {b} is {sum}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only numbers");
                }
                catch (NotEvenNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //catch (OverflowException ex)
                //{
                //    Console.WriteLine("Enter small numbers only");
                //}
                // catch all block
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


        }
    }


    /// <summary>
    /// This Calculator class can be used for finding sum
    /// </summary>
    class Calculator // BL
    {

        /// <summary>
        /// Finds sum of two even numbers
        /// </summary>
        /// <param name="a">first even number</param>
        /// <param name="b">second even number</param>
        /// <returns>the sum of two evens</returns>
        /// <exception cref="NotEvenNumberException"></exception>
        public static int FindSum(int a, int b)
        {
            if (a % 2 != 0 || b % 2 != 0) // not an even number
            {
                //Console.WriteLine("Provide only even numbers");
                //return "Provide only enven numbers";

                //throw new Exception("Provide only even numbers");
                throw new NotEvenNumberException("Provide only even numbers");

            }
            //else
            //{

            return a + b;
            //}
        }
    }

    class NotEvenNumberException : ApplicationException
    {
        public NotEvenNumberException(string msg) : base(msg)
        {

        }
    }
}