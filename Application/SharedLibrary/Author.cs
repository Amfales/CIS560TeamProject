using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary
{
    public class Author
    {
        [JsonConstructor]
        public Author(string f, string l)
        {
            FirstName = f;
            LastName = l;
        }
        public Author() : this("", "") { }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
