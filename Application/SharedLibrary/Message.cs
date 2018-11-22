using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Message<PType> : IMessage
        //where PType : class
    {
        public static MessageType Type { get; }
        public PType Payload { get; protected set; }
        
        public Message(PType p)
        {
            Payload = p;
        }
        public Message() { }

        object IMessage.Payload => Payload;
        MessageType IMessage.Type => Type;

        public static Message<PType> UpgradeMessage(IMessage m)
        {
            if (m.Type != Type)
            {
                return null;
            }
            return new Message<PType>((PType)(m.Payload));
        }
    }

    public interface IMessage
    {
        MessageType Type { get; }
        object Payload { get; }
    }
}
