using Excel.Error.Abstraction;
using System.Collections.Generic;

namespace src.Error
{
    public class Error : IError
    {
        public string Message { get; private set; }

        public List<IError> InnerErrors { get; private set; }

        public Error(string message)
            : this(message, new List<IError>())
        { 
        }

        public Error(string message, List<IError> innerErrors)
        {
            Message = message;
            InnerErrors = innerErrors;
        }

        public IEnumerable<string> Write()
        {
            throw new System.NotImplementedException();
        }
    }
}
