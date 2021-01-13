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

        public IMessage Message { get; private set; }

        public Error(string category, IMessage message)
        {
            Category = category;
            Message = message;
        }

        public string Write()
        {
            return $"{Category}:{Message.Write()}";
        }
    }
}
