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
using System.Windows.Forms;

namespace ServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            IPAddress localhost = new IPAddress(new byte[] { 127, 0, 0, 1 });
            WebSocketServer serv = new WebSocketServer(9999);
            serv.AddWebSocketService<TestBehavior>("/test", () => (new TestBehavior(Console.WriteLine)));
            WebSocket ws = new WebSocket("ws://localhost:9999/test");
            //WebSocket ws = new WebSocket("ws://localhost:9999/", onMessage: DoPrint, onError: DoError);

            ws.OnMessage += (sender, e) => { Console.WriteLine(e.Data); };

            DoThings(ws);
            //DoThings("ws://echo.websocket.org");
            //DoThings("ws://localhost:9999/", ws);
            while (Console.ReadLine() == "")
            {

            }
            ws.Send("end");
            while (true)
            {
                Console.ReadLine();
            }
            
        }

        private static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void DoThings(WebSocket w)
        {
            //w = new WebSocket(address, onMessage: DoPrint, onError: DoError);
            
            w.Connect();
            w.Send("This is a message");
        }
    }
}
