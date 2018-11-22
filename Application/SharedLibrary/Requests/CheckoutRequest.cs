using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class CheckoutRequest : Message<Checkout>
    {
        public CheckoutRequest(string e, List<int> l)
        {
            Payload = new Checkout(e, l);
        }

        public CheckoutRequest() : this("", new List<int>()) { }

        public static new MessageType Type => MessageType.CheckoutRequest;
    }

    public class Checkout
    {
        public List<int> IDs { get; }
        public string Email { get; }

        public Checkout(string e, List<int> ids)
        {
            Email = e;
            IDs = ids;
        }
        public Checkout() : this("",new List<int>()) { }
    }
}
