namespace DPDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BillingSystem billingSystem = new BillingSystem();
            billingSystem.GenerateBill();
        }
    }

    public class TaxCalcFactory
    {
        public ITaxCalculator CreateTaxCalculator()
        {
            return new APTaxCalculator();
        }
    }

    public class BillingSystem
    {
        // Base class/interface ref variable can hold derived class object

        public ITaxCalculator taxCalculator;// = new KATaxCalculator();
        public void GenerateBill()
        {
            // scann all the products
            // find the total amount
            double amt = 6700.60;
            // calc disc
            // calc offers
            // calc tax

            TaxCalcFactory taxCalcFactory = new TaxCalcFactory();
            taxCalculator = taxCalcFactory.CreateTaxCalculator();

            double tax = taxCalculator.CalculateTax(amt);
            // calc the total bill amt
            // print the bill
        }
    }

    public interface ITaxCalculator
    {
        double CalculateTax(double amt);
    }


    public class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            Console.WriteLine("KA tax calculator");
            int ct = 100;
            int st = 120;
            int es = 20;
            int et = 10;
            double tax = ct + st + es + et;
            return tax;
        }
    }

    public class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            Console.WriteLine("TN tax calculator");
            int ct = 100;
            int st = 130;
            int inf = 20;
            int abc = 10;
            double tax = ct + st + inf + abc;
            return tax;
        }
    }

    public class APTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amt)
        {
            Console.WriteLine("AP tax calculator");
            int ct = 100;
            int st = 130;
            int inf = 20;
            int abc = 10;
            double tax = ct + st + inf + abc;
            return tax;
        }
    }

}