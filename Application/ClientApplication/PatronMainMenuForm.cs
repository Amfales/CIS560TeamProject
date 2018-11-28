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
    public partial class PatronMainMenuForm : Form
    {
        FormClose handleClose;
        LogoutButton handleLogOut;
        ViewBooksButton handleViewBooks;
        CheckOutButton handleCheckOut;
        RenewBooksButton handleRenewBooks;

        public PatronMainMenuForm(FormClose hClose, LogoutButton hLogout, ViewBooksButton hViewBooks, CheckOutButton hCheckOut, RenewBooksButton hRenewBooks)
        {
            handleClose = hClose;
            handleLogOut = hLogout;
            handleViewBooks = hViewBooks;
            handleCheckOut = hCheckOut;
            handleRenewBooks = hRenewBooks;

            InitializeComponent();
            BackColor = Color.SteelBlue;
            uxWelcomeLabel.BackColor = Color.LightSteelBlue;
            uxButtonPanel.BackColor = Color.LightSteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxLogOutButton_Click(object sender, EventArgs e)
        {
            handleLogOut(this);
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
    }
}
