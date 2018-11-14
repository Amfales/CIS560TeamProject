using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using SharedLibrary;
using Newtonsoft.Json;


namespace ServerApplication
{
    //public delegate Task<bool> SendToFunc(string data);
    public delegate void SendMessage(IMessage m);
    public delegate void HandleMessage(MessageEventArgs e, SendMessage s);
    public class ServerBehavior: WebSocketBehavior
    {
        private HandleMessage _decider;
        

        public ServerBehavior()
        {
            throw new ArgumentException();
        }
        public ServerBehavior(HandleMessage decide)
        {
            _decider = decide;
        }
        

        protected override void OnMessage(MessageEventArgs e)
        {
            _decider(e, SendMessage);
        }

        private void WrappedSendTo(string data)
        {
            this.Sessions.SendTo(data, this.ID);
        }

        private void SendMessage(IMessage m)
        {
            string data = JsonConvert.SerializeObject(m);
            WrappedSendTo(data);
        }
       
    }
}
