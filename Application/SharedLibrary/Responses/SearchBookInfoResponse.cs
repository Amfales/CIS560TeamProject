using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class SearchBookInfoResponse : Message<List<BookInfo>>
    {
        [JsonConstructor]
        public SearchBookInfoResponse(List<BookInfo> s)
        {
            Payload = s;
        }
        public SearchBookInfoResponse() : this(new List<BookInfo>()) { }
        public SearchBookInfoResponse(Message<List<BookInfo>> m)
        {
            // Might need to find a better way to do this.
            Payload = m.Payload;
        }

        public new MessageType Type => MessageType.SearchBookInfoResponse;
    }


    public class CompositeBookInfo : IEnumerable<BookInfo>
    {
        protected SortedSet<BookInfo> _books;
        public CompositeBookInfo(SortedSet<BookInfo> l)
        {
            _books = l;
        }
        public IEnumerator<BookInfo> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
