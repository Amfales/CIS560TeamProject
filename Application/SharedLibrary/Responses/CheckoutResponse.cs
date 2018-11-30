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
        public CheckoutResponse(bool success, List<DueDateAssociation> date)
        {
            Payload = new Checkout(success, date);
        }

        public new MessageType Type => MessageType.CheckoutResponse;
    }

    public class Checkout
    {
        public bool Success { get; private set; }
        public List<DueDateAssociation> DueDate { get; private set; }

        public Checkout(bool success, List<DueDateAssociation> duedate)
        {
            Success = success;
            DueDate = duedate;
        }
    }
}
