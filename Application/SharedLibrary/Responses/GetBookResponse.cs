using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class GetBookResponse : Message<BookInfo>
    {
        [JsonConstructor]
        public GetBookResponse(BookInfo b)
        {
            Payload = b;
        }

        public GetBookResponse() : this(new BookInfo()) { }

        public new MessageType Type => MessageType.GetBookResponse;
    }
}
