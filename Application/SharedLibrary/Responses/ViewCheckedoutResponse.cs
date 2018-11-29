using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class ViewCheckedoutResponse : Message<CheckedoutBooks>
    {
        [JsonConstructor]
        public ViewCheckedoutResponse(List<CheckedoutBook> l)
        {
            Payload = new CheckedoutBooks(l);
        }
        public ViewCheckedoutResponse() : this(new List<CheckedoutBook>()) { }
        public ViewCheckedoutResponse(Message<CheckedoutBooks> m)
        {
            Payload = new CheckedoutBooks(new List<CheckedoutBook>(m.Payload));
        }


        public static new MessageType Type => MessageType.ViewCheckedoutResponse;
    }


    public class CheckedoutBooks : IEnumerable<CheckedoutBook>
    {
        private List<CheckedoutBook> _books;
        public CheckedoutBooks(List<CheckedoutBook> l)
        {
            _books = l;
        }

        public IEnumerator<CheckedoutBook> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
