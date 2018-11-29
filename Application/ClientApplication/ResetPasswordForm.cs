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
    public partial class ResetPasswordForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        ResetPassword handleResetPassword;

        public ResetPasswordForm(FormClose hClose, ReturnToMenu hReturn, ResetPassword hReset)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleResetPassword = hReset;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxRetireButton_Click(object sender, EventArgs e) // Actually uxUpdateButton
        {
            if (uxEmailTextbox.Text == "" || uxPasswordTextbox.Text == "")
            {
                MessageBox.Show("Invalid email or password.");
                return;
            }

            string result = MessageBox.Show(this, "Are you sure you want to reset this patron's password?", "Password Reset", MessageBoxButtons.YesNo).ToString();
            if (result == "No") { return; }

            StringBuilder hashString = new StringBuilder();
            byte[] hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(uxPasswordTextbox.Text));
            for (int i = 0; i < hash.Length; i++)
            {
                hashString.Append(hash[i].ToString("x2"));
            }

            handleResetPassword(uxEmailTextbox.Text, hashString.ToString());
        }

        public void HandleResetPasswordResponse(bool success)
        {
            if (success)
            {
                MessageBox.Show("Patron's password was reset successfully.");
                uxEmailTextbox.Text = "";
                uxPasswordTextbox.Text = "";
            }
            else
            {
                MessageBox.Show("Patron's password was not reset successfully. Contact a system administrator for assistance.");
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            uxEmailTextbox.Text = "";
            uxPasswordTextbox.Text = "";
            handleReturnToMenu(this);
        }
    }
}
