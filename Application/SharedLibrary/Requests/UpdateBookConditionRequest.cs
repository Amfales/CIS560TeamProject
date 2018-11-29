using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class UpdateBookConditionRequest : Message<UpdateCondition>
    {
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
        public static new MessageType Type => MessageType.UpdateBookConditionRequest;

    }

    public class UpdateCondition
    {
        public int BookID { get; }
        public string Condition { get; }
        public string Email { get; }
        public UpdateCondition(int b, string c, string e)
        {
            BookID = b;
            Condition = c;
            Email = e;
        }
    }
}
