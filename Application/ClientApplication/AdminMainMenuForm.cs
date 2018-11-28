using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class AdminMainMenuForm : Form
    {
        FormClose handleClose;
        LogoutButton handleLogOut;
        ViewBooksButton handleViewBooks;
        CheckOutButton handleCheckOut;
        RenewBooksButton handleRenewBooks;
        ReturnBooksButton handleReturnBooks;
        UpdateConditionButton handleUpdateCondition;
        RetireBookButton handleRetireBook;
        ResetPasswordButton handleResetPassword;
        AddBookButton handleAddBook;

        public AdminMainMenuForm(FormClose hClose, LogoutButton hLogout, ViewBooksButton hViewBooks, CheckOutButton hCheckOut, RenewBooksButton hRenewBooks, ReturnBooksButton hReturnBooks, UpdateConditionButton hUpdate, RetireBookButton hRetire, ResetPasswordButton hReset, AddBookButton hAdd)
        {
            handleClose = hClose;
            handleLogOut = hLogout;
            handleViewBooks = hViewBooks;
            handleCheckOut = hCheckOut;
            handleRenewBooks = hRenewBooks;
            handleReturnBooks = hReturnBooks;
            handleUpdateCondition = hUpdate;
            handleRetireBook = hRetire;
            handleResetPassword = hReset;
            handleAddBook = hAdd;

            InitializeComponent();
            BackColor = Color.SteelBlue;
            uxWelcomeLabel.BackColor = Color.LightSteelBlue;
            uxButtonPanel.BackColor = Color.LightSteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxViewBooksButton_Click(object sender, EventArgs e)
        {
            handleViewBooks(this);
        }

        private void uxCheckOutButton_Click(object sender, EventArgs e)
        {
            handleCheckOut(this);
        }

        private void uxRenewBooksButton_Click(object sender, EventArgs e)
        {
            handleRenewBooks(this);
        }

        private void uxLogOutButton_Click(object sender, EventArgs e)
        {
            handleLogOut(this);
        }

        private void uxResetPasswordButton_Click(object sender, EventArgs e)
        {
            handleResetPassword(this);
        }

        private void uxAddBookButton_Click(object sender, EventArgs e)
        {
            handleAddBook(this);
        }

        private void uxRetireBookButton_Click(object sender, EventArgs e)
        {
            handleRetireBook(this);
        }

        private void uxUpdateBookButton_Click(object sender, EventArgs e)
        {
            handleUpdateCondition(this);
        }

        private void uxReturnBooksButton_Click(object sender, EventArgs e)
        {
            handleReturnBooks(this);
        }
    }
}
