using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

using System.Data.SqlClient;

namespace ServerApplication.Decider
{
    public partial class ServerDecider
    {
        private void HandleResetPasswordRequest(SendMessage send, ResetPasswordRequest m)
        {
            if (!IsAdmin(m.Payload.UserEmail))
            {
                _logger("Did not reset password.");
                send(new ResetPasswordResponse(false));
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
                    InitializeResetPasswordCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    _logger("Successfully updated " + m.Payload.ResetEmail + "'s password.");
                    send(new ResetPasswordResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }
        private void InitializeResetPasswordCommand(ref SqlCommand c, ResetPasswordRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Proj.ChangePassword";
            c.Parameters.AddWithValue("@Email", m.Payload.ResetEmail);
            c.Parameters.AddWithValue("@NewHashedPassword", m.Payload.ResetPassword);
        }
    }
}
