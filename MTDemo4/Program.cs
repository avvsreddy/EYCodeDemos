namespace MTDemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigData data = new BigData();
            //data.Fill();
            //data.Fill();
            Parallel.Invoke(data.Fill, data.Fill);
            Console.WriteLine(data.stack.Count);
        }
    }

    public class BigData
    {
        public Stack<int> stack = new Stack<int>();

        public void Fill()
        {
            for (int i = 1; i <= 10000000; i++)
            {
                stack.Push(i);
            }
        }
    }
}