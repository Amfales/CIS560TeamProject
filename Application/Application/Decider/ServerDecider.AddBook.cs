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
        private void HandleAddBookRequest(SendMessage send, AddBookRequest m)
        {
            if (!IsAdmin(m.Payload.Email))
            {
                _logger("Did not add book.");
                send(new AddBookResponse(false));
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
                    InitializeAddBookCommand(ref comm, m);

                    comm.ExecuteNonQuery();

                    trans.Commit();

                    _logger("Successfully added book.");
                    send(new AddBookResponse(true));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }

        private void InitializeAddBookCommand(ref SqlCommand c, AddBookRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.AddBookWithoutInfoID";

            SqlParameter title = new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 128);
            title.Direction = System.Data.ParameterDirection.Input;
            title.Value = m.Payload.Book.Name;

            SqlParameter firstName = new SqlParameter("@AuthorFirstName", System.Data.SqlDbType.NVarChar, 128);
            firstName.Direction = System.Data.ParameterDirection.Input;
            firstName.Value = m.Payload.Book.Author.FirstName;

            SqlParameter lastName = new SqlParameter("@AuthorLastName", System.Data.SqlDbType.NVarChar, 128);
            lastName.Direction = System.Data.ParameterDirection.Input;
            lastName.Value = m.Payload.Book.Author.LastName;

            SqlParameter publisherName = new SqlParameter("@PublisherName", System.Data.SqlDbType.NVarChar, 128);
            publisherName.Direction = System.Data.ParameterDirection.Input;
            publisherName.Value = m.Payload.Book.Publisher;

            SqlParameter genre = new SqlParameter("@GenreDescriptor", System.Data.SqlDbType.NVarChar, 64);
            genre.Direction = System.Data.ParameterDirection.Input;
            genre.Value = m.Payload.Book.Genre;

            SqlParameter ISBN = new SqlParameter("@ISBN", System.Data.SqlDbType.NVarChar, 32);
            ISBN.Direction = System.Data.ParameterDirection.Input;
            ISBN.Value = m.Payload.Book.ISBN;

            SqlParameter copyrightYear = new SqlParameter("@CopyrightYear", System.Data.SqlDbType.SmallInt);
            copyrightYear.Direction = System.Data.ParameterDirection.Input;
            copyrightYear.Value = m.Payload.Book.CopyrightYear;

            SqlParameter bookID = new SqlParameter("@BookID", System.Data.SqlDbType.Int);
            bookID.Direction = System.Data.ParameterDirection.Output;


            c.Parameters.Add(title);
            c.Parameters.Add(firstName);
            c.Parameters.Add(lastName);
            c.Parameters.Add(publisherName);
            c.Parameters.Add(genre);
            c.Parameters.Add(ISBN);
            c.Parameters.Add(copyrightYear);
            c.Parameters.Add(bookID);
        }
    }
}
