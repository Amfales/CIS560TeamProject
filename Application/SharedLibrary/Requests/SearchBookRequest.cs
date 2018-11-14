using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class SearchBookRequest : Message<SearchInfo>
    {
        public SearchBookRequest() : this("","","","",true) { }
        public SearchBookRequest(string n, string a, string i, string g, bool b)
        {
            Payload = new SearchInfo(n, a, i, g, b);
        }

        public SearchBookRequest(Message<SearchInfo> m)
        {
            Payload = new SearchInfo(m.Payload.Name, m.Payload.Author, m.Payload.ISBN, m.Payload.Genre, m.Payload.BookInfoOnly);
        }

        public static new MessageType Type => MessageType.SearchBookRequest;

    }


    public class SearchInfo
    {
        public string Name { get; }
        public string Author { get; }
        public string ISBN { get; }
        public string Genre { get; }
        public bool BookInfoOnly { get; }

        public SearchInfo(string n, string a, string i, string g, bool b)
        {
            Name = n;
            Author = a;
            ISBN = i;
            Genre = g;
            BookInfoOnly = b;
        }
    }
}
