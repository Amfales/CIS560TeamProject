using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class RenewalResponse : Message<CheckedoutBooks>
    {
        public RenewalResponse(List<CheckedoutBook> l)
        {
            Payload = new CheckedoutBooks(l);
        }
        public RenewalResponse() : this(new List<CheckedoutBook>()) { }
        public RenewalResponse(Message<CheckedoutBooks> m)
        {
            Payload = new CheckedoutBooks(new List<CheckedoutBook>(m.Payload));
        }


        public static new MessageType Type => MessageType.RenewalResponse;
    }

    // CheckedoutBooks class is inside of ViewCheckedoutResponse.cs





}
