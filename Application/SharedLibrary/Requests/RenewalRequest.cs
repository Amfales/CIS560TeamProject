using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class RenewalRequest : Message<Renewal>
    {
        public RenewalRequest(string e, List<int> ids)
        {
            Payload = new Renewal(e, ids);
        }
        public RenewalRequest() : this("",new List<int>()) { }
        public RenewalRequest(Message<Renewal> m) : this(m.Payload.Email, m.Payload.IDs) { }

        public static new MessageType Type => MessageType.RenewalRequest;
    }


    public class Renewal
    {
        public string Email { get; }
        public List<int> IDs { get; }
        public Renewal(string e, List<int> ids)
        {
            Email = e;
            IDs = ids;
        }
    }
}
