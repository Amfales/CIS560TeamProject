using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;
using SharedLibrary.Requests;
using SharedLibrary.Responses;

namespace ClientApplication
{
    public delegate void FormClose(FormClosingEventArgs e, Form f);
    public delegate void LoginButton(string email, string password, Form f);
    public delegate void LogoutButton(Form f);
    public delegate void ViewBooksButton(Form f);
    public delegate void ReturnToMenu(Form f);
    public delegate void CheckOutButton(Form f);
    public delegate List<string> GenreRequest();
    public delegate void AddToBookList(int BookID, string source);
    public delegate void SearchBooks(string title, string authorFirst, string authorLast, string genre, string isbn);
    public delegate void CheckOut(List<int> BookIDs);
    public delegate void Return(List<int> BookIDs);
    public delegate void RenewBooksButton(Form f);
    public delegate void ReturnBooksButton(Form f);
    public delegate void UpdateConditionButton(Form f);
    public delegate void RetireBookButton(Form f);
    public delegate void ResetPasswordButton(Form f);
    public delegate void AddBookButton(Form f);
    public delegate void CreateAccountButton(Form f);
    public delegate void RenewBooks(List<int> BookIDs);
    public delegate void UpdateCondition(int BookID, string condition);
    public delegate void RetireBook(int BookID);
    public delegate void ResetPassword(string email, string password);
    public delegate void AddBook(string title, string authorFirst, string authorLast, string publisher, string genre, string isbn, int copyright);
    public delegate void CreateAccount(string email, string firstName, string lastName, string password, string userType);

    // enum for the different possible user permission levels
    enum PermissionLevel {Invalid, Patron, Admin}

    public class FormController
    {
        LoginForm login;
        PatronMainMenuForm patronMainMenu;
        ViewBookForm viewBooks;
        CheckOutForm checkOut;
        RenewBooksForm renewBooks;
        AdminMainMenuForm adminMainMenu;
        ReturnBooksForm returnBooks;
        UpdateConditionForm updateCondition;
        RetireBookForm retireBook;
        ResetPasswordForm resetPassword;
        AddBookForm addBook;
        CreateAccountForm createAccount;
        ServerConnection connection;

        string getBookSource;
        string userEmail;
        PermissionLevel userPermissionLevel;

        public FormController()
        {
            login = new LoginForm(HandleLoginButton);
            patronMainMenu = new PatronMainMenuForm(HandleFormClose, HandleLogOutButton, HandleViewBooksButton, HandleCheckOutButton, HandleRenewBooksButton);
            viewBooks = new ViewBookForm(HandleFormClose, HandleReturnToMenu, HandleGenreRequest, HandleSearchBooks);
            checkOut = new CheckOutForm(HandleFormClose, HandleReturnToMenu, HandleAddToBookList, HandleCheckOut);
            renewBooks = new RenewBooksForm(HandleFormClose, HandleReturnToMenu, HandleRenewBooks);
            adminMainMenu = new AdminMainMenuForm(HandleFormClose, HandleLogOutButton, HandleViewBooksButton, HandleCheckOutButton, HandleRenewBooksButton, HandleReturnBooksButton, HandleUpdateConditionButton, HandleRetireBookButton, HandleResetPasswordButton, HandleAddBookButton, HandleCreateAccountButton);
            returnBooks = new ReturnBooksForm(HandleFormClose, HandleReturnToMenu, HandleAddToBookList, HandleReturn);
            updateCondition = new UpdateConditionForm(HandleFormClose, HandleReturnToMenu, HandleUpdateCondition);
            retireBook = new RetireBookForm(HandleFormClose, HandleReturnToMenu, HandleRetireBook);
            resetPassword = new ResetPasswordForm(HandleFormClose, HandleReturnToMenu, HandleResetPassword);
            addBook = new AddBookForm(HandleFormClose, HandleReturnToMenu, HandleGenreRequest, HandleAddBook);
            createAccount = new CreateAccountForm(HandleFormClose, HandleReturnToMenu, HandleCreateAccount);

            connection = new ServerConnection("ws://localhost:12345/library");
            connection.onReceive = OnReceive;

            login.Show();
        }

