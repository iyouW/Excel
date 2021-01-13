using Excel.Message.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Message
{
    public class Message : IMessage
    {
        public string Content { get; private set; }

        public Message(string content)
        {
            Content = content;
        }

        public string Write()
        {
            return Content;
        }
    }
}
