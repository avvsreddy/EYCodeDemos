namespace MTDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M1();
        }

        static void M1()
        {
            int coreCount = Environment.ProcessorCount;
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = coreCount / 2;

            Parallel.For(1, 1001, options, i =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
        }


    }
}