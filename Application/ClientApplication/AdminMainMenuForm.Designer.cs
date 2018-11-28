namespace ClientApplication
{
    partial class AdminMainMenuForm
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
            this.uxButtonPanel = new System.Windows.Forms.Panel();
            this.uxUpdateBookButton = new System.Windows.Forms.Button();
            this.uxRetireBookButton = new System.Windows.Forms.Button();
            this.uxAddBookButton = new System.Windows.Forms.Button();
            this.uxResetPasswordButton = new System.Windows.Forms.Button();
            this.uxRenewBooksButton = new System.Windows.Forms.Button();
            this.uxCheckOutButton = new System.Windows.Forms.Button();
            this.uxViewBooksButton = new System.Windows.Forms.Button();
            this.uxWelcomeLabel = new System.Windows.Forms.Label();
            this.uxLogOutButton = new System.Windows.Forms.Button();
            this.uxReturnBooksButton = new System.Windows.Forms.Button();
            this.uxButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxButtonPanel
            // 
            this.uxButtonPanel.Controls.Add(this.uxReturnBooksButton);
            this.uxButtonPanel.Controls.Add(this.uxUpdateBookButton);
            this.uxButtonPanel.Controls.Add(this.uxRetireBookButton);
            this.uxButtonPanel.Controls.Add(this.uxAddBookButton);
            this.uxButtonPanel.Controls.Add(this.uxResetPasswordButton);
            this.uxButtonPanel.Controls.Add(this.uxRenewBooksButton);
            this.uxButtonPanel.Controls.Add(this.uxCheckOutButton);
            this.uxButtonPanel.Controls.Add(this.uxViewBooksButton);
            this.uxButtonPanel.Location = new System.Drawing.Point(36, 79);
            this.uxButtonPanel.Name = "uxButtonPanel";
            this.uxButtonPanel.Size = new System.Drawing.Size(372, 198);
            this.uxButtonPanel.TabIndex = 4;
            // 
            // uxUpdateBookButton
            // 
            this.uxUpdateBookButton.Location = new System.Drawing.Point(277, 16);
            this.uxUpdateBookButton.Name = "uxUpdateBookButton";
            this.uxUpdateBookButton.Size = new System.Drawing.Size(80, 76);
            this.uxUpdateBookButton.TabIndex = 6;
            this.uxUpdateBookButton.Text = "Update Book Condition";
            this.uxUpdateBookButton.UseVisualStyleBackColor = true;
            this.uxUpdateBookButton.Click += new System.EventHandler(this.uxUpdateBookButton_Click);
            // 
            // uxRetireBookButton
            // 
            this.uxRetireBookButton.Location = new System.Drawing.Point(191, 16);
            this.uxRetireBookButton.Name = "uxRetireBookButton";
            this.uxRetireBookButton.Size = new System.Drawing.Size(80, 76);
            this.uxRetireBookButton.TabIndex = 5;
            this.uxRetireBookButton.Text = "Retire Book";
            this.uxRetireBookButton.UseVisualStyleBackColor = true;
            this.uxRetireBookButton.Click += new System.EventHandler(this.uxRetireBookButton_Click);
            // 
            // uxAddBookButton
            // 
            this.uxAddBookButton.Location = new System.Drawing.Point(105, 16);
            this.uxAddBookButton.Name = "uxAddBookButton";
            this.uxAddBookButton.Size = new System.Drawing.Size(80, 76);
            this.uxAddBookButton.TabIndex = 4;
            this.uxAddBookButton.Text = "Add Book";
            this.uxAddBookButton.UseVisualStyleBackColor = true;
            this.uxAddBookButton.Click += new System.EventHandler(this.uxAddBookButton_Click);
            // 
            // uxResetPasswordButton
            // 
            this.uxResetPasswordButton.Location = new System.Drawing.Point(19, 16);
            this.uxResetPasswordButton.Name = "uxResetPasswordButton";
            this.uxResetPasswordButton.Size = new System.Drawing.Size(80, 76);
            this.uxResetPasswordButton.TabIndex = 3;
            this.uxResetPasswordButton.Text = "Reset User\'s Password";
            this.uxResetPasswordButton.UseVisualStyleBackColor = true;
            this.uxResetPasswordButton.Click += new System.EventHandler(this.uxResetPasswordButton_Click);
            // 
            // uxRenewBooksButton
            // 
            this.uxRenewBooksButton.Location = new System.Drawing.Point(277, 107);
            this.uxRenewBooksButton.Name = "uxRenewBooksButton";
            this.uxRenewBooksButton.Size = new System.Drawing.Size(80, 76);
            this.uxRenewBooksButton.TabIndex = 2;
            this.uxRenewBooksButton.Text = "Renew Books";
            this.uxRenewBooksButton.UseVisualStyleBackColor = true;
            this.uxRenewBooksButton.Click += new System.EventHandler(this.uxRenewBooksButton_Click);
            // 
            // uxCheckOutButton
            // 
            this.uxCheckOutButton.Location = new System.Drawing.Point(191, 107);
            this.uxCheckOutButton.Name = "uxCheckOutButton";
            this.uxCheckOutButton.Size = new System.Drawing.Size(80, 76);
            this.uxCheckOutButton.TabIndex = 1;
            this.uxCheckOutButton.Text = "Check Out Books";
            this.uxCheckOutButton.UseVisualStyleBackColor = true;
            this.uxCheckOutButton.Click += new System.EventHandler(this.uxCheckOutButton_Click);
            // 
            // uxViewBooksButton
            // 
            this.uxViewBooksButton.Location = new System.Drawing.Point(105, 107);
            this.uxViewBooksButton.Name = "uxViewBooksButton";
            this.uxViewBooksButton.Size = new System.Drawing.Size(80, 76);
            this.uxViewBooksButton.TabIndex = 0;
            this.uxViewBooksButton.Text = "View Books";
            this.uxViewBooksButton.UseVisualStyleBackColor = true;
            this.uxViewBooksButton.Click += new System.EventHandler(this.uxViewBooksButton_Click);
            // 
            // uxWelcomeLabel
            // 
            this.uxWelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxWelcomeLabel.Location = new System.Drawing.Point(119, 19);
            this.uxWelcomeLabel.Name = "uxWelcomeLabel";
            this.uxWelcomeLabel.Size = new System.Drawing.Size(206, 41);
            this.uxWelcomeLabel.TabIndex = 3;
            this.uxWelcomeLabel.Text = "uxWelcomeLabel";
            this.uxWelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxLogOutButton
            // 
            this.uxLogOutButton.Location = new System.Drawing.Point(353, 15);
            this.uxLogOutButton.Name = "uxLogOutButton";
            this.uxLogOutButton.Size = new System.Drawing.Size(75, 23);
            this.uxLogOutButton.TabIndex = 5;
            this.uxLogOutButton.Text = "Log Out";
            this.uxLogOutButton.UseVisualStyleBackColor = true;
            this.uxLogOutButton.Click += new System.EventHandler(this.uxLogOutButton_Click);
            // 
            // uxReturnBooksButton
            // 
            this.uxReturnBooksButton.Location = new System.Drawing.Point(19, 107);
            this.uxReturnBooksButton.Name = "uxReturnBooksButton";
            this.uxReturnBooksButton.Size = new System.Drawing.Size(80, 76);
            this.uxReturnBooksButton.TabIndex = 7;
            this.uxReturnBooksButton.Text = "Return Books";
            this.uxReturnBooksButton.UseVisualStyleBackColor = true;
            this.uxReturnBooksButton.Click += new System.EventHandler(this.uxReturnBooksButton_Click);
            // 
            // AdminMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 304);
            this.Controls.Add(this.uxButtonPanel);
            this.Controls.Add(this.uxWelcomeLabel);
            this.Controls.Add(this.uxLogOutButton);
            this.Name = "AdminMainMenuForm";
            this.Text = "AdminMainMenuForm";
            this.uxButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uxButtonPanel;
        private System.Windows.Forms.Button uxUpdateBookButton;
        private System.Windows.Forms.Button uxRetireBookButton;
        private System.Windows.Forms.Button uxAddBookButton;
        private System.Windows.Forms.Button uxResetPasswordButton;
        private System.Windows.Forms.Button uxRenewBooksButton;
        private System.Windows.Forms.Button uxCheckOutButton;
        private System.Windows.Forms.Button uxViewBooksButton;
        private System.Windows.Forms.Label uxWelcomeLabel;
        private System.Windows.Forms.Button uxLogOutButton;
        private System.Windows.Forms.Button uxReturnBooksButton;
    }
}