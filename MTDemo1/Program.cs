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

        }

        static void M1()
        {
            //Console.WriteLine($"M1 method in thread id :{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            //for (int i = 1; i < 1000; i++)
            //{
            //    Console.WriteLine($"M1 : {i}");
            //}

        }
        static void M2()
        {
            //Console.WriteLine($"M2 method in thread id :{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            //for (int i = 1; i < 1000; i++)
            //{
            //    Console.WriteLine($"M2 : {i}");
            //}
        }
    }
}