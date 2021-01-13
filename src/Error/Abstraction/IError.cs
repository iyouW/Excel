using Excel.Message.Abstraction;
using System.Collections.Generic;

namespace Excel.Error.Abstraction
{
    public interface IError : IMessage
    {
        string Category {get;}
        IMessage Message { get; }
    }
}