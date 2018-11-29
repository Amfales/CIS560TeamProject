using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class ResetPasswordResponse : Message<bool>
    {
        [JsonConstructor]
        public ResetPasswordResponse(bool succ)
        {
            Payload = succ;
        }
        public ResetPasswordResponse() : this(false) { }
        public ResetPasswordResponse(Message<bool> m): this(m.Payload) { }
        public static new MessageType Type => MessageType.ResetPasswordResponse;
    }
}
