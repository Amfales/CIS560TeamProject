namespace ClientApplication
{
    partial class CheckOutForm
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
            this.uxBookIDLabel = new System.Windows.Forms.Label();
            this.uxBookIDBox = new System.Windows.Forms.TextBox();
            this.uxAddButton = new System.Windows.Forms.Button();
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxCheckOutButton = new System.Windows.Forms.Button();
            this.uxBookList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxRemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxBookIDLabel
            // 
            this.uxBookIDLabel.AutoSize = true;
            this.uxBookIDLabel.Location = new System.Drawing.Point(23, 28);
            this.uxBookIDLabel.Name = "uxBookIDLabel";
            this.uxBookIDLabel.Size = new System.Drawing.Size(49, 13);
            this.uxBookIDLabel.TabIndex = 0;
            this.uxBookIDLabel.Text = "Book ID:";
            // 
            // uxBookIDBox
            // 
            this.uxBookIDBox.Location = new System.Drawing.Point(73, 24);
            this.uxBookIDBox.Name = "uxBookIDBox";
            this.uxBookIDBox.Size = new System.Drawing.Size(172, 20);
            this.uxBookIDBox.TabIndex = 1;
            // 
            // uxAddButton
            // 
            this.uxAddButton.Location = new System.Drawing.Point(251, 23);
            this.uxAddButton.Name = "uxAddButton";
            this.uxAddButton.Size = new System.Drawing.Size(89, 23);
            this.uxAddButton.TabIndex = 2;
            this.uxAddButton.Text = "Add to Cart";
            this.uxAddButton.UseVisualStyleBackColor = true;
            this.uxAddButton.Click += new System.EventHandler(this.uxAddButton_Click);
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(26, 253);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(68, 34);
            this.uxReturnButton.TabIndex = 4;
            this.uxReturnButton.Text = "Return to Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxCheckOutButton
            // 
            this.uxCheckOutButton.Location = new System.Drawing.Point(221, 253);
            this.uxCheckOutButton.Name = "uxCheckOutButton";
            this.uxCheckOutButton.Size = new System.Drawing.Size(119, 34);
            this.uxCheckOutButton.TabIndex = 5;
            this.uxCheckOutButton.Text = "Check Out";
            this.uxCheckOutButton.UseVisualStyleBackColor = true;
            this.uxCheckOutButton.Click += new System.EventHandler(this.uxCheckOutButton_Click);
            // 
            // uxBookList
            // 
            this.uxBookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Author});
            this.uxBookList.FullRowSelect = true;
            this.uxBookList.GridLines = true;
            this.uxBookList.Location = new System.Drawing.Point(26, 50);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(314, 197);
            this.uxBookList.TabIndex = 6;
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
            // uxRemoveButton
            // 
            this.uxRemoveButton.Location = new System.Drawing.Point(100, 253);
            this.uxRemoveButton.Name = "uxRemoveButton";
            this.uxRemoveButton.Size = new System.Drawing.Size(115, 34);
            this.uxRemoveButton.TabIndex = 7;
            this.uxRemoveButton.Text = "Remove Selected Book";
            this.uxRemoveButton.UseVisualStyleBackColor = true;
            this.uxRemoveButton.Click += new System.EventHandler(this.uxRemoveButton_Click);
            // 
            // CheckOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 305);
            this.Controls.Add(this.uxRemoveButton);
            this.Controls.Add(this.uxBookList);
            this.Controls.Add(this.uxCheckOutButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxAddButton);
            this.Controls.Add(this.uxBookIDBox);
            this.Controls.Add(this.uxBookIDLabel);
            this.Name = "CheckOutForm";
            this.Text = "CheckOutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxBookIDLabel;
        private System.Windows.Forms.TextBox uxBookIDBox;
        private System.Windows.Forms.Button uxAddButton;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.Button uxCheckOutButton;
        private System.Windows.Forms.ListView uxBookList;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.Button uxRemoveButton;
    }
}