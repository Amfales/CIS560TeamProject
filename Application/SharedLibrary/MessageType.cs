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

        GetBookRequest,
        GetBookResponse,

        CheckoutRequest,
        CheckoutResponse,

        ViewCheckedoutRequest,
        ViewCheckedoutResponse,

        RenewalRequest,
        RenewalResponse,

        ReturnRequest,
        ReturnResponse,

        ResetPasswordRequest,
        ResetPasswordResponse,

        AddBookRequest,
        AddBookResponse,

        RetireBookRequest,
        RetireBookResponse,

        UpdateBookConditionRequest,
        UpdateBookConditionResponse,

        CreateUserRequest,
        CreateUserResponse,


        Error
    }
}
