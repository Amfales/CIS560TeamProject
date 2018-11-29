using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;
using SharedLibrary.Responses;

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

                    handleRenewBooks(bookIDs);
                }
            }
            else
            {
                MessageBox.Show("No books are selected for renewal.");
            }
        }

        public void HandleRenewBooksResponse(bool success, List<DueDateAssociation> returnDates)
        {
            if (success)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Renewal successful! The new due date for your books is: ");
                foreach (DueDateAssociation date in returnDates)
                {
                    sb.Append("\n" + date.BookID + ": " + date.DueDate.ToShortDateString());
                }

                MessageBox.Show(sb.ToString());
                handleReturnToMenu(this);
            }
            else
            {
                MessageBox.Show("Renewal unsuccessful. Contact a librarian for assistance.");
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            handleReturnToMenu(this);
        }
    }
}
