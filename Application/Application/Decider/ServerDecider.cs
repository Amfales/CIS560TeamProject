using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

using Newtonsoft.Json;

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
        private string _connection =
            "server=tcp:" + Dns.GetHostEntry("fullmilkpig.ddns.net").AddressList[0].ToString() + "\\LIBRARYKIOSK, 1733;" +
            "User id=NHelgeson;" +
            "Password=buttz560";
        private LogFunction _logger;

        public ServerDecider(LogFunction l)
        {
            _logger = l;
        }




        public void GetDecision(MessageEventArgs e, SendMessage send)
        {
            JsonConverter[] c = new JsonConverter[1];
            c[0] = new Newtonsoft.Json.Converters.StringEnumConverter();
            string data = e.Data;
            IMessage m = Newtonsoft.Json.JsonConvert.DeserializeObject<IMessage>(data, c);
            switch (m.Type)
            {
                case MessageType.LoginRequest:
                    HandleLoginRequest(send, Newtonsoft.Json.JsonConvert.DeserializeObject<LoginRequest>(data, c));
                    break;
                case MessageType.SearchBookRequest:
                    DecideSearchBookRequest(send, Newtonsoft.Json.JsonConvert.DeserializeObject<SearchBookRequest>(data));
                    break;
                case MessageType.CheckoutRequest:
                    HandleCheckoutRequest(send, Newtonsoft.Json.JsonConvert.DeserializeObject<CheckoutRequest>(data));
                    break;
                case MessageType.ViewCheckedoutRequest:
                    HandleViewCheckedoutRequest(send, Newtonsoft.Json.JsonConvert.DeserializeObject<ViewCheckedoutRequest>(data));
                    break;
                case MessageType.RenewalRequest:
                    HandleRenewalRequest(send, Newtonsoft.Json.JsonConvert.DeserializeObject<RenewalRequest>(data));
                    break;
                default:
                    break;
            }
        }

        private bool IsAdmin(string adminEmail)
        {
            return _loggedIn.ContainsKey(adminEmail) &&
                   _loggedIn[adminEmail] &&
                   _userPermissions.ContainsKey(adminEmail) &&
                   _userPermissions[adminEmail] == UserType.Admin;

        }

        /*
        private void CreateNewUser(SendMessage send)
        {
            send(new LoginResponse());
        }
        */
    }
}
