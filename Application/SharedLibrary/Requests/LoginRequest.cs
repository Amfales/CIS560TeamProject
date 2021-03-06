﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SharedLibrary.Requests
{
    public class LoginRequest : Message<Login>
    {
        public LoginRequest() : this("", "") { }

        [JsonConstructor]
        public LoginRequest(string e, string p)
        {
            Payload = new Login(e, p);
        }
        public LoginRequest(Message<Login> m)
        {
            Payload = new Login(m.Payload.Email, m.Payload.HashPassword);
        }
        public new MessageType Type => MessageType.LoginRequest;
    }

    public class Login
    {
        public string Email { get; }
        public string HashPassword { get; }
        public Login(string email, string hashpassword)
        {
            Email = email;
            HashPassword = hashpassword;
        }
        
    }
}
