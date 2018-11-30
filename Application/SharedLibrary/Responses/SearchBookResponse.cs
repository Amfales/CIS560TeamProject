using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class SearchBookResponse : Message<List<Book>>
    {
        [JsonConstructor]
        public SearchBookResponse(List<Book> l)
        {
            Payload = l;
        }
        public SearchBookResponse() : this(new List<Book>()) { }


        public new MessageType Type => MessageType.SearchBookResponse;
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
