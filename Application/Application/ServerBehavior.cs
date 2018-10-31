using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerApplication
{
    public delegate Task<bool> SendToFunc(string data);
    public class ServerBehavior: WebSocketBehavior
    {
        private Func<MessageEventArgs, SendToFunc, Task> _decider;

        public ServerBehavior()
        {
            throw new ArgumentException();
        }
        public ServerBehavior(Func<MessageEventArgs, SendToFunc, Task> decide)
        {
            _decider = decide;
        }
        

        protected override Task OnMessage(MessageEventArgs e)
        {
            return _decider(e, WrappedSendTo);
        }

        private Task<bool> WrappedSendTo(string data)
        {
            return this.Sessions.SendTo(this.Id, data);
        }
       
    }
}
