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
    public delegate Task<bool> SendToFunc(string data);
    public delegate Task SendMessage(IMessage m);
    public class ServerBehavior: WebSocketBehavior
    {
        private Func<MessageEventArgs, SendMessage, Task> _decider;

        public ServerBehavior()
        {
            throw new ArgumentException();
        }
        public ServerBehavior(Func<MessageEventArgs, SendMessage, Task> decide)
        {
            _decider = decide;
        }
        

        protected override Task OnMessage(MessageEventArgs e)
        {
            return _decider(e, SendMessage);
        }

        private Task<bool> WrappedSendTo(string data)
        {
            return this.Sessions.SendTo(this.Id, data);
        }

        private Task SendMessage(IMessage m)
        {
            string data = JsonConvert.SerializeObject(m);
            return WrappedSendTo(data);
        }
       
    }
}
