using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class ViewCheckedoutRequest : Message<User>
    {
        [JsonConstructor]
        public ViewCheckedoutRequest(string e)
        {
            Payload = new User(e);
        }
        public ViewCheckedoutRequest() : this("") { }
        public ViewCheckedoutRequest(Message<User> m) : this(m.Payload.Email) { }

        public new MessageType Type => MessageType.ViewCheckedoutRequest;
    }


    public class User
    {
        public string Email { get; }

        public User(string email)
        {
            Email = email;
        }
    }
}
