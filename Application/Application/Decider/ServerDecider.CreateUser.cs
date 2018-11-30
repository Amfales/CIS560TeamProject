using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace ServerApplication.Decider
{
    public partial class ServerDecider
    {
        private void HandleCreateUserRequest(SendMessage send, CreateUserRequest m)
        {
            if (!IsAdmin(m.Payload.Email))
            {
                _logger("Did not create new user.");
                send(new CreateUserResponse(false));
                return;
            }
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                SqlTransaction trans = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trans;
                try
                {
                    InitializeCreateUserCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    trans.Commit();

                    _logger("Successfully created " + m.Payload.FirstName + " " + m.Payload.LastName + "'s user.");
                    send(new CreateUserResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeCreateUserCommand(ref SqlCommand c, CreateUserRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Proj.AddUser";

            SqlParameter firstName = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 128);
            firstName.Direction = System.Data.ParameterDirection.Input;
            firstName.Value = m.Payload.FirstName;


            SqlParameter lastName = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 128);
            lastName.Direction = System.Data.ParameterDirection.Input;
            lastName.Value = m.Payload.LastName;


            SqlParameter email = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 128);
            email.Direction = System.Data.ParameterDirection.Input;
            email.Value = m.Payload.Email;

            SqlParameter hashedPassword = new SqlParameter("@HashedPassword", System.Data.SqlDbType.NVarChar, 64);
            hashedPassword.Direction = System.Data.ParameterDirection.Input;
            hashedPassword.Value = m.Payload.HashPassword;


            SqlParameter permissionLevel = new SqlParameter("@PermissionLevel", System.Data.SqlDbType.NVarChar, 32);
            permissionLevel.Direction = System.Data.ParameterDirection.Input;
            permissionLevel.Value = m.Payload.UserType;

            c.Parameters.Add(firstName);
            c.Parameters.Add(lastName);
            c.Parameters.Add(email);
            c.Parameters.Add(hashedPassword);
            c.Parameters.Add(permissionLevel);
        }
    }
}
