using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class ReturnRequest : Message<List<int>>
    {
        [JsonConstructor]
        public ReturnRequest(List<int> l)
        {
            Payload = l;
        }
        public ReturnRequest() : this(new List<int>()) { }
        public ReturnRequest(Message<List<int>> m) : this(m.Payload) { }

        public new MessageType Type => MessageType.ReturnRequest;
    }
}
