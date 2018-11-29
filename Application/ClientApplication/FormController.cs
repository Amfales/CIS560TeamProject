using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public delegate void FormClose(FormClosingEventArgs e, Form f);
    public delegate void LoginButton(string email, string password, Form f);
    public delegate void LogoutButton(Form f);
    public delegate void ViewBooksButton(Form f);
    public delegate void ReturnToMenu(Form f);
    public delegate void CheckOutButton(Form f);
    public delegate List<string> GenreRequest();
    public delegate Object AddToBookList(int BookID);
    public delegate List<Object> SearchBooks(string title, string authorFirst, string authorLast, string genre, string isbn);
    public delegate Object CheckOut(List<int> BookIDs);
    public delegate bool Return(List<int> BookIDs);
    public delegate void RenewBooksButton(Form f);
    public delegate void ReturnBooksButton(Form f);
    public delegate void UpdateConditionButton(Form f);
    public delegate void RetireBookButton(Form f);
    public delegate void ResetPasswordButton(Form f);
    public delegate void AddBookButton(Form f);
    public delegate void CreateAccountButton(Form f);
    public delegate Object RenewBooks(List<int> BookIDs);
    public delegate bool UpdateCondition(int BookID, string condition);
    public delegate bool RetireBook(int BookID);
    public delegate bool ResetPassword(string email, string password);
    public delegate bool AddBook(string title, string authorFirst, string authorLast, string publisher, string genre, string isbn, int copyright);
    public delegate bool CreateAccount(string email, string firstName, string lastName, string password, string userType);

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

            login.Show();
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

            string firstName = "Test";
            int loginResponse = 1;

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

            // Clear the password textbox
            login.Controls.Find("uxPasswordTextbox", false)[0].Text = "";

            // If the username and password pair match a user account
            if (userPermissionLevel != PermissionLevel.Invalid)
            {
                // Open the main menu that corresponds to the user's permission level
                switch (userPermissionLevel)
                {
                    // If the user is a patron, show the patron main menu form
                    case PermissionLevel.Patron:
                        // Clear and hide the login form
                        f.Hide();
                        foreach (Control control in f.Controls)
                        {
                            if (control is TextBox)
                            {
                                ((TextBox)control).Text = null;
                            }
                        }

                        // Show and set the patron main menu
                        patronMainMenu.Show();
                        patronMainMenu.Controls.Find("uxWelcomeLabel", false)[0].Text = "Welcome, " + firstName;
                        break;
                    
                    // If the user is an employee, show the employee main menu form
                    case PermissionLevel.Admin:
                        // Clear and hide the login form
                        f.Hide();
                        foreach (Control control in f.Controls)
                        {
                            if (control is TextBox)
                            {
                                ((TextBox)control).Text = null;
                            }
                        }

                        // Show and set the admin main menu
                        adminMainMenu.Show();
                        adminMainMenu.Controls.Find("uxWelcomeLabel", false)[0].Text = "Welcome, " + firstName;
                        break;
                }   
            }
            else // If the user inputs invalid credentials
            {
                // Alert the user
                MessageBox.Show(f, "Invalid username or password");
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
            return new List<string> { "Mystery", "Fantasy", "Nonfiction" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="genre"></param>
        /// <param name="isbn"></param>
        /// <returns></returns>
        List<Object> HandleSearchBooks(string title, string authorFirst, string authorLast, string genre, string isbn)
        {
            return new List<Object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        Object HandleAddToBookList(int BookID)
        {
            if (true)
            {
                return new Object();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        Object HandleCheckOut(List<int> BookIDs)
        {
            return new object();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        bool HandleReturn(List<int> BookIDs)
        {
            return true;
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
            ListView bookList = (ListView)renewBooks.Controls.Find("uxBookList", false)[0];
            bookList.Items.Clear();
            bookList.Items.Add(new ListViewItem(new string[] { "123", "title", "author", "01/02/2009" }));
            bookList.Items.Add(new ListViewItem(new string[] { "345", "title", "author", "01/02/2003" }));

            renewBooks.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BookIDs"></param>
        /// <returns></returns>
        Object HandleRenewBooks(List<int> BookIDs)
        {
            return new object();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        bool HandleUpdateCondition(int bookID, string condition)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        bool HandleRetireBook(int bookID)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool HandleResetPassword(string email, string password)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoArgs"></param>
        /// <returns></returns>
        bool HandleAddBook(string title, string authorFirst, string authorLast, string publisher, string genre, string isbn, int copyright)
        {
            return true;
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
        bool HandleCreateAccount(string email, string firstName, string lastName, string password, string userType)
        {
            return true;
        }
    }
}
