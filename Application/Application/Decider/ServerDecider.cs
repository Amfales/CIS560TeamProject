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
            "server=tcp:" + Dns.GetHostEntry("fullmilkpig.ddns.net").AddressList[0].ToString() + ", 1733;" +
            "Database=librarykiosk;" +
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
            IMessage m = Deserialize<IMessage>(data, c);
            switch (m.Type)
            {
                case MessageType.AddBookRequest:
                    HandleAddBookRequest(send, Deserialize<AddBookRequest>(data, c));
                    break;
                case MessageType.CheckoutRequest:
                    HandleCheckoutRequest(send, Deserialize<CheckoutRequest>(data, c));
                    break;
                case MessageType.CreateUserRequest:
                    HandleCreateUserRequest(send, Deserialize<CreateUserRequest>(data, c));
                    break;
                case MessageType.GetBookRequest:
                    HandleGetBookRequest(send, Deserialize<GetBookRequest>(data, c));
                    break;
                case MessageType.LoginRequest:
                    HandleLoginRequest(send, Deserialize<LoginRequest>(data, c));
                    break;
                case MessageType.RenewalRequest:
                    HandleRenewalRequest(send, Deserialize<RenewalRequest>(data, c));
                    break;
                case MessageType.ResetPasswordRequest:
                    HandleResetPasswordRequest(send, Deserialize<ResetPasswordRequest>(data, c));
                    break;
                case MessageType.RetireBookRequest:
                    HandleRetireBookRequest(send, Deserialize<RetireBookRequest>(data, c));
                    break;
                case MessageType.ReturnRequest:
                    HandleReturnRequest(send, Deserialize<ReturnRequest>(data, c));
                    break;
                case MessageType.SearchBookRequest:
                    DecideSearchBookRequest(send, Deserialize<SearchBookRequest>(data, c));
                    break;
                case MessageType.UpdateBookConditionRequest:
                    HandleUpdateBookConditionRequest(send, Deserialize<UpdateBookConditionRequest>(data, c));
                    break;
                case MessageType.ViewCheckedoutRequest:
                    HandleViewCheckedoutRequest(send, Deserialize<ViewCheckedoutRequest>(data, c));
                    break;
                default:
                    break;
            }
        }

        private T Deserialize<T>(string data, JsonConverter[] c)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data, c);
        }


        private bool IsAdmin(string adminEmail)
        {
            return _loggedIn.ContainsKey(adminEmail) &&
                   _loggedIn[adminEmail] &&
                   _userPermissions.ContainsKey(adminEmail) &&
                   _userPermissions[adminEmail] == UserType.Admin;

        }
    }
}
