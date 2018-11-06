using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class ErrorMessage : Message<Error>
    {
        public static new MessageType Type => MessageType.Error;

        public ErrorMessage(string error, ErrorType t) : base()
        {
            Payload = new Error(error, t);
        }

        public ErrorMessage() : this("",default(ErrorType)) { }
    }



    public class Error
    {
        public string ErrorMessage { get; }
        public ErrorType Type { get; }

        public Error(string e, ErrorType t)
        {
            ErrorMessage = e;
            Type = t;
        }
    }

    public enum ErrorType
    {
        Default,
        UserAlreadyLoggedIn
    }
}
