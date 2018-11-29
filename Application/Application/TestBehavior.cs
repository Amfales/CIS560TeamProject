using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;



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
            LoginRequest l = JsonConvert.DeserializeObject<LoginRequest>(text);
            Send( JsonConvert.SerializeObject(new LoginResponse(true, 0, "this is their first name")));
        }
    }
}
