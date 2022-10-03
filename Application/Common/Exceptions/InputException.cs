using System.Globalization;

namespace Application.Common.Exceptions
{
    public class InputException : Exception
    {
        public InputException() 
            : base()
        {
        }

        public InputException(string message) 
            : base(message) 
        { 
        }

        public InputException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