        void OnReceive(string data)
        {
            IMessage m = Newtonsoft.Json.JsonConvert.DeserializeObject<IMessage>(data);

            switch (m.Type)
            {
                case MessageType.LoginResponse:
                    HandleLoginResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(data));
                    break;

                case MessageType.SearchBookInfoResponse:
                    HandleSearchBooksResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<SearchBookInfoResponse>(data));
                    break;

                case MessageType.GetBookResponse:
                    HandleAddToBookListResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<GetBookResponse>(data));
                    break;

                case MessageType.CheckoutResponse:
                    HandleCheckOutResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<SharedLibrary.Responses.CheckoutResponse>(data));
                    break;

                case MessageType.ReturnResponse:
                    HandleReturnResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<ReturnResponse>(data));
                    break;

                case MessageType.RenewalResponse:
                    HandleRenewBooksResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<RenewalResponse>(data));
                    break;

                case MessageType.UpdateBookConditionResponse:
                    HandleUpdateConditionResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateBookConditionResponse>(data));
                    break;

                case MessageType.RetireBookResponse:
                    HandleRetireBookResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<RetireBookResponse>(data));
                    break;

                case MessageType.ResetPasswordResponse:
                    HandleResetPasswordResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<ResetPasswordResponse>(data));
                    break;

                case MessageType.AddBookResponse:
                    HandleAddBookResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<AddBookResponse>(data));
                    break;

                case MessageType.CreateUserResponse:
                    HandleCreateAccountResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<CreateUserResponse>(data));
                    break;
                case MessageType.ViewCheckedoutResponse:
                    HandleViewCheckedOutResponse(Newtonsoft.Json.JsonConvert.DeserializeObject<ViewCheckedoutResponse>(data));
                    break;
            }
        }

        /// <summary>
        /// Delegate to handle when the X button is pressed on certain forms
        /// </summary>
        /// <param name="e">The closing event</param>
        /// <param name="f">The form invoking the close</param>
        void HandleFormClose(FormClosingEventArgs e, Form f)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            if (e.CloseReason == CloseReason.WindowsShutDown) Application.Exit();

            // Confirm user wants to close
            string result = MessageBox.Show(f, "Are you sure you want to close the application?", "Closing", MessageBoxButtons.YesNo).ToString();
            if (result == "Yes")
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Event that occurs when the login button is pressed on the Login form
        /// </summary>
        /// <param name="email">the input email</param>
        /// <param name="password">the hashed input password</param>
        /// <param name="f">reference to the login form</param>
        void HandleLoginButton(string email, string password, Form f)
        {
            userEmail = email;
            userPermissionLevel = PermissionLevel.Invalid;

            connection.Send(new LoginRequest(email, password));
        }

        void HandleLoginResponse(LoginResponse response)
        {
            if (!response.Payload.UserLoggedIn)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            string firstName = response.Payload.FirstName;
            int loginResponse = response.Payload.PermissionLevel;

            switch (loginResponse)
            {
                case -1:
                    userPermissionLevel = PermissionLevel.Invalid;
                    break;
                case 0:
                    userPermissionLevel = PermissionLevel.Patron;
                    break;
                case 1:
                    userPermissionLevel = PermissionLevel.Admin;
                    break;
            }

            // If the username and password pair match a user account
            if (userPermissionLevel != PermissionLevel.Invalid)
            {
                // Open the main menu that corresponds to the user's permission level
                switch (userPermissionLevel)
                {
                    // If the user is a patron, show the patron main menu form
                    case PermissionLevel.Patron:
                        // Clear and hide the login form
                        login.Invoke(new Action(() =>
                        {
                            login.Hide();
                            foreach (Control control in login.Controls)
                            {
                                if (control is TextBox)
                                {
                                    ((TextBox)control).Text = null;
                                }
                            }
                        }));

                        // Show and set the patron main menu
                        login.Invoke(new Action(() =>
                        {
                           patronMainMenu.Show();
                           patronMainMenu.Controls.Find("uxWelcomeLabel", false)[0].Text = "Welcome, " + firstName;
                       }));
                        break;

                    // If the user is an employee, show the employee main menu form
                    case PermissionLevel.Admin:
                        // Clear and hide the login form
                        login.Invoke(new Action(() =>
                        {
                            login.Hide();
                        
                            foreach (Control control in login.Controls)
                            {
                                if (control is TextBox)
                                {
                                    ((TextBox)control).Text = "";
                                }
                            }
                        }));
                        // Show and set the admin main menu

                        login.Invoke(new Action(() =>
                       {
                           adminMainMenu.Show();
                           adminMainMenu.Controls.Find("uxWelcomeLabel", false)[0].Text = "Welcome, " + firstName;
                       }));
                        
                        break;
                }
            }
            else // If the user inputs invalid credentials
            {
                // Alert the user
                MessageBox.Show(login, "Invalid username or password");
            }
        }

        /// <summary>
        /// Event that occurs when the logout button is pressed on the Main Menu forms
        /// </summary>
        /// <param name="f">reference to the form</param>
        void HandleLogOutButton(Form f)
        {
            string result = MessageBox.Show(f, "Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo).ToString();
            if (result == "Yes")
            {
                f.Hide();
                login.Show();
                userEmail = "";
                userPermissionLevel = PermissionLevel.Invalid;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleViewBooksButton(Form f)
        {
            f.Hide();

            // Clear View Books form
            Control queryBox = viewBooks.Controls.Find("uxQueryPanel", false)[0];
            foreach (Control control in queryBox.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";

                    if (control.Name == "uxAuthorFirstBox") { ((TextBox)control).Text = "First"; }
                    if (control.Name == "uxAuthorLastBox") { ((TextBox)control).Text = "Last"; }
                }
            }
            ListView bookList = (ListView)viewBooks.Controls.Find("uxBookList", false)[0];
            bookList.Items.Clear();

            viewBooks.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleCheckOutButton(Form f)
        {
            f.Hide();

            // Clear Check Out form
            checkOut.Controls.Find("uxBookIDBox", false)[0].Text = "";
            ListView bookList = (ListView)checkOut.Controls.Find("uxBookList", false)[0];
            bookList.Items.Clear();

            checkOut.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleReturnBooksButton(Form f)
        {
            f.Hide();

            // Clear Check Out form
            returnBooks.Controls.Find("uxBookIDBox", false)[0].Text = "";
            ListView bookList = (ListView)returnBooks.Controls.Find("uxBookList", false)[0];
            bookList.Items.Clear();

            returnBooks.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleUpdateConditionButton(Form f)
        {
            f.Hide();
            updateCondition.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleResetPasswordButton(Form f)
        {
            f.Hide();
            resetPassword.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleRetireBookButton(Form f)
        {
            f.Hide();
            retireBook.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleAddBookButton(Form f)
        {
            f.Hide();
            addBook.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleCreateAccountButton(Form f)
        {
            f.Hide();
            createAccount.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        void HandleReturnToMenu(Form f)
        {
            f.Hide();
            if (userPermissionLevel == PermissionLevel.Patron)
            {
                patronMainMenu.Show();
            }
            else if (userPermissionLevel == PermissionLevel.Admin)
            {
                adminMainMenu.Show();
            }
        }

        /// <summary>
        /// Request for the list of available genres in the library
        /// </summary>
        /// <returns></returns>
        List<string> HandleGenreRequest()
        {
            return new List<string> { "Action and Adventure", "Anthology", "Art", "Autobiographies", "Biographies", "Children's", "Comics", "Cookbooks", "Diaries", "Dictionaries", "Drama", "Encyclopedias", "Fantasy", "Guide", "Health", "History", "Horror", "Journals", "Math", "Mystery", "Poetry", "Prayer books", "Romance", "Science", "Self help", "Series", "Travel", "Trilogy" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="genre"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        void HandleSearchBooks(string title, string authorFirst, string authorLast, string genre, string isbn)
        {
            connection.Send(new SearchBookRequest(title, new Author(authorFirst, authorLast), isbn, genre, true));
        }

        void HandleSearchBooksResponse(SearchBookInfoResponse response)
        {
            viewBooks.Invoke(new Action(() =>
           {
               viewBooks.ParseResults(new List<BookInfo>(response.Payload));
           }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        void HandleAddToBookList(int BookID, string source)
        {
            getBookSource = source;
            connection.Send(new GetBookRequest(BookID));
        }

        void HandleAddToBookListResponse(GetBookResponse response)
        {
            if (getBookSource == "return")
            {
                returnBooks.Invoke(new Action(() =>
               {
                   returnBooks.HandleAddToBookListResponse(response.Payload);
               }));
            }
            if (getBookSource == "checkout")
            {
                checkOut.Invoke(new Action(() =>
                {
                    checkOut.HandleAddToCartResponse(response.Payload);
                }));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        void HandleCheckOut(List<int> BookIDs)
        {
            connection.Send(new CheckoutRequest(userEmail, BookIDs));
        }

        void HandleCheckOutResponse(CheckoutResponse response)
        {
            checkOut.Invoke(new Action(() =>
            {
                checkOut.HandleCheckOutResponse(response.Payload.Success, response.Payload.DueDate[0].Date);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        void HandleReturn(List<int> BookIDs)
        {
            connection.Send(new ReturnRequest(BookIDs));
        }

        void HandleReturnResponse(ReturnResponse response)
        {
            returnBooks.Invoke(new Action(() =>
            {
                returnBooks.HandleReturnBooksResponse(response.Payload);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void HandleRenewBooksButton(Form f)
        {
            f.Hide();

            List<Object> checkedOutBooks = new List<Object>();
            // Request list of checked out books with email
            connection.Send(new ViewCheckedoutRequest(userEmail));
        }

        void HandleViewCheckedOutResponse(ViewCheckedoutResponse response)
        {
            login.Invoke(new Action(() =>
            {
                renewBooks.Show();
            }));

            renewBooks.Invoke(new Action(() =>
            {
                ListView bookList = (ListView)renewBooks.Controls.Find("uxBookList", false)[0];
                bookList.Items.Clear();

                List<CheckedoutBook> books = new List<CheckedoutBook>(response.Payload);
                foreach (CheckedoutBook book in books)
                {
                    bookList.Items.Add(new ListViewItem(new string[] { book.BookID.ToString(), book.Name, book.Author.FirstName + " " + book.Author.LastName, book.DueDate.ToShortDateString() }));
                }
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        void HandleRenewBooks(List<int> BookIDs)
        {
            connection.Send(new RenewalRequest(userEmail, BookIDs));
        }

        void HandleRenewBooksResponse(RenewalResponse response)
        {
            renewBooks.Invoke(new Action(() =>
            {
                renewBooks.HandleRenewBooksResponse(response.Payload.Success, response.Payload.DueDates);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        void HandleUpdateCondition(int bookID, string condition)
        {
            connection.Send(new UpdateBookConditionRequest(bookID, condition, userEmail));
        }

        void HandleUpdateConditionResponse(UpdateBookConditionResponse response)
        {
            updateCondition.Invoke(new Action(() =>
            {
                updateCondition.HandleUpdateConditionResponse(response.Payload);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        void HandleRetireBook(int bookID)
        {
            connection.Send(new RetireBookRequest(bookID, userEmail));
        }

        void HandleRetireBookResponse(RetireBookResponse response)
        {
            retireBook.Invoke(new Action(() =>
            {
                retireBook.HandleRetireBookResponse(response.Payload);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        void HandleResetPassword(string email, string password)
        {
            connection.Send(new ResetPasswordRequest(email, password, userEmail));
        }

        void HandleResetPasswordResponse(ResetPasswordResponse response)
        {
            resetPassword.Invoke(new Action(() =>
            {
                resetPassword.HandleResetPasswordResponse(response.Payload);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoArgs"></param>
        /// <returns></returns>
        void HandleAddBook(string title, string authorFirst, string authorLast, string publisher, string genre, string isbn, int copyright)
        {
            connection.Send(new AddBookRequest(userEmail, new BookInfo(title, new Author(authorFirst, authorLast), isbn, genre, publisher, copyright)));
        }

        void HandleAddBookResponse(AddBookResponse response)
        {
            addBook.Invoke(new Action(() =>
            {
                addBook.HandleAddBookResponse(response.Payload);
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        void HandleCreateAccount(string email, string firstName, string lastName, string password, string userType)
        {
            connection.Send(new CreateUserRequest(email, password, firstName, lastName, userType));
        }

        void HandleCreateAccountResponse(CreateUserResponse response)
        {
            createAccount.Invoke(new Action(() =>
            {
                createAccount.HandleCreateAccountResponse(response.Payload);
            }));
        }
    }
}
