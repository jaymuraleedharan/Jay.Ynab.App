using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL
{
    public class YnabException : Exception
    {
        public ErrorData Error { get; private set; }

        public YnabException(ErrorData errorData) : base()
        {
            Error = errorData;
        }

        public YnabException(string message, ErrorData errorData) : base(message)
        {
            Error = errorData;
        }

        public YnabException(string message, Exception innerException, ErrorData errorData) : base(message, innerException)
        {
            Error = errorData;
        }

    }
}
