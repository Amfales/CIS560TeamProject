using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Requests;

namespace SharedLibrary
{
    public static class MessageConverter
    {

        public static IMessage Convert(IMessage m)
        {
            switch (m.Type)
            {
                case MessageType.LoginRequest:
                    return Message<Login>.UpgradeMessage(m);


                default:
                    return m;
            }
        }
    }
}
