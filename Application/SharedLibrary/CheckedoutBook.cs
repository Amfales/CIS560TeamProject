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

        public CheckedoutBook(Book book, DateTime duedate) : base(book)
        {
            DueDate = duedate;
        }

    }
}
