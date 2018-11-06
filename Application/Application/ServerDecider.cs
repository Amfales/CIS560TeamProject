using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace ServerApplication
{
    public class ServerDecider
    {
        private Dictionary<string, bool> _loggedIn = new Dictionary<string, bool>();
        private Dictionary<string, UserType> _userPermissions = new Dictionary<string, UserType>();
        private const string _lowConnection = "";
        private const string _userConnection = "";
        private const string _libraryConnection = "";
        private const string _adminConnection = "";




        public void GetDecider(MessageEventArgs e, SendMessage func)
        {
            string data = e.Data;
            IMessage m = Newtonsoft.Json.JsonConvert.DeserializeObject<IMessage>(data);
            switch (m.Type)
            {
                case MessageType.LoginRequest:
                    HandleNewUserRequest(func, new LoginRequest(Message<Login>.UpgradeMessage(m)));
                    break;
                default:
                    break;
            }
        }

        private void HandleNewUserRequest(SendMessage f, LoginRequest m)
        {
            if (_loggedIn[m.Payload.UserName])
            {

            }
        }












        private void CreateNewUser(SendMessage send)
        {
            send(new LoginResponse());
        }




        private void DoNothing() { }
    }
}
