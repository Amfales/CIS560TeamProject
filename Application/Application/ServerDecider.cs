using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using SharedLibrary.Responses;

namespace ServerApplication
{
    public static class ServerDecider
    {
        public static Task GetDecider(MessageEventArgs e, SendMessage func)
        {
            return CreateNewUser(func);
        }




        private static Task CreateNewUser(SendMessage f)
        {
            return f(new LoginResponse());
        }
    }
}
