using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class AddBookResponse : Message<bool>
    {
        public AddBookResponse(bool succ)
        {
            Payload = succ;
        }
        public AddBookResponse() : this(false) { }
        public AddBookResponse(Message<bool> m) : this(m.Payload) { }
        public static new MessageType Type => MessageType.AddBookResponse;
    }
}
