using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using WebSocketSharp;
using WebSocketSharp.Server;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace ServerApplication.Decider
{
    public partial class ServerDecider
    {
        private Dictionary<string, bool> _loggedIn = new Dictionary<string, bool>();
        private Dictionary<string, UserType> _userPermissions = new Dictionary<string, UserType>();
        private const string _connection = "";
        private LogFunction _logger;

        public ServerDecider(LogFunction l)
        {
            _logger = l;
        }




        public void GetDecision(MessageEventArgs e, SendMessage send)
        {
            string data = e.Data;
            IMessage m = Newtonsoft.Json.JsonConvert.DeserializeObject<IMessage>(data);
            switch (m.Type)
            {
                case MessageType.LoginRequest:
                    HandleLoginRequest(send, new LoginRequest(Message<Login>.UpgradeMessage(m)));
                    break;
                case MessageType.SearchBookRequest:
                    DecideSearchBookRequest(send, new SearchBookRequest(Message<SearchInfo>.UpgradeMessage(m)));
                    break;
                default:
                    break;
            }
        }

        private void HandleLoginRequest(SendMessage send, LoginRequest m)
        {
            if (_loggedIn[m.Payload.Email])
            {

            }
        }


        private void CreateNewUser(SendMessage send)
        {
            send(new LoginResponse());
        }
    }
}
