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
    public partial class RetireBookForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        RetireBook handleRetireBook;

        public RetireBookForm(FormClose hClose, ReturnToMenu hReturn, RetireBook hRetire)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleRetireBook = hRetire;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            uxBookIDBox.Text = "";
            handleReturnToMenu(this);
        }

        private void uxRetireButton_Click(object sender, EventArgs e)
        {
            string result = MessageBox.Show(this, "Are you sure you want to retire this book?", "Retire Book", MessageBoxButtons.YesNo).ToString();
            if (result == "No") { return; }

            try
            {
                handleRetireBook(Convert.ToInt32(uxBookIDBox.Text));
            }
            catch
            {
                MessageBox.Show("Invalid BookID.");
                return;
            }
        }

        public void HandleRetireBookResponse(bool success)
        {
            if (success)
            {
                MessageBox.Show("Book successfully retired.");
                uxBookIDBox.Text = "";
            }
            else
            {
                MessageBox.Show("Book was not successfully retired. Contact a system administrator for assistance.");
            }
        }
    }
}
