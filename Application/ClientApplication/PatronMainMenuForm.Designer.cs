namespace ClientApplication
{
    partial class PatronMainMenuForm
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
            this.uxWelcomeLabel = new System.Windows.Forms.Label();
            this.uxButtonPanel = new System.Windows.Forms.Panel();
            this.uxRenewBooksButton = new System.Windows.Forms.Button();
            this.uxCheckOutButton = new System.Windows.Forms.Button();
            this.uxViewBooksButton = new System.Windows.Forms.Button();
            this.uxLogOutButton = new System.Windows.Forms.Button();
            this.uxButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxWelcomeLabel
            // 
            this.uxWelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxWelcomeLabel.Location = new System.Drawing.Point(118, 16);
            this.uxWelcomeLabel.Name = "uxWelcomeLabel";
            this.uxWelcomeLabel.Size = new System.Drawing.Size(206, 41);
            this.uxWelcomeLabel.TabIndex = 0;
            this.uxWelcomeLabel.Text = "uxWelcomeLabel";
            this.uxWelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxButtonPanel
            // 
            this.uxButtonPanel.Controls.Add(this.uxRenewBooksButton);
            this.uxButtonPanel.Controls.Add(this.uxCheckOutButton);
            this.uxButtonPanel.Controls.Add(this.uxViewBooksButton);
            this.uxButtonPanel.Location = new System.Drawing.Point(35, 76);
            this.uxButtonPanel.Name = "uxButtonPanel";
            this.uxButtonPanel.Size = new System.Drawing.Size(366, 137);
            this.uxButtonPanel.TabIndex = 1;
            // 
            // uxRenewBooksButton
            // 
            this.uxRenewBooksButton.Location = new System.Drawing.Point(249, 16);
            this.uxRenewBooksButton.Name = "uxRenewBooksButton";
            this.uxRenewBooksButton.Size = new System.Drawing.Size(97, 106);
            this.uxRenewBooksButton.TabIndex = 2;
            this.uxRenewBooksButton.Text = "Renew Books";
            this.uxRenewBooksButton.UseVisualStyleBackColor = true;
            this.uxRenewBooksButton.Click += new System.EventHandler(this.uxRenewBooksButton_Click);
            // 
            // uxCheckOutButton
            // 
            this.uxCheckOutButton.Location = new System.Drawing.Point(134, 16);
            this.uxCheckOutButton.Name = "uxCheckOutButton";
            this.uxCheckOutButton.Size = new System.Drawing.Size(97, 106);
            this.uxCheckOutButton.TabIndex = 1;
            this.uxCheckOutButton.Text = "Check Out Books";
            this.uxCheckOutButton.UseVisualStyleBackColor = true;
            this.uxCheckOutButton.Click += new System.EventHandler(this.uxCheckOutButton_Click);
            // 
            // uxViewBooksButton
            // 
            this.uxViewBooksButton.Location = new System.Drawing.Point(19, 16);
            this.uxViewBooksButton.Name = "uxViewBooksButton";
            this.uxViewBooksButton.Size = new System.Drawing.Size(97, 106);
            this.uxViewBooksButton.TabIndex = 0;
            this.uxViewBooksButton.Text = "View Books";
            this.uxViewBooksButton.UseVisualStyleBackColor = true;
            this.uxViewBooksButton.Click += new System.EventHandler(this.uxViewBooksButton_Click);
            // 
            // uxLogOutButton
            // 
            this.uxLogOutButton.Location = new System.Drawing.Point(352, 12);
            this.uxLogOutButton.Name = "uxLogOutButton";
            this.uxLogOutButton.Size = new System.Drawing.Size(75, 23);
            this.uxLogOutButton.TabIndex = 2;
            this.uxLogOutButton.Text = "Log Out";
            this.uxLogOutButton.UseVisualStyleBackColor = true;
            this.uxLogOutButton.Click += new System.EventHandler(this.uxLogOutButton_Click);
            // 
            // PatronMainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 237);
            this.Controls.Add(this.uxLogOutButton);
            this.Controls.Add(this.uxButtonPanel);
            this.Controls.Add(this.uxWelcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PatronMainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.uxButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uxWelcomeLabel;
        private System.Windows.Forms.Panel uxButtonPanel;
        private System.Windows.Forms.Button uxRenewBooksButton;
        private System.Windows.Forms.Button uxCheckOutButton;
        private System.Windows.Forms.Button uxViewBooksButton;
        private System.Windows.Forms.Button uxLogOutButton;
    }
}