using System.Collections.Generic;

namespace Excel.Error.Abstraction
{
    public interface IError
    {
        string Message { get; }
        List<IError> InnerErrors { get; }
        IEnumerable<string> Write();
    }
}