namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // customer 1
            Account acc1 = new Account();
            acc1.alert += Communication.Alert.SendEmail; // Subscribe 
            acc1.alert += Communication.Alert.SendSMS;
            acc1.alert -= Communication.Alert.SendEmail; //Unsubscribe

            acc1.alert += Communication.Alert.SendWhatsApp;

            //acc1.Subscribe(Communication.Alert.SendSMS);


            //acc1.alert("Deposited $9999999999999999999");

            acc1.Deposit(1000);
            Console.WriteLine(acc1.Balance);
            //acc1.Withdraw(500);
            //Console.WriteLine(acc1.Balance);
        }
    }


    // declare the delegate
    public delegate void AlertDelete(string msg);
    class Account  // SRP - OCP
    {
        public int Balance { get; set; }
        // instantiation
        public event AlertDelete alert;

        //public void Subscribe(AlertDelete alert)
        //{
        //    this.alert += alert;
        //}

        //public void Unsubscribe(AlertDelete alert)
        //{
        //    this.alert -= alert;
        //}

        public void Deposit(int amount)
        {
            Balance += amount;

            // invocation
            if (alert != null)
                alert($"Deposited {amount}");
            //Communication.Alert.SendEmail($"Deposited {amount}");
            //Communication.Alert.SendSMS($"Deposited {amount}");
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;

            //Communication.Alert.SendEmail($"Withdraw {amount}");
            //Communication.Alert.SendSMS($"Withdraw {amount}");
            if (alert != null)
                alert($"Withdraw {amount}");
        }


    }
}
namespace Communication
{
    class Alert
    {
        public static void SendEmail(string msg)
        {
            //SmtpClient smtpClient = new SmtpClient();
            //MailMessage msg = new MailMessage();
            //smtpClient.Send(msg);
            Console.WriteLine($"Email : {msg}");
        }

        public static void SendSMS(string msg)
        {
            Console.WriteLine($"SMS : {msg}");
        }

        public static void SendWhatsApp(string msg)
        {
            Console.WriteLine($"Whats App : {msg}");
        }
    }
}