using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class SearchBookResponse : Message<CompositeBook>
    {
        [JsonConstructor]
        public SearchBookResponse(List<Book> l)
        {
            Payload = new CompositeBook(l);
        }
        public SearchBookResponse() : this(new List<Book>()) { }
        public SearchBookResponse(Message<CompositeBook> m)
        {
            // Might need to find a better way to do this.
            Payload = new CompositeBook(new List<Book>(m.Payload));
        }

        public static new MessageType Type => MessageType.SearchBookResponse;
    }


    public class CompositeBook : IEnumerable<Book>
    {
        protected List<Book> _books;
        public CompositeBook(List<Book> l)
        {
            _books = l;
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return _books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
