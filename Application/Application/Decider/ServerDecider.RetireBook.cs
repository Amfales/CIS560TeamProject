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
        private void HandleRetireBookRequest(SendMessage send, RetireBookRequest m)
        {
            if (!IsAdmin(m.Payload.Email))
            {
                _logger("Did not retire book.");
                send(new RetireBookResponse(false));
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
                    InitializeRetireBookCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    _logger("Successfully retired a book.");
                    send(new RetireBookResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeRetireBookCommand(ref SqlCommand c, RetireBookRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.RemoveBookWithID";
            c.Parameters.AddWithValue("@BookID", m.Payload.BookId);
        }
    }
}
