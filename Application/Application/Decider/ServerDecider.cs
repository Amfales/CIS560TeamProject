using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

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
        private string _connection = "server=tcp:" + Dns.GetHostEntry("fullmilkpig.ddns.net").AddressList[0].ToString() + "\\LIBRARYKIOSK, 1433";
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
                case MessageType.CheckoutRequest:
                    HandleCheckoutRequest(send, new CheckoutRequest(Message<Checkout>.UpgradeMessage(m)));
                    break;
                case MessageType.ViewCheckedoutRequest:
                    HandleViewCheckedoutRequest(send, new ViewCheckedoutRequest(Message<User>.UpgradeMessage(m)));
                    break;
                case MessageType.RenewalRequest:
                    HandleRenewalRequest(send, new RenewalRequest(Message<Renewal>.UpgradeMessage(m)));
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
