﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class AddBookRequest : Message<AddBook>
    {
        [JsonConstructor]
        public AddBookRequest(string e, BookInfo b)
        {
            Payload = new AddBook(e, b);
        }
        public AddBookRequest() : this("", new BookInfo()) { }
        public AddBookRequest(Message<AddBook> m)
        {
            Payload = new AddBook(m.Payload.Email, m.Payload.Book);
        }
        public new MessageType Type => MessageType.AddBookRequest;
    }

    public class AddBook
    {
        public string Email { get; }
        public BookInfo Book { get; }
        
        public AddBook(string email, BookInfo book)
        {
            Email = email;
            Book = book;
        }
    }
}
