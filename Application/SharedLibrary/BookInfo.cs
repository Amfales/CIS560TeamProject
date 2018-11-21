using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class BookInfo
    {
        public string Name { get; }
        public Author Author { get; }
        public string ISBN { get; }
        public string Genre { get; }
        public string Publisher { get; }
        public int CopyrightYear { get; }

        public BookInfo(string n, Author a, string i, string g, string p, int c)
        {
            Name = n;
            Author = a;
            ISBN = i;
            Genre = g;
            Publisher = p;
            CopyrightYear = c;
        }

        public BookInfo() : this("",new Author(),"","","",0) { }
        public BookInfo(BookInfo b)
        {
            Name = b.Name;
            Author = b.Author;
            ISBN = b.ISBN;
            Genre = b.Genre;
            Publisher = b.Publisher;
            CopyrightYear = b.CopyrightYear;
        }

        public class BookInfoComparer : IComparer<BookInfo>
        {
            public int Compare(BookInfo x, BookInfo y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
    }

    
}
