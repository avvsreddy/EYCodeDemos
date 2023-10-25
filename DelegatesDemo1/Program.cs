namespace DelegatesDemo1
{

    //class MyDelegate : Delegate
    //{

    //}

    // Step 1: Delegate Declaration
    delegate void MyDelegate(string str);
    delegate void MyDelegate2();

    internal class Program
    {
        static void Main(string[] args)
        {
            // Delegates Demo
            // Direct method call
            //DelegatesDemo1.Program.Greetings("Hello");
            // Indirect method call - delgates
            // 1. Declare a delegate
            // 2. instantiate a delete

            // Delegate d = new  Delegate ();
            MyDelegate d = new MyDelegate(Greetings);
            Program p = new Program();
            d += p.Hello; // subscribe
            d -= Greetings; // unsubscribe
            //d += Hi;

            MyDelegate2 d2 = new MyDelegate2(Hi);
            d2();
            // 3. initialize a delegate
            // 4. invoke a delegate
            //d.Invoke("hello");
            d("Ramesh");
        }

        static void Greetings(string msg)
        {
            Console.WriteLine($"Greetings : {msg}");
        }

        public void Hello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        public static void Hi()
        {
            Console.WriteLine("Hi");
        }
    }
}