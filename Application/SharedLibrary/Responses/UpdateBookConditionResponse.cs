using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class UpdateBookConditionResponse : Message<bool>
    {
        [JsonConstructor]
        public UpdateBookConditionResponse(bool succ)
        {
            Payload = succ;
        }
        public UpdateBookConditionResponse() : this(false) { }
        public UpdateBookConditionResponse(Message<bool> m) : this(m.Payload) { }
        public new MessageType Type => MessageType.UpdateBookConditionResponse;
    }
}
