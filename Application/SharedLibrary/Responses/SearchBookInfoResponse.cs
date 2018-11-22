using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class SearchBookInfoResponse : Message<CompositeBookInfo>
    {
        public SearchBookInfoResponse(SortedSet<BookInfo> s)
        {
            Payload = new CompositeBookInfo(s);
        }
        public SearchBookInfoResponse() : this(new SortedSet<BookInfo>()) { }
        public SearchBookInfoResponse(Message<CompositeBookInfo> m)
        {
            // Might need to find a better way to do this.
            Payload = new CompositeBookInfo(new SortedSet<BookInfo>(m.Payload));
        }

        public static new MessageType Type => MessageType.SearchBookInfoResponse;
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
