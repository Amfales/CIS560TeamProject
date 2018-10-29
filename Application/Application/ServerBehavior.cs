using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerApplication
{
    public class ServerBehavior: WebSocketBehavior
    {
        private Func<MessageEventArgs, IWebSocketSession, Task> _decider;

        public ServerBehavior()
        {
            throw new ArgumentException();
        }
        public ServerBehavior(Func<MessageEventArgs, IWebSocketSession, Task> decide)
        {
            _decider = decide;
        }



        protected override Task OnMessage(MessageEventArgs e)
        {
            return _decider(e, this.Sessions[this.Id]);
        }
       
    }
}
