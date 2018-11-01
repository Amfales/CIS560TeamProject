using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using SharedLibrary;
using Newtonsoft.Json;

namespace ServerApplication
{
    public class WebServer
    {
        private WebSocketServer _serv;
        private const string _lowConnection     = "";
        private const string _userConnection    = "";
        private const string _libraryConnection = "";
        private const string _adminConnection   = "";



        public WebServer(IPAddress add, int port)
        {
            _serv = new WebSocketServer(add, port);
            _serv.AddWebSocketService<ServerBehavior>("/library", InitializeService);
        }

        private ServerBehavior InitializeService()
        {
            return new ServerBehavior(ServerDecide);
        }
        
        private Task ServerDecide(MessageEventArgs e, SendMessage func)
        {
            return ServerDecider.GetDecider(e, func);
        }


        private Task SendMessage(SendToFunc sendFunc, IMessage m)
        {
            return sendFunc(JsonConvert.SerializeObject(m));
        }

    }
}
