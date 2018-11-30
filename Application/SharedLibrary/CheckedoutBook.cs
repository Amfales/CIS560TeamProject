using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary
{
    public class CheckedoutBook : Book
    {
        public DateTime DueDate { get; }

        [JsonConstructor]

        public CheckedoutBook(int bookid, string bookquality, string name, Author author, string isbn, string genre, string publisher, int copyrightyear, DateTime duedate)
            : base(bookid,bookquality,name,author,isbn,genre,publisher,copyrightyear)
        {
            DueDate = duedate;
        }

    }
}
