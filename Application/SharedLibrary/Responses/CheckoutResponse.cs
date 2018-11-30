using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class CheckoutResponse : Message<Checkout>
    {
        [JsonConstructor]
        public CheckoutResponse(bool succ, List<DueDateAssociation> date)
        {
            Payload = new Checkout(succ, date);
        }

        public CheckoutResponse(Message<Checkout> m)
        {
            Payload = new Checkout(m.Payload.Success, m.Payload.DueDate);
        }
        

        public new MessageType Type => MessageType.CheckoutResponse;
    }

    public class Checkout
    {
        public bool Success { get; }
        public List<DueDateAssociation> DueDate { get; }

        public Checkout(bool success, List<DueDateAssociation> duedate)
        {
            Success = success;
            DueDate = duedate;
        }
    }
}
