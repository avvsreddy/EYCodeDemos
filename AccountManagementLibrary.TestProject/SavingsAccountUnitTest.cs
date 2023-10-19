namespace AccountManagementLibrary.TestProject
{
    [TestClass]
    public class SavingsAccountUnitTest
    {
        [TestMethod]
        public void DepositTest_WithValidInput_ShouldIncreaseBalance()
        {
            // no cond
            // no iter
            // no exp

            // AAA
            // A - Arrange
            SavingsAccount target = new SavingsAccount();
            target.AccNo = 1;
            target.Pin = 123;
            target.Balance = 1000;

            int depositAmt = 1000;
            int expectedBalance = 2000;
            int pin = 123;

            // A - Act

            target.Deposit(pin, depositAmt);

            // A - Assert

            //if(target.Balance == 2000)

            Assert.AreEqual(expectedBalance, target.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPinException))]
        public void DepositTest_WithInvlaidPin_ShouldThrowsExp()
        {
            SavingsAccount target = new SavingsAccount { AccNo = 1, Balance = 1000, Pin = 123 };
            target.Deposit(111, 1000);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAmountException))]
        public void DepositTest_WithSmallDepositAmount_ShouldThrowsExp()
        {
            SavingsAccount target = new SavingsAccount { AccNo = 1, Balance = 1000, Pin = 123 };
            target.Deposit(123, 500);
        }
    }
}