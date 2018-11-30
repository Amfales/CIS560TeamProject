using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class AddBookResponse : Message<bool>
    {
        [JsonConstructor]
        public AddBookResponse(bool succ)
        {
            Payload = succ;
        }
        public AddBookResponse() : this(false) { }
        public AddBookResponse(Message<bool> m) : this(m.Payload) { }
        public new MessageType Type => MessageType.AddBookResponse;
    }
}
