using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class GetBookResponse : Message<Book>
    {
        [JsonConstructor]
        public GetBookResponse(Book b)
        {
            Payload = b;
        }

        public GetBookResponse() : this(new Book()) { }

        public GetBookResponse(Message<Book> m) { Payload = m.Payload; }

        public new MessageType Type => MessageType.GetBookResponse;
    }
}
