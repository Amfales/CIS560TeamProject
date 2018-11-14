using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Responses
{
    public class LoginResponse : Message<LoginResponseData>
    {

    }

    public class LoginResponseData
    {
        public bool UserLoggedIn { get; }
        public int 

        public LoginResponseData(bool log) { UserLoggedIn = log; }
    }
}
