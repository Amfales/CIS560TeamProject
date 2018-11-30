using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        [JsonConstructor]
        public BookInfo(string name, Author author, string isbn, string genre, string publisher, int copyrightyear)
        {
            Name = name;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Publisher = publisher;
            CopyrightYear = copyrightyear;
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
