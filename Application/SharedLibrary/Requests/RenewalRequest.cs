using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class RenewalRequest : Message<Renewal>
    {
        [JsonConstructor]
        public RenewalRequest(string e, List<int> ids)
        {
            Payload = new Renewal(e, ids);
        }
        public RenewalRequest() : this("",new List<int>()) { }
        public RenewalRequest(Message<Renewal> m) : this(m.Payload.Email, m.Payload.IDs) { }

        public new MessageType Type => MessageType.RenewalRequest;
    }


    public class Renewal
    {
        public string Email { get; }
        public List<int> IDs { get; }
        public Renewal(string email, List<int> ids)
        {
            Email = email;
            IDs = ids;
        }
    }
}
