using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class RenewalResponse : Message<List<DueDateAssociation>>
    {
        public RenewalResponse(List<DueDateAssociation> l)
        {
            Payload = l;
        }
        public RenewalResponse() : this(new List<DueDateAssociation>()) { }
        public RenewalResponse(Message<List<DueDateAssociation>> m)
        {
            Payload = new List<DueDateAssociation>(m.Payload);
        }


        public static new MessageType Type => MessageType.RenewalResponse;
    }

    public class DueDateAssociation
    {
        public int BookID { get; }
        public DateTime DueDate { get; }
        public DueDateAssociation(int id, DateTime d)
        {
            BookID = id;
            DueDate = d;
        }
    }




}
