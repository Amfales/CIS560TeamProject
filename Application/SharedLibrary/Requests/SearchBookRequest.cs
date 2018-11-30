using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class SearchBookRequest : Message<SearchInfo>
    {
        public SearchBookRequest() : this("",new Author(),"","",true) { }
        [JsonConstructor]
        public SearchBookRequest(string n, Author a, string i, string g, bool b)
        {
            Payload = new SearchInfo(n, a, i, g, b);
        }

        public SearchBookRequest(Message<SearchInfo> m)
        {
            Payload = new SearchInfo(m.Payload.Name, m.Payload.Author, m.Payload.ISBN, m.Payload.Genre, m.Payload.BookInfoOnly);
        }

        public new MessageType Type => MessageType.SearchBookRequest;

    }


    public class SearchInfo
    {
        public string Name { get; }
        public Author Author { get; }
        public string ISBN { get; }
        public string Genre { get; }
        public bool BookInfoOnly { get; }

        public SearchInfo(string name, Author author, string isbn, string genre, bool bookinfoonly)
        {
            Name = name;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            BookInfoOnly = bookinfoonly;
        }
    }
}
