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
        private void HandleViewCheckedoutRequest(SendMessage send, ViewCheckedoutRequest m)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                SqlCommand comm      = conn.CreateCommand();
                SqlTransaction trans = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = trans;
                try
                {
                    InitializeViewCheckedoutCommand(ref comm, m);

                    List<CheckedoutBook> l = new List<CheckedoutBook>();
                    GrabViewCheckedout(comm, ref l);

                    _logger("Successfully found " + l.Count + " checked out books for user " + m.Payload.Email);
                    send(new ViewCheckedoutResponse(l));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeViewCheckedoutCommand(ref SqlCommand c, ViewCheckedoutRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.GetUserCheckedOutBooks";
            c.Parameters.AddWithValue("@Email", m.Payload.Email);
        }

        private void GrabViewCheckedout(SqlCommand c, ref List<CheckedoutBook> l)
        {
            using (SqlDataReader data = c.ExecuteReader())
            {
                while (data.Read())
                {
                    string title = data.GetString(data.GetOrdinal("Title"));
                    string aFirst = data.GetString(data.GetOrdinal("AuthorFirstName"));
                    string aLast = data.GetString(data.GetOrdinal("AuthorLastName"));
                    string isbn = data.GetString(data.GetOrdinal("ISBN"));
                    int copyYear = data.GetInt16(data.GetOrdinal("Copyrightyear"));
                    string pub = data.GetString(data.GetOrdinal("PublisherName"));
                    string gen = data.GetString(data.GetOrdinal("Genre"));
                    int id = data.GetInt32(data.GetOrdinal("BookID"));
                    DateTime dt = data.GetDateTime(data.GetOrdinal("DueDate"));

                    // TODO Add in the book quality and call the correct Book constructor

                   
                    CheckedoutBook cb = new CheckedoutBook(id, "", title, new Author(aFirst, aLast), isbn, gen, pub, copyYear, dt);
                    l.Add(cb);
                }
            }
        }
    }
}
