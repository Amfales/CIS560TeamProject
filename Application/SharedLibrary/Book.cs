using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary
{
    public class Book : BookInfo
    {
        public int BookID { get; }
        public string BookQuality { get; }
        private BookInfo _bookInfo;

        public Book() : this(-1, "") { }

        [JsonConstructor]
        public Book(int bookid, string bookquality) : base()
        {
            BookID = bookid;
            BookQuality = bookquality;
            _bookInfo = new BookInfo();
        }

        public Book(int bookid, string bookquality, BookInfo bi) : base(bi)
        {
            BookID = bookid;
            BookQuality = bookquality;
            _bookInfo = bi;
        }

        public Book(Book b) : this(b.BookID, b.BookQuality, b._bookInfo) { }

    }
}
