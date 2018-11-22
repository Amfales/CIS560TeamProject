﻿using System;
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
        private void HandleCheckoutRequest(SendMessage send, CheckoutRequest m)
        {
            if (m.Payload.IDs.Count == 0)
            {
                _logger("Did not process checkout for empty request.");
                return;
            }
            int paySize = m.Payload.IDs.Count;
            DateTime dt;
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                SqlCommand comm = conn.CreateCommand();
                SqlTransaction trans;
                trans = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trans;
                try
                {
                    InitializeCheckoutCommand(ref comm, m);
                    GrabCheckoutInfo(comm, m, paySize, out dt);

                    _logger("Successfully checked out " + paySize + " books to " + m.Payload.Email + ".");
                    send(new CheckoutResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }
            }
        }

        private void InitializeCheckoutCommand(ref SqlCommand c, CheckoutRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.CheckOutBook";
            c.Parameters.AddWithValue("@Email", m.Payload.Email);
            c.Parameters.AddWithValue("@BookID", m.Payload.IDs[0]);
            SqlParameter p = new SqlParameter("@DueDate", System.Data.SqlDbType.DateTime2);
            p.Direction = System.Data.ParameterDirection.Output;
            c.Parameters.Add(p);
        }
        private void UpdateCheckoutCommand(ref SqlCommand c, CheckoutRequest m, int ind)
        {
            c.Parameters["@BookID"].Value = m.Payload.IDs[ind];
        }

        private void GrabCheckoutInfo(SqlCommand c, CheckoutRequest m, int paySize, out DateTime returnDate)
        {
            int currInd = 0;
            while (currInd < paySize - 1)
            {
                c.ExecuteNonQuery();
                UpdateCheckoutCommand(ref c, m, currInd);
                currInd++;
            }
            c.ExecuteNonQuery(); //On the last one, grab the return date.
            returnDate = DateTime.Parse(
                c.Parameters["@DueDate"].Value.ToString()); //?????????????????
        }
    }
}