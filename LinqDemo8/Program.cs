using System.Collections;

namespace LinqDemo8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Extension method

            string str = "Hello";
            int a = 10;
            //a.Encrypt();
            str = str.ToLower();

            str = str.Encrypt();

            Program p = new Program();
            //p.Encrypt();

            //str = MyUtil.Encrypt(str);

            List<int> list = new List<int>();

            list.Where(x => true);


            //Enumerable
            //var result = list.A
        }
    }

    public static class Enumerable1
    {
        public static string Encrypt(this IEnumerable str)
        {
            return "@#$@#$WEFERT@#%@#$@#$%@%@#%@$%";
        }


    }
}