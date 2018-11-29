using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class RenewalResponse : Message<RenewalResponseData>
    {
        public RenewalResponse(bool succ, List<DueDateAssociation> l)
        {
            Payload = new RenewalResponseData(succ, l);
        }
        public RenewalResponse() : this(false, new List<DueDateAssociation>()) { }
        public RenewalResponse(Message<RenewalResponseData> m)
        {
            Payload = new RenewalResponseData(m.Payload.Success, m.Payload.DueDates);
        }


        public static new MessageType Type => MessageType.RenewalResponse;
    }

    public class RenewalResponseData
    {
        public bool Success { get; }
        public List<DueDateAssociation> DueDates { get; }
        public RenewalResponseData(bool succ, List<DueDateAssociation> dates)
        {
            Success = succ;
            DueDates = dates;
        }
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
