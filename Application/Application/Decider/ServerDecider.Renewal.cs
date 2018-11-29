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
        private void HandleRenewalRequest(SendMessage send, RenewalRequest m)
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
                    InitializeRenewalCommand(ref comm, m);

                    List<DueDateAssociation> l = new List<DueDateAssociation>();
                    GrabRenewal(comm, m, ref l);

                    _logger("Successfully renewed " + l.Count + " checked out books for user " + m.Payload.Email);
                    send(new RenewalResponse(true, l));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }


        private void InitializeRenewalCommand(ref SqlCommand c, RenewalRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.RenewBook";
            c.Parameters.AddWithValue("@Email", m.Payload.Email);
            SqlParameter checkID = new SqlParameter("@CheckOutID", System.Data.SqlDbType.Int);
            checkID.Direction = System.Data.ParameterDirection.Output;
            SqlParameter dueDate = new SqlParameter("@NewDueDate", System.Data.SqlDbType.DateTime2);
            dueDate.Direction = System.Data.ParameterDirection.Output;
            SqlParameter bookID = new SqlParameter("@BookID", System.Data.SqlDbType.Int);
            bookID.Direction = System.Data.ParameterDirection.Input;
            c.Parameters.Add(checkID);
            c.Parameters.Add(dueDate);
            c.Parameters.Add(bookID);
        }

        private void UpdateRenewalCommand(ref SqlCommand c, RenewalRequest m, int index)
        {
            c.Parameters["@BookID"].Value = m.Payload.IDs[index];
        }

        private void GrabRenewal(SqlCommand c, RenewalRequest m, ref List<DueDateAssociation> l)
        {
            int index = 0;
            int goal = m.Payload.IDs.Count;
            do
            {
                UpdateRenewalCommand(ref c, m, index);
                c.ExecuteNonQuery();
                int checkID = Convert.ToInt32(c.Parameters["@BookID"].Value);
                DateTime dueDate = Convert.ToDateTime(c.Parameters["@NewDueDate"].Value);
                l.Add(new DueDateAssociation(checkID, dueDate));
                index++;
            }   while (index < goal);
        }
    }
}
