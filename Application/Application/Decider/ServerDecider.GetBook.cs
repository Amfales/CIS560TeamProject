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
        public void HandleGetBookRequest(SendMessage send, GetBookRequest m)
        {
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
                    InitializeGetBookCommand(ref comm, m);

                    BookInfo b;
                    GrabGetBookInfo(comm, out b);

                    _logger("Successfully found book with book id: " + m.Payload);
                    send(new GetBookResponse(b));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }
            }
        }

        private void InitializeGetBookCommand(ref SqlCommand c, GetBookRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.GetAllBookInfoForBook";
            c.Parameters.AddWithValue("@BookID", m.Payload);
        }

        private void GrabGetBookInfo(SqlCommand c, out BookInfo b)
        {
            using (SqlDataReader data = c.ExecuteReader())
            {
                if (!data.HasRows)
                {
                    throw new Exception("No book with the given ID");
                }
                data.Read();
                string title = data.GetString(data.GetOrdinal("Title"));
                string aFirst = data.GetString(data.GetOrdinal("AuthorFirstName"));
                string aLast = data.GetString(data.GetOrdinal("AuthorLastName"));
                string isbn = data.GetString(data.GetOrdinal("ISBN"));
                int copyYear = data.GetInt16(data.GetOrdinal("Copyrightyear"));
                string pub = data.GetString(data.GetOrdinal("PublisherName"));
                string gen = data.GetString(data.GetOrdinal("Genre"));

                // TODO Add in the book quality and call the correct Book constructor

                b = new BookInfo(title, new Author(aFirst, aLast),
                    isbn, gen, pub, copyYear);
            }
        }
    }
}
