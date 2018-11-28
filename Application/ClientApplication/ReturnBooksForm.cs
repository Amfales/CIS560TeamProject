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
    public partial class ReturnBooksForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        AddToBookList handleAddToBookList;
        Return handleReturn;

        public ReturnBooksForm(FormClose hClose, ReturnToMenu hReturnToMenu, AddToBookList hAddToList, Return hReturn)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturnToMenu;
            handleAddToBookList = hAddToList;
            handleReturn = hReturn;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxAddButton_Click_1(object sender, EventArgs e)
        {
            Object book = null;
            try
            {
                book = handleAddToBookList(Convert.ToInt32(uxBookIDBox.Text));
            }
            catch { }

            if (book != null)
            {
                uxBookList.Items.Add(new ListViewItem(new string[] { uxBookIDBox.Text, "title", "author" }));
                uxBookIDBox.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Book ID");
            }
        }

        private void uxCheckOutButton_Click_1(object sender, EventArgs e)
        {
            string result = MessageBox.Show(this, "Are you sure you want to return these books?", "Return", MessageBoxButtons.YesNo).ToString();
            if (result == "Yes")
            {
                if (uxBookList.Items.Count != 0)
                {
                    List<int> bookIDs = new List<int>();
                    foreach (ListViewItem item in uxBookList.Items)
                    {
                        bookIDs.Add(Convert.ToInt32(item.SubItems[0].Text));
                    }

                    bool success = handleReturn(bookIDs);

                    if (success)
                    {
                        MessageBox.Show("Return Successful!");
                        bookIDs.Clear();
                        handleReturnToMenu(this);
                    }
                    else
                    {
                        MessageBox.Show("Return unsuccessful. Contact a system administrator for assistance.");
                    }
                }
            }
        }

        private void uxRemoveButton_Click_1(object sender, EventArgs e)
        {
            if (uxBookList.SelectedItems.Count != 0)
            {
                uxBookList.Items.Remove(uxBookList.SelectedItems[0]);
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            handleReturnToMenu(this);
        }
    }
}
