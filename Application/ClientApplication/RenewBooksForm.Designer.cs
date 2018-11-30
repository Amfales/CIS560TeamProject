namespace ClientApplication
{
    partial class RenewBooksForm
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
            this.DueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxReturnButton = new System.Windows.Forms.Button();
            this.uxRenewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxBookList
            // 
            this.uxBookList.CheckBoxes = true;
            this.uxBookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Author,
            this.DueDate});
            this.uxBookList.GridLines = true;
            this.uxBookList.Location = new System.Drawing.Point(12, 12);
            this.uxBookList.Name = "uxBookList";
            this.uxBookList.Size = new System.Drawing.Size(404, 166);
            this.uxBookList.TabIndex = 0;
            this.uxBookList.UseCompatibleStateImageBehavior = false;
            this.uxBookList.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 140;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 120;
            // 
            // DueDate
            // 
            this.DueDate.Text = "Due Date";
            this.DueDate.Width = 90;
            // 
            // uxReturnButton
            // 
            this.uxReturnButton.Location = new System.Drawing.Point(13, 185);
            this.uxReturnButton.Name = "uxReturnButton";
            this.uxReturnButton.Size = new System.Drawing.Size(101, 30);
            this.uxReturnButton.TabIndex = 1;
            this.uxReturnButton.Text = "Return To Menu";
            this.uxReturnButton.UseVisualStyleBackColor = true;
            this.uxReturnButton.Click += new System.EventHandler(this.uxReturnButton_Click);
            // 
            // uxRenewButton
            // 
            this.uxRenewButton.Location = new System.Drawing.Point(120, 185);
            this.uxRenewButton.Name = "uxRenewButton";
            this.uxRenewButton.Size = new System.Drawing.Size(296, 30);
            this.uxRenewButton.TabIndex = 2;
            this.uxRenewButton.Text = "Renew Selected Books";
            this.uxRenewButton.UseVisualStyleBackColor = true;
            this.uxRenewButton.Click += new System.EventHandler(this.uxRenewButton_Click);
            // 
            // RenewBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 224);
            this.Controls.Add(this.uxRenewButton);
            this.Controls.Add(this.uxReturnButton);
            this.Controls.Add(this.uxBookList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RenewBooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Books";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView uxBookList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader DueDate;
        private System.Windows.Forms.Button uxReturnButton;
        private System.Windows.Forms.Button uxRenewButton;
    }
}