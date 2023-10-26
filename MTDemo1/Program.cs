using System.Diagnostics;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main method in thread id :{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Running in Seq...");
            Stopwatch sw = Stopwatch.StartNew();
            M1();
            M2();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // classic mt 
            Console.WriteLine("Running in Thread...");
            sw.Restart();
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            Thread t2 = new Thread(M2);
            t2.Start();
            t1.Join();
            t2.Join();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // TPL - Task
            Console.WriteLine("Running in TPL - Task");
            sw.Restart();
            Task tt1 = new Task(M1);
            tt1.Start();
            Task tt2 = new Task(M2);
            tt2.Start();
            tt1.Wait();
            tt2.Wait();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // TPL - Parallel
            sw = Stopwatch.StartNew();
            Console.WriteLine("Running in TPL - Parallel");
            Parallel.Invoke(M1, M2);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            Console.WriteLine("Running in TPL - Parallel For");
            Parallel.Invoke(M11, M22);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void M1()
        {
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(100);
            }
        }
        static void M2()
        {
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(100);
            }
        }

        static void M11()
        {
            //for (int i = 1; i < 100; i++)
            Parallel.For(1, 101, i =>
            {
                Thread.Sleep(100);
            });
        }
        static void M22()
        {
            //for (int i = 1; i < 100; i++)
            Parallel.For(1, 101, x =>
            {
                Thread.Sleep(100);
            });
        }
    }
}