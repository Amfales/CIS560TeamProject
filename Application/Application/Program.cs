using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;
using System.Windows.Forms;

namespace ServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            IPAddress localhost = new IPAddress(new byte[] { 127, 0, 0, 1 });
            WebSocketServer serv = new WebSocketServer(9999);
            WebServer server = new WebServer(12345);
            serv.AddWebSocketService<TestBehavior>("/test", () => (new TestBehavior(Console.WriteLine)));
            WebSocket ws = new WebSocket("ws://localhost:9999/test");
            //WebSocket ws = new WebSocket("ws://localhost:9999/", onMessage: DoPrint, onError: DoError);
            serv.Start();
            /*
            LoginRequest lr = new LoginRequest("username", "password");
            IMessage m = lr;
            Login l = m.Payload as Login;
            LoginRequest t = new LoginRequest(Message<Login>.UpgradeMessage(m));
            if (l != null)
            {
                Console.WriteLine("UserName: " + l.UserName);
            }
            else
            {
                Console.WriteLine("l is null");
            }*/
            

            ws.OnMessage += (sender, e) => { Console.WriteLine(e.Data); };

            DoThings(ws);
            string msg = "";
            while ((msg = Console.ReadLine()) != "")
            {
                ws.Send(msg);
            }
            ws.Send("end");
            serv.Stop();
            while (true)
            {
                Console.ReadLine();
            }
            
        }
        

        public static void DoThings(WebSocket w)
        {
            //w = new WebSocket(address, onMessage: DoPrint, onError: DoError);
            
            w.Connect();
            //w.
            Console.WriteLine("Did connect.");
            w.Send("This is a message");
        }
    }
}
