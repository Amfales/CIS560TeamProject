using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class CheckoutResponse : Message<Checkout>
    {
        public CheckoutResponse(bool succ, List<DueDateAssociation> date)
        {
            Payload = new Checkout(succ, date);
        }

        public CheckoutResponse(Message<Checkout> m)
        {
            Payload = new Checkout(m.Payload.Success, m.Payload.DueDate);
        }

        public CheckoutResponse() : this(false, null) { }

        public static new MessageType Type => MessageType.CheckoutResponse;
    }

    public class Checkout
    {
        public bool Success { get; }
        public List<DueDateAssociation> DueDate { get; }

        public Checkout(bool succ, List<DueDateAssociation> date)
        {
            Success = succ;
            DueDate = date;
        }
    }
}
