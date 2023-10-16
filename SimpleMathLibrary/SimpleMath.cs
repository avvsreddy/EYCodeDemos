namespace SimpleMathLibrary
{
    public class SimpleMath
    {
        public static int FindMax(int fno, int sno) // BL - SRP
        {
            int max;

            if (fno > sno)
                max = fno;
            else
                max = sno;

            return max;

        }
    }
}
