namespace AccountManagementLibrary
{
    public class SavingsAccount
    {
        public int AccNo { get; set; }
        public int Pin { get; set; }
        public int Balance { get; set; }
        public void Deposit(int pin, int amount)
        {
            // pin must match otherwise throw exp

            if (pin != this.Pin)
                throw new InvalidPinException("Provided invalid pin");
            // min amount is 1000
            if (amount < 1000)
                throw new InvalidAmountException("Amount to deposit must be more that 1000");
            // balance should increase by deposit amt

            Balance += amount;

        }
    }
}
