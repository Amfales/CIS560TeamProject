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
    public partial class LoginForm : Form
    {
        LoginButton handleLoginButton;

        public LoginForm(LoginButton hLoginButton)
        {
            handleLoginButton = hLoginButton;

            InitializeComponent();
            BackColor = Color.SteelBlue;
            uxEmailTextbox.BackColor = Color.LightSteelBlue;
            uxPasswordTextbox.BackColor = Color.LightSteelBlue;
            uxEmailTextbox.Focus();
        }

        private void uxLoginButton_Click(object sender, EventArgs e)
        {
            StringBuilder hashString = new StringBuilder();

            byte[] hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(uxPasswordTextbox.Text));
            for (int i = 0; i < hash.Length; i++)
            {
                hashString.Append(hash[i].ToString("x2"));
            }

            handleLoginButton(uxEmailTextbox.Text, hashString.ToString(), this);

            uxPasswordTextbox.Text = "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void uxPasswordTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uxLoginButton_Click(this, e);
            }
        }
    }
}
