using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class ReturnRequest : Message<List<int>>
    {
        public ReturnRequest(List<int> l)
        {
            Payload = l;
        }
        public ReturnRequest() : this(new List<int>()) { }
        public ReturnRequest(Message<List<int>> m) : this(m.Payload) { }

        public static new MessageType Type => MessageType.ReturnRequest;
    }
}
