using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class CheckedoutBook : Book
    {
        public DateTime DueDate { get; }

        public CheckedoutBook(Book b, DateTime d) : base(b)
        {
            DueDate = d;
        }

    }
}
