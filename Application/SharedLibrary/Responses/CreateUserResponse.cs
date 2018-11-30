using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class CreateUserResponse : Message<bool>
    {
        [JsonConstructor]
        public CreateUserResponse(bool success)
        {
            Payload = success;
        }
        public CreateUserResponse() : this(false) { }

        public new MessageType Type => MessageType.CreateUserResponse;
    }
}
