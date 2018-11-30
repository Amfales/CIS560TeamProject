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
    public partial class ViewBookForm : Form
    {
        List<string> genres;
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        SearchBooks handleSearchBooks;

        public ViewBookForm(FormClose hClose, ReturnToMenu hReturnToMenu, GenreRequest hGenreRequest, SearchBooks hSearchBooks)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturnToMenu;
            handleSearchBooks = hSearchBooks;

            InitializeComponent();
            BackColor = Color.SteelBlue;
            uxQueryPanel.BackColor = Color.LightSteelBlue;
            genres = hGenreRequest();
            genres.ForEach(genre => uxGenreBox.Items.Add(genre));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            handleReturnToMenu(this);
        }

        private void uxSearchButton_Click(object sender, EventArgs e)
        {
            string title;
            string authorFirst;
            string authorLast;
            string genre;
            string isbn;

            if (uxTitleBox.Text == "") { title = "%"; }
            else { title = "%" + uxTitleBox.Text + "%"; }

            if (uxAuthorFirstBox.Text == "") { authorFirst = "%"; }
            else { authorFirst = "%" + uxAuthorFirstBox.Text + "%"; }

            if (uxAuthorLastBox.Text == "") { authorLast = "%"; }
            else { authorLast = "%" + uxAuthorLastBox.Text + "%"; }

            if (uxGenreBox.Text == "") { genre = "%"; }
            else { genre = "%" + uxGenreBox.Text + "%"; }

            if (uxISBNBox.Text == "") { isbn = "%"; }
            else { isbn = "%" + uxISBNBox.Text + "%"; }

            uxBookList.Items.Clear();

            handleSearchBooks(title, authorFirst, authorLast, genre, isbn);
        }

        public void ParseResults(List<BookInfo> books)
        {
            foreach (BookInfo book in books)
            {
                uxBookList.Items.Add(new ListViewItem(new string[] { book.Name, book.Author.LastName, book.Genre, book.ISBN }));
            }
        }

        private void uxAuthorFirstBox_Enter(object sender, EventArgs e)
        {
            if (uxAuthorFirstBox.Text == "First") { uxAuthorFirstBox.Text = ""; }
        }

        private void uxAuthorLastBox_Enter(object sender, EventArgs e)
        {
            if (uxAuthorLastBox.Text == "Last") { uxAuthorLastBox.Text = ""; }
        }
    }
}
