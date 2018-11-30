using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class GetBookRequest : Message<int> 
    {
        [JsonConstructor]
        public GetBookRequest(int b)
        {
            Payload = b;
        }

        public GetBookRequest() : this(-1) { }

        public new MessageType Type => MessageType.GetBookRequest;
    }
}
