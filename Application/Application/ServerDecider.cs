using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using WebSocketSharp;
using WebSocketSharp.Server;

using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace ServerApplication
{
    public class ServerDecider
    {
        private Dictionary<string, bool> _loggedIn = new Dictionary<string, bool>();
        private Dictionary<string, UserType> _userPermissions = new Dictionary<string, UserType>();
        private const string _connection = "";
        private LogFunction _logger;

        public ServerDecider(LogFunction l)
        {
            _logger = l;
        }




        public void GetDecision(MessageEventArgs e, SendMessage send)
        {
            string data = e.Data;
            IMessage m = Newtonsoft.Json.JsonConvert.DeserializeObject<IMessage>(data);
            switch (m.Type)
            {
                case MessageType.LoginRequest:
                    HandleLoginRequest(send, new LoginRequest(Message<Login>.UpgradeMessage(m)));
                    break;
                case MessageType.SearchBookRequest:
                    DecideSearchBookRequest(send, new SearchBookRequest(Message<SearchInfo>.UpgradeMessage(m)));
                    break;
                default:
                    break;
            }
        }

        private void HandleLoginRequest(SendMessage send, LoginRequest m)
        {
            if (_loggedIn[m.Payload.Email])
            {

            }
        }

        private void DecideSearchBookRequest(SendMessage send, SearchBookRequest m)
        {
            if (m.Payload.BookInfoOnly) HandleSearchBookInfoRequest(send, m);
            else HandleSearchBookRequest(send, m);
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

                    SortedSet<BookInfo> ss = new SortedSet<BookInfo>(new BookInfo.BookInfoComparer());
                    GrabSearchBookInfo(comm, ref ss);

                    send(new SearchBookInfoResponse(ss));
                }
                catch (Exception ex)
                {

                }

            }
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

                    SortedSet<BookInfo> ss = new SortedSet<BookInfo>(new BookInfo.BookInfoComparer());
                    GrabSearchBookInfo(comm, ref ss);

                    send(new SearchBookInfoResponse(ss));
                }
                catch (Exception ex)
                {

                }

            }
        }

        private void Thing(out int hash)
        {
            hash = 3;
        }


        private void InitializeSearchBookCommand(ref SqlCommand c, SearchBookRequest m)
        {
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.CommandText = "Book.SearchWithAll";
            c.Parameters.AddWithValue("Title", m.Payload.Name);
            c.Parameters.AddWithValue("FirstName", m.Payload.Author.FirstName);
            c.Parameters.AddWithValue("LastName", m.Payload.Author.LastName);
            c.Parameters.AddWithValue("ISBN", m.Payload.ISBN);
            c.Parameters.AddWithValue("GenreDescriptor", m.Payload.Genre);
        }
        private void GrabSearchBookInfo(SqlCommand c, ref SortedSet<BookInfo> ss)
        {
            using (SqlDataReader data = c.ExecuteReader())
            {
                while (data.Read())
                {
                    bool isCheckedOut = data.GetInt32(data.GetOrdinal("CheckedOut")) == 0;
                    if (!isCheckedOut)
                    {
                        string title = data.GetString(data.GetOrdinal("Title"));
                        string aFirst = data.GetString(data.GetOrdinal("AuthorFirstName"));
                        string aLast = data.GetString(data.GetOrdinal("AuthorLastName"));
                        string isbn = data.GetString(data.GetOrdinal("ISBN"));
                        int copyYear = data.GetSqlDateTime(data.GetOrdinal("Copyrightyear")).Value.Year;
                        string pub = data.GetString(data.GetOrdinal("PublisherName"));
                        string gen = data.GetString(data.GetOrdinal("Genre"));
                        BookInfo b = new BookInfo(title, new Author(aFirst, aLast),
                            isbn, gen, pub, copyYear);
                        ss.Add(b);
                    }
                }
            }
        }








        private void CreateNewUser(SendMessage send)
        {
            send(new LoginResponse());
        }
    }
}
