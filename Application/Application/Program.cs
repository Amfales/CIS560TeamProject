using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using SharedLibrary;
using SharedLibrary.Requests;

namespace ServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoginRequest lr = new LoginRequest("andrew", "fales");
            IMessage m = lr;
            IPAddress localhost = new IPAddress(new byte[] { 127, 0, 0, 1 });
            WebSocketServer serv = new WebSocketServer(localhost, 9999);
            serv.AddWebSocketService<ServerBehavior>("/library");
            ServerBehavior sb = new ServerBehavior();
            Console.WriteLine(sb.Id);
            Console.ReadLine();
        }

        public static void DoNothing() { }
    }
}
