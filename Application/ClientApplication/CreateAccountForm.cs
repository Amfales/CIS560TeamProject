using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ClientApplication
{
    public partial class CreateAccountForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        CreateAccount handleCreateAccount;

        public CreateAccountForm(FormClose hClose, ReturnToMenu hReturn, CreateAccount hCreate)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleCreateAccount = hCreate;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxUpdateButton_Click(object sender, EventArgs e)
        {
            if (uxEmailTextbox.Text == "" || uxPasswordTextbox.Text == "" || uxFirstNameBox.Text == "" || uxLastNameBox.Text == "" || uxUserTypeBox.Text == "")
            {
                MessageBox.Show("All fields must be filled.");
                return;
            }

            StringBuilder hashString = new StringBuilder();
            byte[] hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(uxPasswordTextbox.Text));
            for (int i = 0; i < hash.Length; i++)
            {
                hashString.Append(hash[i].ToString("x2"));
            }

            handleCreateAccount(uxEmailTextbox.Text, uxFirstNameBox.Text, uxLastNameBox.Text, hashString.ToString(), uxUserTypeBox.Text);
        }

        public void HandleCreateAccountResponse(bool success)
        {
            if (success)
            {
                MessageBox.Show("User account was created successfully.");
                uxEmailTextbox.Text = "";
                uxPasswordTextbox.Text = "";
                uxFirstNameBox.Text = "";
                uxLastNameBox.Text = "";
                uxUserTypeBox.Text = "";
            }
            else
            {
                MessageBox.Show("User account was not created successfully. Contact a system administrator for assistance.");
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            uxEmailTextbox.Text = "";
            uxPasswordTextbox.Text = "";
            uxFirstNameBox.Text = "";
            uxLastNameBox.Text = "";
            uxUserTypeBox.Text = "";
            handleReturnToMenu(this);
        }

        private void uxUserTypeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uxUpdateButton_Click(this, e);
            }
        }
    }
}
