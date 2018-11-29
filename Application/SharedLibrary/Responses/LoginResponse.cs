using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class LoginResponse : Message<LoginResponseData>
    {
        public LoginResponse(bool succ, UserType p, string f)
        {
            Payload = new LoginResponseData(succ, p, f);
        }
        public LoginResponse() : this(false, default(UserType), "") { }
        public LoginResponse(Message<LoginResponseData> m)
        {
            Payload = new LoginResponseData(m.Payload.UserLoggedIn, m.Payload.PermissionLevel, m.Payload.FirstName);
        }
        public static new MessageType Type => MessageType.LoginResponse;
    }

    public class LoginResponseData
    {
        public bool UserLoggedIn { get; }
        public UserType PermissionLevel { get; }
        public string FirstName { get; }

        public LoginResponseData(bool log, UserType p, string f)
        {
            UserLoggedIn = log;
            PermissionLevel = p;
            FirstName = f;
        }
    }
}
