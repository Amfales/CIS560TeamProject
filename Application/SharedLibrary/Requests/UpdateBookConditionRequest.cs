using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class UpdateBookConditionRequest : Message<UpdateCondition>
    {
        [JsonConstructor]
        public UpdateBookConditionRequest(int b, string c, string e)
        {
            Payload = new UpdateCondition(b, c, e);
        }
        public UpdateBookConditionRequest() : this(-1,"","") { }
        public UpdateBookConditionRequest(Message<UpdateCondition> m)
        {
            Payload = new UpdateCondition(m.Payload.BookID, m.Payload.Condition,
                m.Payload.Email);
        }
        public new MessageType Type => MessageType.UpdateBookConditionRequest;

    }

    public class UpdateCondition
    {
        public int BookID { get; }
        public string Condition { get; }
        public string Email { get; }
        public UpdateCondition(int bookid, string condition, string email)
        {
            BookID = bookid;
            Condition = condition;
            Email = email;
        }
    }
}
