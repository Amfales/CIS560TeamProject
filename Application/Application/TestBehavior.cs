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
    public class TestBehavior : WebSocketBehavior
    {
        public delegate void LogFunction(string s);
        LogFunction _f;

        public TestBehavior(LogFunction f)
        { _f = f; }


        protected override void OnMessage(MessageEventArgs e)
        {
            string text = e.Data;
            //_f(text);
            Send("Server was sent: " + text);
        }
    }
}
