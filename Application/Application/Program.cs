﻿using System;
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
using Newtonsoft.Json;

namespace ServerApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IPAddress localhost = new IPAddress(new byte[] { 127, 0, 0, 1 });
            //WebSocketServer serv = new WebSocketServer(9999);
            WebServer server = new WebServer(12345);
            //serv.AddWebSocketService<TestBehavior>("/test", () => (new TestBehavior(Console.WriteLine)));
            //WebSocket ws = new WebSocket("ws://localhost:12345/library");
            //WebSocket ws = new WebSocket("ws://localhost:9999/", onMessage: DoPrint, onError: DoError);
            //serv.Start();

            server.Start();
            
            
                

            while (true)
            {
                Console.ReadLine();
            }
            
        }
    }
}
