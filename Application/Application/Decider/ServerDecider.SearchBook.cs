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
        private void DecideSearchBookRequest(SendMessage send, SearchBookRequest m)
        {
            if (m.Payload.BookInfoOnly) HandleSearchBookInfoRequest(send, m);
            else HandleSearchBookRequest(send, m);
        }


        private void HandleSearchBookInfoRequest(SendMessage send, SearchBookRequest m)
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
                    InitializeSearchBookCommand(ref comm, m);

                    List<BookInfo> ss = new List<BookInfo>();
                    GrabSearchBookInfo(comm, ref ss);

                    _logger("Successfully found " + ss.Count + " BookInfo rows in the data base.");
                    send(new SearchBookInfoResponse(ss));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }
        private void HandleSearchBookRequest(SendMessage send, SearchBookRequest m)
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
                    InitializeSearchBookCommand(ref comm, m);

                    List<Book> l = new List<Book>();
                    GrabSearchBook(comm, ref l);

                    _logger("Successfully found " + l.Count + " Book rows in the data base.");
                    send(new SearchBookResponse(l));
                }
                catch (Exception ex)
                {
                    _logger(ex.ToString());
                }

            }
        }
        

        private void InitializeSearchBookCommand(ref SqlCommand c, SearchBookRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.SearchBookWithAll";
            c.Parameters.AddWithValue("@Title", m.Payload.Name);
            c.Parameters.AddWithValue("@FirstName", m.Payload.Author.FirstName);
            c.Parameters.AddWithValue("@LastName", m.Payload.Author.LastName);
            c.Parameters.AddWithValue("@ISBN", m.Payload.ISBN);
            c.Parameters.AddWithValue("@GenreDescriptor", m.Payload.Genre);
        }

        private void GrabSearchBook(SqlCommand c, ref List<Book> ss)
        {
            using (SqlDataReader data = c.ExecuteReader())
            {
                while (data.Read())
                {
                    bool isCheckedOut = data.GetInt32(data.GetOrdinal("CheckedOut")) != 0;
                    if (!isCheckedOut)
                    {
                        string title = data.GetString(data.GetOrdinal("Title"));
                        string aFirst = data.GetString(data.GetOrdinal("AuthorFirstName"));
                        string aLast = data.GetString(data.GetOrdinal("AuthorLastName"));
                        string isbn = data.GetString(data.GetOrdinal("ISBN"));
                        int copyYear = data.GetInt16(data.GetOrdinal("Copyrightyear"));
                        string pub = data.GetString(data.GetOrdinal("PublisherName"));
                        string gen = data.GetString(data.GetOrdinal("Genre"));
                        int id = data.GetInt32(data.GetOrdinal("BookID"));

                        // TODO Add in the book quality and call the correct Book constructor

                        BookInfo bi = new BookInfo(title, new Author(aFirst, aLast),
                            isbn, gen, pub, copyYear);
                        Book b = new Book(id, "", bi);
                        ss.Add(b);
                    }
                }
            }
        }
        private void GrabSearchBookInfo(SqlCommand c, ref List<BookInfo> ss)
        {
            using (SqlDataReader data = c.ExecuteReader())
            {
                while (data.Read())
                {
                    bool isCheckedOut = data.GetInt32(data.GetOrdinal("CheckedOut")) != 0;
                    if (!isCheckedOut)
                    {
                        string title = data.GetString(data.GetOrdinal("Title"));
                        string aFirst = data.GetString(data.GetOrdinal("AuthorFirstName"));
                        string aLast = data.GetString(data.GetOrdinal("AuthorLastName"));
                        string isbn = data.GetString(data.GetOrdinal("ISBN"));
                        int copyYear = data.GetInt16(data.GetOrdinal("Copyrightyear"));
                        string pub = data.GetString(data.GetOrdinal("PublisherName"));
                        string gen = data.GetString(data.GetOrdinal("Genre"));
                        BookInfo b = new BookInfo(title, new Author(aFirst, aLast),
                            isbn, gen, pub, copyYear);
                        ss.Add(b);
                    }
                }
            }
        }
    }
}
