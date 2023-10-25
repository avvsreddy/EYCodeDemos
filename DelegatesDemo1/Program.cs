namespace DelegatesDemo1
{

    //class MyDelegate : Delegate
    //{

    //}

    // Step 1: Delegate Declaration
    delegate void MyDelegate(string str);

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

            // 3. initialize a delegate
            // 4. invoke a delegate
            //d.Invoke("hello");
            d("Hello");
        }

        static void Greetings(string msg)
        {
            Console.WriteLine($"Greetings : {msg}");
        }
    }
}