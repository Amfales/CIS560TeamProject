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
    public partial class RenewBooksForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        RenewBooks handleRenewBooks;

        public RenewBooksForm(FormClose hClose, ReturnToMenu hReturn, RenewBooks hRenewBooks)
        {
            InitializeComponent();
            BackColor = Color.SteelBlue;

            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleRenewBooks = hRenewBooks;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxRenewButton_Click(object sender, EventArgs e)
        {
            if (uxBookList.CheckedItems.Count != 0)
            {
                string result = MessageBox.Show(this, "Are you sure you want to renew these books?", "Renew Books", MessageBoxButtons.YesNo).ToString();
                if (result == "Yes")
                {
                    List<int> bookIDs = new List<int>();
                    foreach (ListViewItem item in uxBookList.Items)
                    {
                        if (item.Checked)
                        {
                            bookIDs.Add(Convert.ToInt32(item.SubItems[0].Text));
                        }
                    }

                    Object response = handleRenewBooks(bookIDs);
                    DateTime returnDate = new DateTime();
                    bool success = true;

                    if (success)
                    {
                        MessageBox.Show("Renewal successful! The new due date for your books is " + returnDate.ToShortDateString() + ".");
                        bookIDs.Clear();
                        handleReturnToMenu(this);
                    }
                    else
                    {
                        MessageBox.Show("Renewal unsuccessful. Contact a librarian for assistance.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No books are selected for renewal.");
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            handleReturnToMenu(this);
        }
    }
}
