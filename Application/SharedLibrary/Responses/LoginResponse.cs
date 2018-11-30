using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Responses
{
    public class LoginResponse : Message<LoginResponseData>
    {
        [JsonConstructor]
        public LoginResponse(bool succ, int p, string f)
        {
            Payload = new LoginResponseData(succ, p, f);
        }
        public LoginResponse() : this(false, default(int), "") { }
        public LoginResponse(Message<LoginResponseData> m)
        {
            Payload = new LoginResponseData(m.Payload.UserLoggedIn, m.Payload.PermissionLevel, m.Payload.FirstName);
        }
        public new MessageType Type => MessageType.LoginResponse;
    }

    public class LoginResponseData
    {
        public bool UserLoggedIn { get; }
        public int PermissionLevel { get; }
        public string FirstName { get; }

        public LoginResponseData(bool userloggedin, int permissionlevel, string firstname)
        {
            UserLoggedIn = userloggedin;
            PermissionLevel = permissionlevel;
            FirstName = firstname;
        }
    }
}
