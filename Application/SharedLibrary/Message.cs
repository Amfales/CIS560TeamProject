using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary
{
    public class Message<PType> : IMessage
        //where PType : class
    {
        public new MessageType Type { get; private set; }
        public new PType Payload { get; set; }

        public Message(PType payload)
        {
            Payload = payload;
        }
        public Message() { }
    }

    public class IMessage
    {
        public MessageType Type { get; set; }
        public object Payload { get; private set; }

    }
}
