using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class GetBookRequest : Message<int> 
    {
        public GetBookRequest(int b)
        {
            Payload = b;
        }

        public GetBookRequest() : this(-1) { }

        public static new MessageType Type => MessageType.GetBookRequest;
    }
}
