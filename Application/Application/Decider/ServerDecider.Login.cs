using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

using System.Data.SqlClient;

namespace ServerApplication.Decider
{
    public partial class ServerDecider
    {
        private void HandleLoginRequest(SendMessage send, LoginRequest m)
        { /*
            if (_loggedIn.ContainsKey(m.Payload.Email) && _loggedIn[m.Payload.Email])
            {
                _logger("User is alreadly logged in.");
                send(new LoginResponse(false, -1, ""));
                return;
            }
            */
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                SqlTransaction trans = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trans;
                try
                {
                    InitializeLoginCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    _logger("Successfully logged in.");
                    string perm = Convert.ToString(comm.Parameters["@PermissionLevel"].Value);
                    string name = Convert.ToString(comm.Parameters["@FirstNAME"].Value);
                    if (perm == "Admin")
                    {
                        send(new LoginResponse(true, 1,name));
                        _userPermissions[m.Payload.Email] = UserType.Admin;
                    }
                    else
                    {
                        send(new LoginResponse(true, 0, name));
                        _userPermissions[m.Payload.Email] = UserType.Standard;
                    }
                    _loggedIn[m.Payload.Email] = true;
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }
            }
        }

        private void InitializeLoginCommand(ref SqlCommand c, LoginRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Proj.LoginUser";

            SqlParameter email = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 128);
            email.Direction = System.Data.ParameterDirection.Input;
            email.Value = m.Payload.Email;

            SqlParameter hashPass = new SqlParameter("@HashedPassword", System.Data.SqlDbType.NVarChar, 64);
            hashPass.Direction = System.Data.ParameterDirection.Input;
            hashPass.Value = m.Payload.HashPassword;

            SqlParameter firstName = new SqlParameter("@FirstNAME", System.Data.SqlDbType.NVarChar, 128);
            firstName.Direction = System.Data.ParameterDirection.Output;

            SqlParameter perm = new SqlParameter("@PermissionLevel", System.Data.SqlDbType.NVarChar, 32);
            perm.Direction = System.Data.ParameterDirection.Output;


            c.Parameters.Add(email);
            c.Parameters.Add(hashPass);
            c.Parameters.Add(firstName);
            c.Parameters.Add(perm);
        }
    }
}
