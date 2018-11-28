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
            string title = uxTitleBox.Text;
            string authorFirst = uxAuthorFirstBox.Text;
            string authorLast = uxAuthorLastBox.Text;
            string genre = uxGenreBox.Text;
            string isbn = uxISBNBox.Text;

            uxBookList.Items.Clear();

            List<Object> queryResults = handleSearchBooks(title, authorFirst, authorLast, genre, isbn);

            foreach (Object book in queryResults)
            {
                uxBookList.Items.Add(new ListViewItem(new string[] { title, authorFirst, authorLast, genre, isbn }));
            }
        }
    }
}
