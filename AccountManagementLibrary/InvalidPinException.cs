namespace AccountManagementLibrary
{
    public class InvalidPinException : ApplicationException
    {
        public InvalidPinException(string msg) : base(msg)
        {

        }
    }
}
