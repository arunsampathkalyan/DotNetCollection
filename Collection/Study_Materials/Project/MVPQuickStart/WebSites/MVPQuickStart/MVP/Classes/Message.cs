using System;
using Dashboard.Interfaces;

namespace Dashboard.Classes
{
    class Message : IMessage
    {
        private readonly string _type;
        private readonly string _text;

        public Message(string type, string text)
        {
            if (type == null)
            {
                throw new NullReferenceException("Type cannot be NULL");
            }
                
             if (text == null)
            {
                throw new NullReferenceException("Text cannot be NULL");
            }

            _type = type;
            _text = text;
        }

        string IMessage.MessageType()
        {
            return _text;
        }

        string IMessage.MessageText()
        {
            return _text;
        }
    }
}
