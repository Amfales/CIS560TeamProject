﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Requests
{
    public class ResetPasswordRequest : Message<Reset>
    {
        public ResetPasswordRequest(string re, string rp, string ue)
        {
            Payload = new Reset(re, rp, ue);
        }
        public ResetPasswordRequest() : this("","","") { }
        public ResetPasswordRequest(Message<Reset> m)
        {
            Payload = new Reset(m.Payload.ResetEmail, m.Payload.ResetPassword,
                m.Payload.UserEmail);
        }
        public static new MessageType Type => MessageType.ResetPasswordRequest;

    }

    public class Reset
    {
        public string ResetEmail { get; }
        public string ResetPassword { get; }
        public string UserEmail { get; }
        public Reset(string re, string rp, string ue)
        {
            ResetEmail = re;
            ResetPassword = rp;
            UserEmail = ue;
        }
    }
}
