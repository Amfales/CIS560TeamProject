using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public enum MessageType
    {
        LoginRequest,
        LoginResponse,

        SearchBookRequest,
        SearchBookInfoResponse,
        SearchBookResponse,

        CreateNewUserRequest,
        CreateNewUserResponse,

        GetBookRequest,
        GetBookResponse,

        CheckoutRequest,
        CheckoutResponse,


        Error
    }
}
