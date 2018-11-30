using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class CreateUserRequest : Message<NewUserInfo>
    {
        [JsonConstructor]
        public CreateUserRequest(string email, string hashpassword, string firstname, string lastname, string usertype)
        {
            Payload = new NewUserInfo(email, hashpassword, firstname, lastname, usertype);
        }

        public CreateUserRequest() : this("","","","","") { }

        public new MessageType Type => MessageType.CreateUserRequest;
    }

    public class NewUserInfo
    {
        public string Email { get; }
        public string HashPassword { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string UserType { get; }

        public NewUserInfo(string email, string hashpassword, string firstname, string lastname, string usertype)
        {
            Email = email;
            HashPassword = hashpassword;
            FirstName = firstname;
            LastName = lastname;
            UserType = usertype;
        }

    }


}
