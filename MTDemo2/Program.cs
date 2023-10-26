namespace MTDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);

            ParameterizedThreadStart pts1 = new ParameterizedThreadStart(M2);
            Thread t2 = new Thread(M2);

            Task tt1 = new Task(M1);
            Task tt2 = new Task(() => { M2(100); });
            Task<int> tt3 = new Task<int>(M3);
            tt3.Start();
            //sdfdfsdf
            //sdfdfsdf
            //sdfsdfd
            int v = tt3.Result;
            //sdfsdfsd

            Task<int> tt4 = new Task<int>(() => { return M4(100); });
            tt4.Start();
            v = tt4.Result;
        }

        static void M1() { }
        static void M2(object i) { }
        static int M3() { return 100; }
        static int M4(int i) { return i; }


    }
}