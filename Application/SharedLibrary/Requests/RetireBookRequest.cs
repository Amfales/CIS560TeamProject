using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class RetireBookRequest : Message<Retire>
    {
        [JsonConstructor]
        public RetireBookRequest(int b, string e)
        {
            Payload = new Retire(b, e);
        }
        public RetireBookRequest() : this(-1,"") { }
        public RetireBookRequest(Message<Retire> m)
        {
            Payload = new Retire(m.Payload.BookId, m.Payload.Email);
        }
        public static new MessageType Type => MessageType.RetireBookRequest;
    }

    public class Retire
    {
        public int BookId { get; }
        public string Email { get; }
        public Retire(int b, string e)
        {
            BookId = b;
            Email = e;
        }
    }
}
