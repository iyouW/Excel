using Excel.Error.Abstraction;
using Excel.Message.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Error
{
    public class Error : IError
    {
        public string Category { get; private set; }

        public List<IMessage> Messages { get; private set; }

        public Error(string category)
            :this(category, new List<IMessage>())
        {
        }

        public Error(string category, List<IMessage> messages)
        {
            Category = category;
            Messages = messages;
        }

        public string Write()
        {
            var message = string.Join(";\n", Messages);
        }

        public void AddMessage(IMessage message)
        {
            Messages.Add(message);
        }

        public void AddMessage(IList<IMessage> messages)
        {
            Messages.AddRange(messages);
        }

        public void AddMessage(IEnumerable<IMessage> messages)
        {
            Messages.AddRange(messages);
        }
    }
}
