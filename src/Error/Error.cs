using Excel.Error.Abstraction;
using System.Collections.Generic;

namespace src.Error
{
    public class Error : IError
    {
        public string Message { get; private set; }

        public Error(string message)
        {
            Message = message;
        }

        public string Write()
        {
            return Message;
        }
    }
}
