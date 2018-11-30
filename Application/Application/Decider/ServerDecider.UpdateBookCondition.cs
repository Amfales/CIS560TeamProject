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
        private void HandleUpdateBookConditionRequest(SendMessage send, UpdateBookConditionRequest m)
        {
            if (!IsAdmin(m.Payload.Email))
            {
                _logger("Did not update condition.");
                send(new UpdateBookConditionResponse(false));
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
                    InitializeUpdateBookConditionCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    trans.Commit();

                    _logger("Successfully updated description.");
                    send(new UpdateBookConditionResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeUpdateBookConditionCommand(ref SqlCommand c, UpdateBookConditionRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.UpdateBookQuality";

            SqlParameter bookID = new SqlParameter("@BookID", System.Data.SqlDbType.Int);
            bookID.Direction = System.Data.ParameterDirection.Input;
            bookID.Value = m.Payload.BookID;

            SqlParameter desc = new SqlParameter("@NewDescriptor", System.Data.SqlDbType.NVarChar, 32);
            desc.Direction = System.Data.ParameterDirection.Input;
            desc.Value = m.Payload.Condition;
            
            c.Parameters.Add(bookID);
            c.Parameters.Add(desc);
        }
    }
}
