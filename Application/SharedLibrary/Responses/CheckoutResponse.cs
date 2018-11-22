using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class CheckoutResponse : Message<bool>
    {
        public CheckoutResponse(bool succ)
        {
            Payload = succ;
        }

        public CheckoutResponse() : this(false) { }

        public static new MessageType Type => MessageType.CheckoutResponse;
    }
}
