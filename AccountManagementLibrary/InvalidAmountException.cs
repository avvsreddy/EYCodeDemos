namespace AccountManagementLibrary
{
    public class InvalidAmountException : ApplicationException
    {
        public InvalidAmountException(string msg) : base(msg)
        {

        }
    }
}
