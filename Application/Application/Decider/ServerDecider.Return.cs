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
        private void HandleReturnRequest(SendMessage send, ReturnRequest m)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                SqlTransaction trans = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trans;
                try
                {
                    InitializeReturnCommand(ref comm, m);
                    
                    GrabReturn(comm, m);

                    _logger("Successfully returned " + m.Payload.Count + " checked out books.");
                    send(new ReturnResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeReturnCommand(ref SqlCommand c, ReturnRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.CheckInBook";
            SqlParameter bookID = new SqlParameter("@BookID", System.Data.SqlDbType.Int);
            bookID.Direction = System.Data.ParameterDirection.Input;
            SqlParameter checkoutID = new SqlParameter("@CheckOutID", System.Data.SqlDbType.Int);
            checkoutID.Direction = System.Data.ParameterDirection.Output;
            c.Parameters.Add(bookID);
            c.Parameters.Add(checkoutID);
        }

        private void UpdateReturnCommand(ref SqlCommand c, ReturnRequest m, int index)
        {
            c.Parameters["@BookID"].Value = m.Payload[index];
        }

        private void GrabReturn(SqlCommand c, ReturnRequest m)
        {
            int index = 0;
            int goal = m.Payload.Count;
            do
            {
                UpdateReturnCommand(ref c, m, index);
                c.ExecuteNonQuery();
                index++;
            } while (index < goal);
        }
    }
}
