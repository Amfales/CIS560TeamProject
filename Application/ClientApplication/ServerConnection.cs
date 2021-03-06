﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;
using WebSocketSharp.Net;
using WebSocketSharp;
using Newtonsoft.Json;

namespace ClientApplication
{
    class ServerConnection
    {
        private WebSocket connection;
        public messageReceive onReceive;
        public delegate void messageReceive(string data);

        public ServerConnection(string url)
        {
            connection = new WebSocket(url);
            connection.OnMessage += (s, e) => { onReceive.Invoke(e.Data); };
            connection.Connect();
        }

        public void Send(IMessage m)
        {
            connection.Send(JsonConvert.SerializeObject(m));
        }
    }
}
