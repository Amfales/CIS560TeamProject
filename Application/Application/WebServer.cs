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
        private ServerDecider _servDecider;
        private static IPAddress localHost = new IPAddress(new byte[] { 127, 0, 0, 1 });



        public WebServer(IPAddress add, int port)
        {
            _serv = new WebSocketServer(add, port);
            _servDecider = new ServerDecider();
            _serv.AddWebSocketService<ServerBehavior>("/library", InitializeService);
        }
        public WebServer(int port) : this(localHost, port) { }

        private ServerBehavior InitializeService()
        {
            return new ServerBehavior(ServerDecide);
        }
        
        private void ServerDecide(MessageEventArgs e, SendMessage func)
        {
            _servDecider.GetDecision(e, func);
        }

        public void Start()
        {
            _serv.Start();
        }

        public void Stop()
        {
            _serv.Stop();
        }

    }
}
