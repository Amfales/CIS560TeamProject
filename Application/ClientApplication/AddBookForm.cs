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
    public partial class AddBookForm : Form
    {
        List<string> genres;
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        AddBook handleAdd;

        public AddBookForm(FormClose hClose, ReturnToMenu hReturnToMenu, GenreRequest hGenreRequest, AddBook hAdd)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturnToMenu;
            handleAdd = hAdd;

            InitializeComponent();
            BackColor = Color.SteelBlue;
            uxInfoPanel.BackColor = Color.LightSteelBlue;
            genres = hGenreRequest();
            genres.ForEach(genre => uxGenreBox.Items.Add(genre));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxAddBook_Click(object sender, EventArgs e)
        {
            string result = MessageBox.Show(this, "Are you sure you want to add this book to the library?", "Add Book", MessageBoxButtons.YesNo).ToString();
            if (result == "No") { return; }

            foreach (Control control in uxInfoPanel.Controls)
            {
                if (control is TextBox)
                {
                    if (((TextBox)control).Text == "")
                    {
                        MessageBox.Show("All fields must be filled to add a book.");
                        return;
                    }
                }
                else if (control is ComboBox)
                {
                    if (((ComboBox)control).Text == "")
                    {
                        MessageBox.Show("All fields must be filled to add a book.");
                        return;
                    }
                }
            }

            string title = uxTitleBox.Text;
            string authorFirst = uxAuthorFirstBox.Text;
            string authorLast = uxAuthorLastBox.Text;
            string publisher = uxPublisherBox.Text;
            string genre = uxGenreBox.Text;
            int copyright;
            string isbn = uxISBNBox.Text;

            try
            {
                copyright = Convert.ToInt32(uxCopyrightBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid copyright year.");
                return;
            }

            bool success = handleAdd(title, authorFirst, authorLast, publisher, genre, isbn, copyright);

            if (success)
            {
                MessageBox.Show("Book successfully added to library.");
            }
            else
            {
                MessageBox.Show("Book was not successfully added. Contact a system administrator for assistance.");
            }
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in uxInfoPanel.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }

            uxAuthorFirstBox.Text = "First";
            uxAuthorLastBox.Text = "Last";

            handleReturnToMenu(this);
        }

        private void uxClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in uxInfoPanel.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).Text = "";
                }
            }
        }
    }
}
