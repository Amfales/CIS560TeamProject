using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class RetireBookResponse : Message<bool>
    {
        public RetireBookResponse(bool succ)
        {
            Payload = succ;
        }
        public RetireBookResponse() : this(false) { }
        public RetireBookResponse(Message<bool> m) : this(m.Payload) { }
        public static new MessageType Type => MessageType.RetireBookResponse;
    }
}
