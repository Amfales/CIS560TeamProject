using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class RenewalResponse : Message<RenewalResponseData>
    {
        [JsonConstructor]
        public RenewalResponse(bool succ, List<DueDateAssociation> l)
        {
            Payload = new RenewalResponseData(succ, l);
        }
        public RenewalResponse() : this(false, new List<DueDateAssociation>()) { }
        public RenewalResponse(Message<RenewalResponseData> m)
        {
            Payload = new RenewalResponseData(m.Payload.Success, m.Payload.DueDates);
        }


        public new MessageType Type => MessageType.RenewalResponse;
    }

    public class RenewalResponseData
    {
        public bool Success { get; }
        public List<DueDateAssociation> DueDates { get; }
        public RenewalResponseData(bool success, List<DueDateAssociation> duedates)
        {
            Success = success;
            DueDates = duedates;
        }
    }

    public class DueDateAssociation
    {
        public int BookID { get; }
        public DateTime Date { get; }
        public DueDateAssociation(int bookid, DateTime date)
        {
            BookID = bookid;
            Date = date;
        }
    }




}
