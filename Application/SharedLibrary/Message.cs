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
        public static new MessageType Type { get; }
        public new PType Payload { get; set; }

        public Message(PType p)
        {
            Payload = p;
        }
        public Message() { }
        

        public static Message<PType> UpgradeMessage(IMessage m)
        {
            if (m.Type != Type)
            {
                return null;
            }
            return new Message<PType>((PType)(m.Payload));
        }
    }

    public class IMessage
    {
        public MessageType Type { get; set; }
        public object Payload { get; private set; }
    }
}
