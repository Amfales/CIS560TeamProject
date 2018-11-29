using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Book : BookInfo
    {
        public int BookID { get; }
        public string BookQuality { get; }
        private BookInfo _bookInfo;

        public Book() : this(-1, "") { }
        public Book(int b, string q) : base()
        {
            BookID = b;
            BookQuality = q;
            _bookInfo = new BookInfo();
        }

        public Book(int b, string q, BookInfo bi) : base(bi)
        {
            BookID = b;
            BookQuality = q;
            _bookInfo = bi;
        }

        public Book(Book b) : this(b.BookID, b.BookQuality, b._bookInfo) { }

    }
}
