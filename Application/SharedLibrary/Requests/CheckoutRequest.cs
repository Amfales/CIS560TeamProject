using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class CheckoutRequest : Message<Checkout>
    {
        [JsonConstructor]
        public CheckoutRequest(string e, List<int> l)
        {
            Payload = new Checkout(e, l);
        }

        public CheckoutRequest() : this("", new List<int>()) { }

        public CheckoutRequest(Message<Checkout> m)
        {
            Payload = new Checkout(m.Payload.Email, m.Payload.IDs);
        }

        public new MessageType Type => MessageType.CheckoutRequest;
    }

    public class Checkout
    {
        public List<int> IDs { get; }
        public string Email { get; }

        public Checkout(string email, List<int> ids)
        {
            Email = email;
            IDs = ids;
        }
    }
}
