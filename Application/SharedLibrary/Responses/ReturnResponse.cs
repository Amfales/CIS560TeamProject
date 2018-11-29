using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class ReturnResponse : Message<bool>
    {
        public ReturnResponse(bool succ)
        {
            Payload = succ;
        }
        public ReturnResponse() : this(false) { }
        public ReturnResponse(Message<bool> m) : this(m.Payload) { }
        public static new MessageType Type => MessageType.ReturnResponse;
    }
}
