using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class ViewCheckedoutResponse : Message<List<CheckedoutBook>>
    {
        [JsonConstructor]
        public ViewCheckedoutResponse(List<CheckedoutBook> l)
        {
            Payload = l;
        }
        public ViewCheckedoutResponse() : this(new List<CheckedoutBook>()) { }


        public new MessageType Type => MessageType.ViewCheckedoutResponse;
    }
    
}
