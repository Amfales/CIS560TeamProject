namespace ClientApplication
{
    partial class ViewBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxQueryPanel = new System.Windows.Forms.Panel();
            this.uxGenreBox = new System.Windows.Forms.ComboBox();
            this.uxISBNBox = new System.Windows.Forms.TextBox();
            this.uxTitleBox = new System.Windows.Forms.TextBox();
            this.uxISBNLabel = new System.Windows.Forms.Label();
            this.uxGenreLabel = new System.Windows.Forms.Label();
            this.uxAuthorLabel = new System.Windows.Forms.Label();
            this.uxTitleLabel = new System.Windows.Forms.Label();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxSearchButton = new System.Windows.Forms.Button();
            this.uxBookList = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxAuthorLastBox = new System.Windows.Forms.TextBox();
            this.uxAuthorFirstBox = new System.Windows.Forms.TextBox();
            this.uxQueryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxQueryPanel
            // 
            this.uxQueryPanel.Controls.Add(this.uxAuthorLastBox);
            this.uxQueryPanel.Controls.Add(this.uxAuthorFirstBox);
            this.uxQueryPanel.Controls.Add(this.uxGenreBox);
            this.uxQueryPanel.Controls.Add(this.uxISBNBox);
            this.uxQueryPanel.Controls.Add(this.uxTitleBox);
            this.uxQueryPanel.Controls.Add(this.uxISBNLabel);
            this.uxQueryPanel.Controls.Add(this.uxGenreLabel);
            this.uxQueryPanel.Controls.Add(this.uxAuthorLabel);
            this.uxQueryPanel.Controls.Add(this.uxTitleLabel);
            this.uxQueryPanel.Location = new System.Drawing.Point(12, 12);
            this.uxQueryPanel.Name = "uxQueryPanel";
            this.uxQueryPanel.Size = new System.Drawing.Size(435, 101);
            this.uxQueryPanel.TabIndex = 2;
            // 
            // uxGenreBox
            // 
            this.uxGenreBox.FormattingEnabled = true;
            this.uxGenreBox.Location = new System.Drawing.Point(55, 62);
            this.uxGenreBox.Name = "uxGenreBox";
            this.uxGenreBox.Size = new System.Drawing.Size(141, 21);
            this.uxGenreBox.TabIndex = 7;
            // 
            // uxISBNBox
            // 
            this.uxISBNBox.Location = new System.Drawing.Point(259, 63);
            this.uxISBNBox.Name = "uxISBNBox";
            this.uxISBNBox.Size = new System.Drawing.Size(151, 20);
            this.uxISBNBox.TabIndex = 6;
            // 
            // uxTitleBox
            // 
            this.uxTitleBox.Location = new System.Drawing.Point(55, 16);
            this.uxTitleBox.Name = "uxTitleBox";
            this.uxTitleBox.Size = new System.Drawing.Size(141, 20);
            this.uxTitleBox.TabIndex = 4;
            // 
            // uxISBNLabel
            // 
            this.uxISBNLabel.AutoSize = true;
            this.uxISBNLabel.Location = new System.Drawing.Point(222, 67);
            this.uxISBNLabel.Name = "uxISBNLabel";
            this.uxISBNLabel.Size = new System.Drawing.Size(35, 13);
            this.uxISBNLabel.TabIndex = 3;
            this.uxISBNLabel.Text = "ISBN:";
            // 
            // uxGenreLabel
            // 
            this.uxGenreLabel.AutoSize = true;
            this.uxGenreLabel.Location = new System.Drawing.Point(14, 66);
            this.uxGenreLabel.Name = "uxGenreLabel";
            this.uxGenreLabel.Size = new System.Drawing.Size(39, 13);
            this.uxGenreLabel.TabIndex = 2;
            this.uxGenreLabel.Text = "Genre:";
            // 
            // uxAuthorLabel
            // 
            this.uxAuthorLabel.AutoSize = true;
            this.uxAuthorLabel.Location = new System.Drawing.Point(216, 19);
            this.uxAuthorLabel.Name = "uxAuthorLabel";
            this.uxAuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.uxAuthorLabel.TabIndex = 1;
            this.uxAuthorLabel.Text = "Author:";
            // 
            // uxTitleLabel
            // 
            this.uxTitleLabel.AutoSize = true;
            this.uxTitleLabel.Location = new System.Drawing.Point(23, 19);
            this.uxTitleLabel.Name = "uxTitleLabel";
            this.uxTitleLabel.Size = new System.Drawing.Size(30, 13);
            this.uxTitleLabel.TabIndex = 0;
            this.uxTitleLabel.Text = "Title:";
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(12, 349);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(92, 23);
            this.uxReturnButton.TabIndex = 4;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxSearchButton
            // 
            this.uxSearchButton.Location = new System.Drawing.Point(190, 119);
            this.uxSearchButton.Name = "uxSearchButton";
            this.uxSearchButton.Size = new System.Drawing.Size(75, 32);
            this.uxSearchButton.TabIndex = 8;
            this.uxSearchButton.Text = "Search";
            this.uxSearchButton.UseVisualStyleBackColor = true;
            this.uxSearchButton.Click += new System.EventHandler(this.uxSearchButton_Click);
            // 
            // uxBookList
            // 
            this.uxBookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Author,
            this.Genre,
            this.ISBN});
            this.uxBookList.GridLines = true;
            this.uxBookList.Location = new System.Drawing.Point(13, 157);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(434, 186);
            this.uxBookList.TabIndex = 9;
            this.uxBookList.UseCompatibleStateImageBehavior = false;
            this.uxBookList.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 140;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 100;
            // 
            // Genre
            // 
            this.Genre.Text = "Genre";
            this.Genre.Width = 100;
            // 
            // ISBN
            // 
            this.ISBN.Text = "ISBN";
            this.ISBN.Width = 90;
            // 
            // uxAuthorLastBox
            // 
            this.uxAuthorLastBox.Location = new System.Drawing.Point(323, 16);
            this.uxAuthorLastBox.Name = "uxAuthorLastBox";
            this.uxAuthorLastBox.Size = new System.Drawing.Size(87, 20);
            this.uxAuthorLastBox.TabIndex = 15;
            this.uxAuthorLastBox.Text = "Last";
            // 
            // uxAuthorFirstBox
            // 
            this.uxAuthorFirstBox.Location = new System.Drawing.Point(259, 16);
            this.uxAuthorFirstBox.Name = "uxAuthorFirstBox";
            this.uxAuthorFirstBox.Size = new System.Drawing.Size(58, 20);
            this.uxAuthorFirstBox.TabIndex = 14;
            this.uxAuthorFirstBox.Text = "First";
            // 
            // ViewBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 382);
            this.Controls.Add(this.uxBookList);
            this.Controls.Add(this.uxSearchButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxQueryPanel);
            this.Name = "ViewBookForm";
            this.Text = "ViewBookForm";
            this.uxQueryPanel.ResumeLayout(false);
            this.uxQueryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uxQueryPanel;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.ComboBox uxGenreBox;
        private System.Windows.Forms.TextBox uxISBNBox;
        private System.Windows.Forms.TextBox uxTitleBox;
        private System.Windows.Forms.Label uxISBNLabel;
        private System.Windows.Forms.Label uxGenreLabel;
        private System.Windows.Forms.Label uxAuthorLabel;
        private System.Windows.Forms.Label uxTitleLabel;
        private System.Windows.Forms.Button uxSearchButton;
        private System.Windows.Forms.ListView uxBookList;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Genre;
        private System.Windows.Forms.ColumnHeader ISBN;
        private System.Windows.Forms.TextBox uxAuthorLastBox;
        private System.Windows.Forms.TextBox uxAuthorFirstBox;
    }
}