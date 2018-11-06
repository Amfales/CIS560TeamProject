using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class LoginRequest : Message<Login>
    {
        public LoginRequest() : this("", "") { }
        public LoginRequest(string u, string p) : base()
        {
            Payload = new Login(u, p);
        }
        public LoginRequest(Message<Login> m)
        {
            Payload = new Login(m.Payload.UserName, m.Payload.HashPassword);
        }
        public static new MessageType Type => MessageType.LoginRequest;
    }

    public class Login
    {
        public Login(string un, string hp)
        {
            UserName = un;
            HashPassword = hp;
        }
        public string UserName { get; }
        public string HashPassword { get; }
    }
}
