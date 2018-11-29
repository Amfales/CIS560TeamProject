using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class AddBookRequest : Message<AddBook>
    {
        public AddBookRequest(string e, Book b)
        {
            Payload = new AddBook(e, b);
        }
        public AddBookRequest() : this("", new Book()) { }
        public AddBookRequest(Message<AddBook> m)
        {
            Payload = new AddBook(m.Payload.Email, m.Payload.Book);
        }
        public static new MessageType Type => MessageType.AddBookRequest;
    }

    public class AddBook
    {
        public string Email { get; }
        public Book Book { get; }
        
        public AddBook(string e, Book b)
        {
            Email = e;
            Book = b;
        }
    }
}
