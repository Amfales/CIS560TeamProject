namespace ClientApplication
{
    partial class ReturnBooksForm
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
            this.uxBookList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxCheckOutButton = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxBookIDBox = new System.Windows.Forms.TextBox();
            this.uxBookIDLabel = new System.Windows.Forms.Label();
            this.uxRemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxBookList
            // 
            this.uxBookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Author});
            this.uxBookList.FullRowSelect = true;
            this.uxBookList.GridLines = true;
            this.uxBookList.Location = new System.Drawing.Point(29, 48);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(314, 197);
            this.uxBookList.TabIndex = 13;
            this.uxBookList.UseCompatibleStateImageBehavior = false;
            this.uxBookList.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 40;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 150;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 120;
            // 
            // uxCheckOutButton
            // 
            this.uxCheckOutButton.Location = new System.Drawing.Point(224, 251);
            this.uxCheckOutButton.Name = "uxCheckOutButton";
            this.uxCheckOutButton.Size = new System.Drawing.Size(119, 34);
            this.uxCheckOutButton.TabIndex = 12;
            this.uxCheckOutButton.Text = "Return Books";
            this.uxCheckOutButton.UseVisualStyleBackColor = true;
            this.uxCheckOutButton.Click += new System.EventHandler(this.uxCheckOutButton_Click_1);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(29, 251);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(68, 34);
            this.uxReturnButton.TabIndex = 11;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(254, 21);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(89, 23);
            this.uxAddButton.TabIndex = 10;
            this.uxAddButton.Text = "Add Book";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click_1);
            // 
            // uxBookIDBox
            // 
            this.uxBookIDBox.Location = new System.Drawing.Point(76, 22);
            this.uxBookIDBox.Name = "uxBookIDBox";
            this.uxBookIDBox.Size = new System.Drawing.Size(172, 20);
            this.uxBookIDBox.TabIndex = 9;
            // 
            // uxBookIDLabel
            // 
            this.uxBookIDLabel.AutoSize = true;
            this.uxBookIDLabel.Location = new System.Drawing.Point(26, 26);
            this.uxBookIDLabel.Name = "uxBookIDLabel";
            this.uxBookIDLabel.Size = new System.Drawing.Size(49, 13);
            this.uxBookIDLabel.TabIndex = 8;
            this.uxBookIDLabel.Text = "Book ID:";
            // 
            // uxRemoveButton
            // 
            this.uxRemoveButton.Location = new System.Drawing.Point(103, 251);
            this.uxRemoveButton.Name = "uxRemoveButton";
            this.uxRemoveButton.Size = new System.Drawing.Size(115, 34);
            this.uxRemoveButton.TabIndex = 14;
            this.uxRemoveButton.Text = "Remove Selected Book";
            this.uxRemoveButton.UseVisualStyleBackColor = true;
            this.uxRemoveButton.Click += new System.EventHandler(this.uxRemoveButton_Click_1);
            // 
            // ReturnBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 306);
            this.Controls.Add(this.uxBookList);
            this.Controls.Add(this.uxCheckOutButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxAddButton);
            this.Controls.Add(this.uxBookIDBox);
            this.Controls.Add(this.uxBookIDLabel);
            this.Controls.Add(this.uxRemoveButton);
            this.Name = "ReturnBooksForm";
            this.Text = "ReturnBooksForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView uxBookList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.Button uxCheckOutButton;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.Button uxAddButton;
        private System.Windows.Forms.TextBox uxBookIDBox;
        private System.Windows.Forms.Label uxBookIDLabel;
        private System.Windows.Forms.Button uxRemoveButton;
    }
}