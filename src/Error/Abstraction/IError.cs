using Excel.Message.Abstraction;
using System.Collections.Generic;

namespace Excel.Error.Abstraction
{
    public interface IError
    {
        string Category {get;}
        List<IMessage> Messages { get; }

        void AddMessage(IMessage message);
        void AddMessage(IList<IMessage> messages);
        void AddMessage(IEnumerable<IMessage> messages);
    }
}