namespace ClientApplication
{
    partial class AddBookForm
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
            this.uxInfoPanel = new System.Windows.Forms.Panel();
            this.uxAuthorLastBox = new System.Windows.Forms.TextBox();
            this.uxISBNBox = new System.Windows.Forms.TextBox();
            this.uxPublisherBox = new System.Windows.Forms.TextBox();
            this.uxISBNLabel = new System.Windows.Forms.Label();
            this.uxPublisherLabel = new System.Windows.Forms.Label();
            this.uxGenreBox = new System.Windows.Forms.ComboBox();
            this.uxCopyrightBox = new System.Windows.Forms.TextBox();
            this.uxAuthorFirstBox = new System.Windows.Forms.TextBox();
            this.uxTitleBox = new System.Windows.Forms.TextBox();
            this.uxCopyrightLabel = new System.Windows.Forms.Label();
            this.uxGenreLabel = new System.Windows.Forms.Label();
            this.uxAuthorLabel = new System.Windows.Forms.Label();
            this.uxTitleLabel = new System.Windows.Forms.Label();
            this.uxAddBook = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxClearButton = new System.Windows.Forms.Button();
            this.uxInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxInfoPanel
            // 
            this.uxInfoPanel.Controls.Add(this.uxAuthorLastBox);
            this.uxInfoPanel.Controls.Add(this.uxISBNBox);
            this.uxInfoPanel.Controls.Add(this.uxPublisherBox);
            this.uxInfoPanel.Controls.Add(this.uxISBNLabel);
            this.uxInfoPanel.Controls.Add(this.uxPublisherLabel);
            this.uxInfoPanel.Controls.Add(this.uxGenreBox);
            this.uxInfoPanel.Controls.Add(this.uxCopyrightBox);
            this.uxInfoPanel.Controls.Add(this.uxAuthorFirstBox);
            this.uxInfoPanel.Controls.Add(this.uxTitleBox);
            this.uxInfoPanel.Controls.Add(this.uxCopyrightLabel);
            this.uxInfoPanel.Controls.Add(this.uxGenreLabel);
            this.uxInfoPanel.Controls.Add(this.uxAuthorLabel);
            this.uxInfoPanel.Controls.Add(this.uxTitleLabel);
            this.uxInfoPanel.Location = new System.Drawing.Point(12, 12);
            this.uxInfoPanel.Name = "uxInfoPanel";
            this.uxInfoPanel.Size = new System.Drawing.Size(697, 101);
            this.uxInfoPanel.TabIndex = 3;
            // 
            // uxAuthorLastBox
            // 
            this.uxAuthorLastBox.Location = new System.Drawing.Point(355, 16);
            this.uxAuthorLastBox.Name = "uxAuthorLastBox";
            this.uxAuthorLastBox.Size = new System.Drawing.Size(87, 20);
            this.uxAuthorLastBox.TabIndex = 2;
            // 
            // uxISBNBox
            // 
            this.uxISBNBox.Location = new System.Drawing.Point(515, 62);
            this.uxISBNBox.Name = "uxISBNBox";
            this.uxISBNBox.Size = new System.Drawing.Size(151, 20);
            this.uxISBNBox.TabIndex = 6;
            // 
            // uxPublisherBox
            // 
            this.uxPublisherBox.Location = new System.Drawing.Point(515, 16);
            this.uxPublisherBox.Name = "uxPublisherBox";
            this.uxPublisherBox.Size = new System.Drawing.Size(151, 20);
            this.uxPublisherBox.TabIndex = 3;
            // 
            // uxISBNLabel
            // 
            this.uxISBNLabel.AutoSize = true;
            this.uxISBNLabel.Location = new System.Drawing.Point(478, 66);
            this.uxISBNLabel.Name = "uxISBNLabel";
            this.uxISBNLabel.Size = new System.Drawing.Size(35, 13);
            this.uxISBNLabel.TabIndex = 9;
            this.uxISBNLabel.Text = "ISBN:";
            // 
            // uxPublisherLabel
            // 
            this.uxPublisherLabel.AutoSize = true;
            this.uxPublisherLabel.Location = new System.Drawing.Point(460, 19);
            this.uxPublisherLabel.Name = "uxPublisherLabel";
            this.uxPublisherLabel.Size = new System.Drawing.Size(56, 13);
            this.uxPublisherLabel.TabIndex = 8;
            this.uxPublisherLabel.Text = "Publisher: ";
            // 
            // uxGenreBox
            // 
            this.uxGenreBox.FormattingEnabled = true;
            this.uxGenreBox.Location = new System.Drawing.Point(55, 62);
            this.uxGenreBox.Name = "uxGenreBox";
            this.uxGenreBox.Size = new System.Drawing.Size(141, 21);
            this.uxGenreBox.TabIndex = 4;
            // 
            // uxCopyrightBox
            // 
            this.uxCopyrightBox.Location = new System.Drawing.Point(291, 62);
            this.uxCopyrightBox.Name = "uxCopyrightBox";
            this.uxCopyrightBox.Size = new System.Drawing.Size(151, 20);
            this.uxCopyrightBox.TabIndex = 5;
            // 
            // uxAuthorFirstBox
            // 
            this.uxAuthorFirstBox.Location = new System.Drawing.Point(291, 16);
            this.uxAuthorFirstBox.Name = "uxAuthorFirstBox";
            this.uxAuthorFirstBox.Size = new System.Drawing.Size(58, 20);
            this.uxAuthorFirstBox.TabIndex = 1;
            // 
            // uxTitleBox
            // 
            this.uxTitleBox.Location = new System.Drawing.Point(55, 16);
            this.uxTitleBox.Name = "uxTitleBox";
            this.uxTitleBox.Size = new System.Drawing.Size(141, 20);
            this.uxTitleBox.TabIndex = 0;
            // 
            // uxCopyrightLabel
            // 
            this.uxCopyrightLabel.AutoSize = true;
            this.uxCopyrightLabel.Location = new System.Drawing.Point(206, 66);
            this.uxCopyrightLabel.Name = "uxCopyrightLabel";
            this.uxCopyrightLabel.Size = new System.Drawing.Size(79, 13);
            this.uxCopyrightLabel.TabIndex = 3;
            this.uxCopyrightLabel.Text = "Copyright Year:";
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
            this.uxAuthorLabel.Location = new System.Drawing.Point(242, 19);
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
            // uxAddBook
            // 
            this.uxAddBook.Location = new System.Drawing.Point(345, 119);
            this.uxAddBook.Name = "uxAddBook";
            this.uxAddBook.Size = new System.Drawing.Size(364, 34);
            this.uxAddBook.TabIndex = 20;
            this.uxAddBook.Text = "Add Book";
            this.uxAddBook.UseVisualStyleBackColor = true;
            this.uxAddBook.Click += new System.EventHandler(this.uxAddBook_Click);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(12, 119);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(160, 34);
            this.uxReturnButton.TabIndex = 19;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxClearButton
            // 
            this.uxClearButton.Location = new System.Drawing.Point(178, 119);
            this.uxClearButton.Name = "uxClearButton";
            this.uxClearButton.Size = new System.Drawing.Size(161, 34);
            this.uxClearButton.TabIndex = 21;
            this.uxClearButton.Text = "Clear";
            this.uxClearButton.UseVisualStyleBackColor = true;
            this.uxClearButton.Click += new System.EventHandler(this.uxClearButton_Click);
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 163);
            this.Controls.Add(this.uxClearButton);
            this.Controls.Add(this.uxAddBook);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Book";
            this.uxInfoPanel.ResumeLayout(false);
            this.uxInfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uxInfoPanel;
        private System.Windows.Forms.ComboBox uxGenreBox;
        private System.Windows.Forms.TextBox uxCopyrightBox;
        private System.Windows.Forms.TextBox uxAuthorFirstBox;
        private System.Windows.Forms.TextBox uxTitleBox;
        private System.Windows.Forms.Label uxCopyrightLabel;
        private System.Windows.Forms.Label uxGenreLabel;
        private System.Windows.Forms.Label uxAuthorLabel;
        private System.Windows.Forms.Label uxTitleLabel;
        private System.Windows.Forms.Button uxAddBook;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.TextBox uxISBNBox;
        private System.Windows.Forms.TextBox uxPublisherBox;
        private System.Windows.Forms.Label uxISBNLabel;
        private System.Windows.Forms.Label uxPublisherLabel;
        private System.Windows.Forms.TextBox uxAuthorLastBox;
        private System.Windows.Forms.Button uxClearButton;
    }
}