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

namespace ClientApplication
{
    public partial class CheckOutForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        AddToBookList handleAddToCart;
        CheckOut handleCheckOut;

        public CheckOutForm(FormClose hClose, ReturnToMenu hReturn, AddToBookList hAddToCart, CheckOut hCheckOut)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleAddToCart = hAddToCart;
            handleCheckOut = hCheckOut;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            handleReturnToMenu(this);
        }

        private void uxAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                handleAddToCart(Convert.ToInt32(uxBookIDBox.Text), "checkout");
            }
            catch { }
        }

        public void HandleAddToCartResponse(BookInfo book)
        {
            if (book != null)
            {
                uxBookList.Items.Add(new ListViewItem(new string[] { uxBookIDBox.Text, book.Name, book.Author.FirstName + " " + book.Author.LastName }));
                uxBookIDBox.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid Book ID");
            }
        }

        private void uxCheckOutButton_Click(object sender, EventArgs e)
        {
            string result = MessageBox.Show(this, "Are you sure you want to check out?", "Check Out", MessageBoxButtons.YesNo).ToString();
            if (result == "Yes")
            {
                if (uxBookList.Items.Count != 0)
                {
                    List<int> bookIDs = new List<int>();
                    foreach (ListViewItem item in uxBookList.Items)
                    {
                        bookIDs.Add(Convert.ToInt32(item.SubItems[0].Text));
                    }

                    handleCheckOut(bookIDs);
                }
                else
                {
                    MessageBox.Show("No books in shopping cart.");
                }
            }
        }

        public void HandleCheckOutResponse(bool success, DateTime date)
        {
            if (success)
            {
                MessageBox.Show("Check out successful! The due date for your books is " + date.ToShortDateString() + ".");
                handleReturnToMenu(this);
            }
            else
            {
                MessageBox.Show("Check out unsuccessful. Contact a librarian for assistance.");
            }
        }

        private void uxRemoveButton_Click(object sender, EventArgs e)
        {
            if (uxBookList.SelectedItems.Count != 0)
            {
                uxBookList.Items.Remove(uxBookList.SelectedItems[0]);
            }
        }

        private void uxBookIDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uxAddButton_Click(this, e);
            }
        }
    }
}
