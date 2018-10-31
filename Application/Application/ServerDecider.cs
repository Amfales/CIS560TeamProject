using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerApplication
{
    public static class ServerDecider
    {
        public static Task GetDecider(MessageEventArgs e, IWebSocketSession sess)
        {
            return new Task(CreateNewUser);
        }




        private static void CreateNewUser()
        {

        }
    }
}
