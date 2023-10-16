namespace FristConsoleApp
{
    internal class Program // UI
    {
        static void Main(string[] args)  // UI // SRP
        {
            // Accept two numbers and find the max number then disply

            // step 1: declare three int varialble
            int fno, sno, max;

            // step 2: accept two int numbers into variables
            Console.Write("Enter First Number: ");
            fno = int.Parse(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            sno = int.Parse(Console.ReadLine());

            // step 3: find the max
            max = SimpleMathLibrary.SimpleMath.FindMax(fno, sno);

            // step 4: display the result
            Console.WriteLine($"The maximum of {fno} and {sno} is {max}");
            //Console.WriteLine("The maximum of " + fno + " and " + sno + " is " + max);
            //Console.WriteLine("The maximum of {0} and {1} is {2}", fno, sno, max);


        }


    }
}

