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
        

        
        

        [JsonConstructor]
        public Book(int bookid, string bookquality, string name, Author author, string isbn, string genre, string publisher, int copyrightyear) : base(name,author,isbn,genre,publisher,copyrightyear)
        {
            BookID = bookid;
            BookQuality = bookquality;
        }
        

    }
}
